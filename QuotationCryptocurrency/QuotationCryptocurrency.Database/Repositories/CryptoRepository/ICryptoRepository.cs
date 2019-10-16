using QuotationCryptocurrency.Database.Models;
using System.Collections.Generic;

namespace QuotationCryptocurrency.Database.Repositories
{
    public interface ICryptoRepository
    {
        List<Crypto> Get();

        void Add(Crypto crypto);
    }
}
