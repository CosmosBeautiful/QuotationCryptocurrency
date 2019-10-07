using QuotationCryptocurrency.FilterModels.Quotation;
using QuotationCryptocurrency.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuotationCryptocurrency.Repository
{
    public interface IQuotationRepository : IRepository
    {
        List<QuotationView> Get();
        
        void UpdateQuotes();
    }
}
