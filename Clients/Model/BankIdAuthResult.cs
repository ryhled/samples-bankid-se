namespace Samples.BankId.SE.Clients.Model
{
    public sealed class BankIdAuthResult
    {
        public bool Valid { get; init; }

        public string? Error { get; init; }

        public BankIdCollectResponse? Response { get; init; }
    }
}
