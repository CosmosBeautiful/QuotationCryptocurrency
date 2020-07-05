using Microsoft.EntityFrameworkCore;
using QuotationCryptocurrency.Database.Models;

namespace QuotationCryptocurrency.Database.Contexts
{
    public interface IQuotationContext
    {
        DbSet<CryptoData> Cryptos { get; set; }
        DbSet<QuoteData> Quotes { get; set; }
        DbSet<QuotationDataView> QuotationsView { get; set; }
    }

    public class QuotationContext : DbContext, IQuotationContext
    {
        public DbSet<CryptoData> Cryptos { get; set; }
        public DbSet<QuoteData> Quotes { get; set; }
        public DbSet<QuotationDataView> QuotationsView { get; set; }

        public QuotationContext(DbContextOptions<QuotationContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
