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
        
        QuotationViewModel CreateViewModel(List<QuotationView> quotationsView, int pageData, QuotationSortType sortOrder, string selectedName);

        void UpdateQuotes();
    }
}
