using Microsoft.EntityFrameworkCore;
using QuotationCryptocurrency.Database.Models;

namespace QuotationCryptocurrency.Database
{
    public class QuotationContext : DbContext, IQuotationContext
    {
        public DbSet<Crypto> Cryptos { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Quotation> QuotationsView { get; set; }

        public QuotationContext(DbContextOptions<QuotationContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
