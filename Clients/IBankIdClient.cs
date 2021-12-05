using Samples.BankId.SE.Clients.Model;

namespace Samples.BankId.SE.Clients
{
    public interface IBankIdClient
    {
        Task<BankIdAuthResult> Authenticate(string socialSecuritNumber);

        BankIdValidationResult Validate(string signature);

        Task<SigningResult> Sign(string? socialSecurityNumber, string signingText);
    }
}
