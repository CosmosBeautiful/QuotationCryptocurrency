using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using QuotationCryptocurrency.Database.Contexts;
using QuotationCryptocurrency.Database.Tests.Helpers;

namespace QuotationCryptocurrency.Database.Tests.Contexts
{
    public class QuotationContextTest : QuotationContext
    {
        public QuotationContextTest(DbContextOptions<QuotationContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = ConfigurationHelper.GetConfiguration();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString(ConfigurationHelper.QuotationConnectionName));
        }
    }
}
