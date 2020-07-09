using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using QuotationCryptocurrency.Database.Contexts;
using QuotationCryptocurrency.Database.Tests.Contexts;
using QuotationCryptocurrency.Web.Common.Tests.Helpers;

namespace QuotationCryptocurrency.Database.Tests.Helpers
{
    public class ConfigurationHelper
    {
        public const string QuotationConnectionName = "QuotationConnection";

        public static QuotationContextTest GetQuotationContextTest()
        {
            var configuration = AppSettingsHelper.GetConfiguration();
            var options = new DbContextOptionsBuilder<QuotationContext>()
                .UseSqlServer(configuration.GetConnectionString(QuotationConnectionName))
                .Options;

            var contextTest = new QuotationContextTest(options);

            return contextTest;
        }
    }
}
