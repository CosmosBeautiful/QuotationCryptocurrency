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
        private readonly QuotationContext _db;

        public CryptoRepository(QuotationContext db)
        {
            _db = db;
        }

        public List<Crypto> Get()
        {
            List<Crypto> cryptos = _db.Cryptos.ToList();
            return cryptos;
        }

        public void Add(Crypto crypto)
        {
            _db.Cryptos.Add(crypto);
            _db.SaveChanges();
        }
    }
}
