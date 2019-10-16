using QuotationCryptocurrency.Database.Models;
using System.Collections.Generic;

namespace QuotationCryptocurrency.Database.Repositories
{
    public interface IQuoteRepository
    {
        void Add(Quote quote);

        void AddRange(IEnumerable<Quote> quotes);
    }
}
