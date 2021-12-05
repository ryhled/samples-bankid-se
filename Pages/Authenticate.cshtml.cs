using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Samples.BankId.SE.Clients;
using System.Text.Json;

namespace Samples.BankId.SE.Pages
{
    [ValidateAntiForgeryToken]
    public class AuthenticateModel : PageModel
    {
        public string StatusMessage { get; set; } = String.Empty;

        public string RawResponse { get; set; } = String.Empty;

        [BindProperty]
        public string SocialSecurityNumber { get; set; } = String.Empty;

        [BindProperty]
        public bool SameDevice { get; set; }

        private readonly IBankIdClient _bankIdClient;

        public AuthenticateModel(IBankIdClient bankIdClient)
        {
            _bankIdClient = bankIdClient;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAuthenticate()
        {
            var response = await _bankIdClient.Authenticate(SocialSecurityNumber);

            StatusMessage = response.Valid ? "Authentication succeded!" : $"Authentication failed ({response.Error})!";
            RawResponse = JsonSerializer.Serialize(response.Response);

            return Page();
        }
    }
}
