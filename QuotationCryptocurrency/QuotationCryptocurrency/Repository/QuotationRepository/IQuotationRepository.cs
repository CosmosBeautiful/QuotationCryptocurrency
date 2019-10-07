using QuotationCryptocurrency.Quotations;
using System.Collections.Generic;

namespace QuotationCryptocurrency.Repository
{
    public interface IQuotationRepository : IRepository
    {
        List<QuotationModel> Get();
        
        void UpdateQuotes();
    }
}
