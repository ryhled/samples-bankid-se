using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Options;
using Samples.BankId.SE.Clients;
using Samples.BankId.SE.Configuration;
using System.Net;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

// Adds BankId configuration
builder.Services.Configure<BankIdConfiguration>(builder.Configuration.GetSection("BankId"));
builder.Services.AddSingleton<IValidateOptions<BankIdConfiguration>, BankIdConfigurationValidator>();
builder.Services.AddTransient<IBankIdClient, SeBankIdClient>();

// https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.features.formoptions?view=aspnetcore-6.0
builder.Services.Configure<FormOptions>(x =>
{
    x.BufferBody = false; // Enables full request body buffering. Use this if multiple components need to read the raw stream. Defaults to false.
    x.KeyLengthLimit = 2048; // A limit on the length of individual keys. Defaults to 2,048 bytes‬, which is approximately 2KB.
    x.ValueLengthLimit = 4194304; // A limit on the length of individual form values. Defaults to 4,194,304 bytes‬, which is approximately 4MB.
    x.ValueCountLimit = 2048;// A limit for the number of form entries to allow. Defaults to 1024.
    x.MultipartHeadersCountLimit = 32; // A limit for the number of headers to allow in each multipart section. Headers with the same name will be combined. Defaults to 16.
    x.MultipartHeadersLengthLimit = 32768; // A limit for the total length of the header keys and values in each multipart section. Defaults to 16,384‬ bytes‬, which is approximately 16KB.
    x.MultipartBoundaryLengthLimit = 256; // A limit for the length of the boundary identifier. Defaults to 128 bytes‬.
    x.MultipartBodyLengthLimit = 134217728; // A limit for the length of each multipart body. Defaults to 134,217,728 bytes‬, which is approximately 128MB.
});

builder.Services.AddHttpClient<IBankIdClient, SeBankIdClient>()
    .ConfigurePrimaryHttpMessageHandler(() =>
    {
        HttpClientHandler handler = new HttpClientHandler
        {
            AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
            ClientCertificateOptions = ClientCertificateOption.Manual,
            SslProtocols = SslProtocols.Tls12 | SslProtocols.Tls11,
            ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; }
        };
        handler.ClientCertificates.Add(new X509Certificate2(".\\Certificates\\Client\\FPTestcert3_20200618.p12", "qwerty123"));
        return handler;
    });

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

// https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/proxy-load-balancer?view=aspnetcore-6.0
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
