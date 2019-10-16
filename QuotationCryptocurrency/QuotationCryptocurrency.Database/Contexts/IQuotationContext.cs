using Microsoft.EntityFrameworkCore;
using QuotationCryptocurrency.Database.Models;

namespace QuotationCryptocurrency.Database
{
    public interface IQuotationContext
    {
        DbSet<Crypto> Cryptos { get; set; }
        DbSet<Quote> Quotes { get; set; }
        DbSet<QuotationView> QuotationsView { get; set; }
    }
}
