namespace Samples.BankId.SE.Clients.Model
{
    public sealed class SigningResult
    {
        public static SigningResult Failed(string error) => new(error, new BankIdCollectResponse());

        public static SigningResult Success(BankIdCollectResponse response) => new(String.Empty, response);

        private SigningResult(
            string error,
            BankIdCollectResponse response)
        {
            Error = error;
            Response = response;
        }

        public string Error { get; } = string.Empty;

        public bool Succeeded => string.IsNullOrEmpty(Error);

        public BankIdCollectResponse Response { get; }
    }
}
