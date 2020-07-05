using System.Collections.Generic;
using System.Linq;
using QuotationCryptocurrency.Database.Contexts;
using QuotationCryptocurrency.Database.Models;

namespace QuotationCryptocurrency.Database.Repositories
{
    public interface ICryptoRepository
    {
        List<CryptoData> Get();

        void Add(CryptoData cryptoData);
    }

    public class CryptoRepository : ICryptoRepository
    {
        private readonly QuotationContext DB;

        public CryptoRepository(QuotationContext db)
        {
            DB = db;
        }

        public List<CryptoData> Get()
        {
            List<CryptoData> cryptos = DB.Cryptos.ToList();
            return cryptos;
        }

        public void Add(CryptoData cryptoData)
        {
            DB.Cryptos.Add(cryptoData);
            DB.SaveChanges();
        }
    }
}
