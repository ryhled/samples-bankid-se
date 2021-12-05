using System.Text.Json.Serialization;

namespace Samples.BankId.SE.Clients.Model
{
    public sealed class BankIdCollectResponse
    {
        public string? OrderRef { get; init; }

        public string? Status { get; init; }

        public string? HintCode { get; init; }

        public string? Signature { get; init; }

        public CompletionData CompletionData { get; init; } = new CompletionData();
    }
    public sealed class Cert
    {
        public string? NotBefore { get; init; }

        public string? NotAfter { get; init; }
    }

    public sealed class Device
    {
        public string? IpAddress { get; init; }
    }

    public sealed class User
    {
        public string? PersonalNumber { get; init; }

        public string? Name { get; init; }

        public string? GivenName { get; init; }

        public string? SurName { get; init; }
    }

    public sealed class CompletionData
    {
        public string? Signature { get; init; }

        public string? OcspResponse { get; init; }

        public Cert Cert { get; init; } = new Cert();

        public Device Device { get; init; } = new Device();

        public User User { get; init; } = new User();
    }
}
