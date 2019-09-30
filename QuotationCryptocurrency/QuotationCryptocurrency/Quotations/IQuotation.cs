using QuotationCryptocurrency.Models;
using System.Collections.Generic;

namespace QuotationCryptocurrency.Quotations
{
    public interface IQuotation
    {
        IEnumerable<IModel> GetQuotation();
    }
}