using System.Collections.Generic;
using System.Linq;
using QuotationCryptocurrency.Database.Contexts;
using QuotationCryptocurrency.Database.Models;

namespace QuotationCryptocurrency.Database.Repositories
{
    public interface ICryptoRepository
    {
        List<Crypto> Get();

        void Add(Crypto crypto);
    }

    public class CryptoRepository : ICryptoRepository
    {
        private readonly QuotationContext DB;

        public CryptoRepository(QuotationContext db)
        {
            DB = db;
        }

        public List<Crypto> Get()
        {
            List<Crypto> cryptos = DB.Cryptos.ToList();
            return cryptos;
        }

        public void Add(Crypto crypto)
        {
            DB.Cryptos.Add(crypto);
            DB.SaveChanges();
        }
    }
}
