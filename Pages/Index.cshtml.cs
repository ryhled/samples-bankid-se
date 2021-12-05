using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using Samples.BankId.SE.Configuration;

namespace Samples.BankId.SE.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    public readonly BankIdConfiguration BankIdConfiguration;

    public IndexModel(
        ILogger<IndexModel> logger,
        IOptions<BankIdConfiguration> configuration)
    {
        _logger = logger;
        BankIdConfiguration = configuration.Value;
    }

    public void OnGet()
    {

    }
}
