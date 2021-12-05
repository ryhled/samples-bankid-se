using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Samples.BankId.SE.Clients;
using Samples.BankId.SE.Extensions;
using System.Text.Json;

namespace Samples.BankId.SE.Pages
{
    [ValidateAntiForgeryToken]
    public class SignTextModel : PageModel
    {
        [BindProperty]
        public string SigningText { get; set; } = String.Empty;

        [BindProperty]
        public string SocialSecurityNumber { get; set; } = String.Empty;

        [BindProperty]
        public bool SameDevice { get; set; }

        public string StatusMessage { get; set; } = String.Empty;

        public string RawResponse { get; set; } = String.Empty;

        public string Signature { get; set; } = String.Empty;

        public string XmlDsig { get; set; } = String.Empty;

        private readonly IBankIdClient _bankIdClient;

        public SignTextModel(IBankIdClient bankIdClient)
        {
            _bankIdClient = bankIdClient;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostSign(IFormCollection collection)
        {
            var response = await _bankIdClient.Sign(
                SocialSecurityNumber,
                SigningText);

            StatusMessage = response.Succeeded ? "Signing succeeded!" : $"Signing failed ({response.Error})!";
            RawResponse = JsonSerializer.Serialize(response.Response);
            Signature = response?.Response?.CompletionData?.Signature ?? String.Empty;
            XmlDsig = response?.Response?.CompletionData?.Signature?.Decode() ?? string.Empty;
            return Page();
        }
    }
}
