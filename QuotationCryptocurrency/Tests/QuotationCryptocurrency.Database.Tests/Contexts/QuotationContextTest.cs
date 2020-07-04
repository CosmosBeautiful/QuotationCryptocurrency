using Microsoft.EntityFrameworkCore;
using QuotationCryptocurrency.Database.Contexts;

namespace QuotationCryptocurrency.Database.Tests.Contexts
{
    public class QuotationContextTest : QuotationContext
    {
        public QuotationContextTest(DbContextOptions<QuotationContext> options) : base(options)
        {
        }
    }
}
