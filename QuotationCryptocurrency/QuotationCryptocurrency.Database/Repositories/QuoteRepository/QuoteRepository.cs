using QuotationCryptocurrency.Database.Models;
using System.Collections.Generic;

namespace QuotationCryptocurrency.Database.Repositories
{
    public class QuoteRepository : IQuoteRepository
    {
        private readonly QuotationContext _db;

        public QuoteRepository(QuotationContext db)
        {
            _db = db;
        }

        public void Add(Quote quote)
        {
            _db.Quotes.Add(quote);
            _db.SaveChanges();
        }

        public void AddRange(IEnumerable<Quote> quotes)
        {
            _db.Quotes.AddRange(quotes);
            _db.SaveChanges();
        }
    }
}


