using System.Security.Cryptography.X509Certificates;

namespace Samples.BankId.SE.Clients.Model
{
    public sealed class BankIdValidationResult
    {
        public bool Valid { get; init; }

        public string? Error { get; init; }

        public string? VisibleData { get; init; }

        public string? NonVisibleData { get; init; }

        public string? Signatory { get; init; }

        public X509Certificate2? Certificate { get; init; }
    }
}
