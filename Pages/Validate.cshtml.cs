using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Samples.BankId.SE.Clients;
using Samples.BankId.SE.Clients.Model;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

namespace Samples.BankId.SE.Pages
{
    [ValidateAntiForgeryToken]
    public class ValidateModel : PageModel
    {
        [BindProperty]
        public string Signature { get; set; } = String.Empty;

        public string StatusMessage { get; set; } = String.Empty;

        public string Result { get; set; } = String.Empty;

        private readonly IBankIdClient _bankIdClient;

        public ValidateModel(IBankIdClient bankIdClient)
        {
            _bankIdClient = bankIdClient;
        }

        public void OnGet()
        {
        }

        public void OnPostValidate()
        {
            BankIdValidationResult result = _bankIdClient.Validate(Signature);

            StatusMessage = result.Valid ? "Validation succeeded!" : $"Validation failed! ({result.Error})";

            Result = JsonSerializer.Serialize(new
            {
                result.SignatureData,
                result.Signatory,
                result.Certificate?.Subject,
                SimpleName = result.Certificate?.GetNameInfo(X509NameType.SimpleName, true),
                DnsName = result.Certificate?.GetNameInfo(X509NameType.DnsName, true),
                EmailName = result.Certificate?.GetNameInfo(X509NameType.EmailName, true),
                UrlName = result.Certificate?.GetNameInfo(X509NameType.UrlName, true),
                NotBefore = result.Certificate?.NotBefore.ToString(),
                NotAfter = result.Certificate?.NotAfter.ToString()
            });
        }
    }
}
