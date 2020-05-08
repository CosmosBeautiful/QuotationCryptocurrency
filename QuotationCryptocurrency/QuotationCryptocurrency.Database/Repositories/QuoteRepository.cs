using System.Collections.Generic;
using QuotationCryptocurrency.Database.Contexts;
using QuotationCryptocurrency.Database.Models;

namespace QuotationCryptocurrency.Database.Repositories
{
    public interface IQuoteRepository
    {
        void Add(Quote quote);

        void AddRange(IEnumerable<Quote> quotes);
    }

    public class QuoteRepository : IQuoteRepository
    {
        private readonly QuotationContext DB;

        public QuoteRepository(QuotationContext db)
        {
            DB = db;
        }

        public void Add(Quote quote)
        {
            DB.Quotes.Add(quote);
            DB.SaveChanges();
        }

        public void AddRange(IEnumerable<Quote> quotes)
        {
            DB.Quotes.AddRange(quotes);
            DB.SaveChanges();
        }
    }
}


