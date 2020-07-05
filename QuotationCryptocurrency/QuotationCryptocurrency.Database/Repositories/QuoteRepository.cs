using System.Collections.Generic;
using QuotationCryptocurrency.Database.Contexts;
using QuotationCryptocurrency.Database.Models;

namespace QuotationCryptocurrency.Database.Repositories
{
    public interface IQuoteRepository
    {
        void Add(QuoteData quoteData);

        void AddRange(IEnumerable<QuoteData> quotes);
    }

    public class QuoteRepository : IQuoteRepository
    {
        private readonly QuotationContext DB;

        public QuoteRepository(QuotationContext db)
        {
            DB = db;
        }

        public void Add(QuoteData quoteData)
        {
            DB.Quotes.Add(quoteData);
            DB.SaveChanges();
        }

        public void AddRange(IEnumerable<QuoteData> quotes)
        {
            DB.Quotes.AddRange(quotes);
            DB.SaveChanges();
        }
    }
}


