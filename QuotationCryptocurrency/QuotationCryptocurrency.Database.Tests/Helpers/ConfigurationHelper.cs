using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using QuotationCryptocurrency.Database.Contexts;
using QuotationCryptocurrency.Database.Tests.Contexts;
using System.IO;

namespace QuotationCryptocurrency.Database.Tests.Helpers
{
    public class ConfigurationHelper
    {
        private const string AppSettingsName = "appsettings.json";

        public const string QuotationConnectionName = "QuotationConnection";

        public static IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(AppSettingsName);

            var configuration = builder.Build();
            return configuration;
        }

        public static QuotationContextTest GetQuotationContextTest()
        {
            var configuration = GetConfiguration();
            var options = new DbContextOptionsBuilder<QuotationContext>()
                .UseSqlServer(configuration.GetConnectionString(QuotationConnectionName))
                .Options;

            var contextTest = new QuotationContextTest(options);

            return contextTest;
        }
    }
}
