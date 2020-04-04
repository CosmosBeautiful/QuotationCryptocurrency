using QuotationCryptocurrency.Database.Models;
using System.Collections.Generic;

namespace QuotationCryptocurrency.Database.Repositories
{
    public interface IQuotationRepository : IRepository
    {
        List<Quotation> Get();
    }
}
