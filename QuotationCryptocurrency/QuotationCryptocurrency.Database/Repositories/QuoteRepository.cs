using QuotationCryptocurrency.Database.Contexts;
using QuotationCryptocurrency.Database.Models;
using System.Collections.Generic;

namespace QuotationCryptocurrency.Database.Repositories
{
    public interface IQuoteRepository : ICommand<QuoteData>
    {
        void SaveRange(IEnumerable<QuoteData> quotes);
    }

    public class QuoteRepository : IQuoteRepository
    {
        private readonly QuotationContext DB;

        public QuoteRepository(QuotationContext db)
        {
            DB = db;
        }

        public QuoteData Create(QuoteData quote)
        {
            var newQuote = DB.Quotes.Add(quote);
            DB.SaveChanges();

            return newQuote.Entity;
        }

        public void SaveRange(IEnumerable<QuoteData> quotes)
        {
            DB.Quotes.AddRange(quotes);
            DB.SaveChanges();
        }

        public void Update(QuoteData quote)
        {
            DB.Quotes.Update(quote);
            DB.SaveChanges();
        }

        public void Delete(int id)
        {
            DB.Quotes.Remove(new QuoteData { Id = id });
            DB.SaveChanges();
        }
    }
}


