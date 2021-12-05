namespace Samples.BankId.SE.Clients
{
    public class BankIdException : Exception
    {
        public BankIdException()
        {
        }

        public BankIdException(string? message) : base(message)
        {
        }
    }
}
