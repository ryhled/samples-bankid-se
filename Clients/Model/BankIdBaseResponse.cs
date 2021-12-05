namespace Samples.BankId.SE.Clients.Model
{
    public class BankIdBaseResponse
    {
        public BankIdBaseResponse(
            string? autoStartToken,
            string? orderRef)
        {
            AutoStartToken = autoStartToken;
            OrderRef = orderRef;
        }

        public string? AutoStartToken { get; }
        public string? OrderRef { get; }
    }
}
