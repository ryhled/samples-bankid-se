using Microsoft.Extensions.Options;

namespace Samples.BankId.SE.Configuration
{
    public sealed class BankIdConfiguration
    {
        public const string defaultUriString = "http://127.0.0.1";

        public Uri Authority { get; init; } = new Uri(defaultUriString);

        public int TimeoutInMilliseconds { get; init; } = 60000;
    }

    public sealed class BankIdConfigurationValidator : IValidateOptions<BankIdConfiguration>
    {
        public ValidateOptionsResult Validate(string name, BankIdConfiguration options)
        {
            if(options.Authority.ToString().Contains(BankIdConfiguration.defaultUriString))
            {
                return ValidateOptionsResult.Fail("BankId Authority not set.");
            }

            return ValidateOptionsResult.Success;
        }
    }
}
