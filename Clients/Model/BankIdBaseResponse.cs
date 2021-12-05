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

        /// <summary>
        /// Used to compile the start url according to launching.
        /// https://www.bankid.com/utvecklare/guider/teknisk-integrationsguide/programstart
        /// </summary>
        public string? AutoStartToken { get; }

        /// <summary>
        /// Used to collect the status of the order.
        /// </summary>
        public string? OrderRef { get; }

        /// <summary>
        /// 5.1 only - Used to compute the animated QR code.
        /// https://www.bankid.com/utvecklare/guider/teknisk-integrationsguide/qrkoder
        /// </summary>
        public string? QrStartToken { get; }

        /// <summary>
        /// 5.1 only - Used to compute the animatedQR code.
        /// </summary>
        public string? QrStartSecret { get; }
    }
}
