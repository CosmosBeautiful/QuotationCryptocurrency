using QuotationCryptocurrency.Database.Models;

namespace QuotationCryptocurrency.Database.Repositories
{
    public interface IQuoteRepository
    {
        void Add(Quote quote);

    }
}
