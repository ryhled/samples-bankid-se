using Microsoft.Extensions.Options;
using Samples.BankId.SE.Clients.Model;
using Samples.BankId.SE.Configuration;
using Samples.BankId.SE.Extensions;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Text.Json;
using System.Xml;
using System.Xml.Serialization;

namespace Samples.BankId.SE.Clients
{
    public class SeBankIdClient : IBankIdClient
    {
        private readonly HttpClient _client;
        private readonly BankIdConfiguration _configuration;

        private static readonly JsonSerializerOptions serializationOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        public SeBankIdClient(
            HttpClient httpClient,
            IOptions<BankIdConfiguration> configuration)
        {
            _client = httpClient;
            _configuration = configuration.Value;
            _client.BaseAddress = _configuration.Authority;
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<BankIdAuthResult> Authenticate(string socialSecuritNumber)
        {
            StringContent authRequest = BuildRequestContent(new
            {
                PersonalNumber = socialSecuritNumber,
                EndUserIp = "127.0.0.1"
            });

            HttpResponseMessage authResponse = await _client.PostAsync("/rp/v5/auth", authRequest);

            if (authResponse.IsSuccessStatusCode == true)
            {
                BankIdBaseResponse authResponseObject = await authResponse.Content.ReadFromJsonAsync<BankIdBaseResponse>()
                    ?? throw new BankIdException($"Auth response content was not of type {nameof(BankIdBaseResponse)}");
                using StringContent collectRequest = BuildRequestContent(new { authResponseObject?.OrderRef });

                var timeout = DateTime.UtcNow.AddMilliseconds(_configuration.TimeoutInMilliseconds);
                while (DateTime.UtcNow < timeout)
                {
                    HttpResponseMessage collectResponse = await _client.PostAsync("/rp/v5/collect", collectRequest);

                    if (collectResponse.IsSuccessStatusCode == true)
                    {
                        BankIdCollectResponse collectResponseObject = await collectResponse.Content.ReadFromJsonAsync<BankIdCollectResponse>()
                            ?? throw new BankIdException($"Auth response content was not of type {nameof(BankIdCollectResponse)}");

                        if (collectResponseObject.Status == "complete")
                        {
                            return new BankIdAuthResult
                            {
                                Valid = true,
                                Response = collectResponseObject
                            };
                        }

                        if (collectResponseObject.Status == "failed")
                        {
                            return new BankIdAuthResult
                            {
                                Valid = false,
                                Error = collectResponseObject.HintCode ?? collectResponse.ReasonPhrase
                            };
                        }
                    }
                    else
                    {
                        return new BankIdAuthResult
                        {
                            Valid = false,
                            Error = collectResponse.ReasonPhrase
                        };
                    }

                    await Task.Delay(1500);
                }

                await _client.PostAsync("/rp/v5/cancel", collectRequest);
            }

            return new BankIdAuthResult
            {
                Valid = false,
                Error = "Authentication attempt timed out."
            };
        }

        public async Task<SigningResult> Sign(string? socialSecurityNumber, string signingText)
        {
            using StringContent signingRequest = BuildRequestContent(new
            {
                PersonalNumber = socialSecurityNumber,
                EndUserIp = "176.10.189.252",
                UserVisibleData = signingText.Encode(),
                UserNonVisibleData = "non-visible".Encode()
            });

            // Initialize signing
            HttpResponseMessage signingResponse = await _client.PostAsync("/rp/v5/sign", signingRequest);

            if(!signingResponse.IsSuccessStatusCode)
            {
                throw new BankIdException($"Signing request failed, {signingResponse.ReasonPhrase}");
            }

            BankIdBaseResponse responseObject = await signingResponse.Content.ReadFromJsonAsync<BankIdBaseResponse>()
                ?? throw new BankIdException($"Could not parse signing response.");

            StringContent collectRequest = BuildRequestContent(new { responseObject.OrderRef });

            var timeout = DateTime.UtcNow.AddMilliseconds(_configuration.TimeoutInMilliseconds);
            while(DateTime.UtcNow < timeout)
            {
                // Try collect signing result
                HttpResponseMessage collectResponse = await _client.PostAsync("/rp/v5/collect", collectRequest);

                if (collectResponse.IsSuccessStatusCode != true)
                {
                    await _client.PostAsync("/rp/v5/cancel", collectRequest);
                    return SigningResult.Failed(collectResponse.ReasonPhrase ?? collectResponse.StatusCode.ToString());
                }

                var raw = await collectResponse.Content.ReadAsStringAsync();
                var collectResponseObject = await collectResponse.Content.ReadFromJsonAsync<BankIdCollectResponse>()
                    ?? throw new BankIdException($"Could not parse collect response.");

                if (collectResponseObject.Status == "complete")
                {
                    return SigningResult.Success(collectResponseObject);
                }

                if (collectResponseObject.Status == "failed")
                {
                    return SigningResult.Failed(collectResponseObject.HintCode ?? collectResponseObject.Status);
                }

                await Task.Delay(1500);
            }

            await _client.PostAsync("/rp/v5/cancel", collectRequest);
            throw new BankIdException("BankIdSigning attempt failed or timed out.");
        }

        public BankIdValidationResult Validate(string signature)
        {
            try
            {
                var xmlString = signature.Decode();
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xmlString);

                SignedXml signedXml = new();
                signedXml.LoadXml(doc.GetElementsByTagName("Signature")[0] as XmlElement
                    ?? throw new BankIdException("Failed to get signature xml element"));

                XmlSignature signatureXml;
                XmlSerializer serializer = new(typeof(XmlSignature));
                using (TextReader reader = new StringReader(xmlString))
                {
                    signatureXml = serializer.Deserialize(reader) as XmlSignature ?? throw new Exception();
                }
                var sign = doc.GetElementsByTagName("Signature")[0];
                var tst = sign?.SelectSingleNode("Object");

                return new BankIdValidationResult
                {
                    Certificate = new X509Certificate2(Convert.FromBase64String(signatureXml.KeyInfo?.X509Data?.X509Certificate?[0] ?? throw new BankIdException())),
                    VisibleData = Encoding.UTF8.GetString(Convert.FromBase64String(signatureXml.Object?.BankIdSignedData?.UsrVisibleData?.Text ?? throw new BankIdException())),
                    NonVisibleData = Encoding.UTF8.GetString(Convert.FromBase64String(signatureXml.Object?.BankIdSignedData?.UsrNonVisibleData?.Text ?? throw new BankIdException())),
                    Valid = signedXml.CheckSignature()
                };
            }
            catch (Exception ex)
            {
                return new BankIdValidationResult
                {
                    Valid = false,
                    Error = ex.ToString() 
                };
            }
        }

        private static StringContent BuildRequestContent(object data)
        {
            var dataJson = JsonSerializer.Serialize(data, serializationOptions);
            var content = new StringContent(dataJson);
            content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
            return content;
        }
    }
}
