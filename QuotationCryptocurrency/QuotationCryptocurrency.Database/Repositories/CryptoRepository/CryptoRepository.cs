using QuotationCryptocurrency.Database.Models;
using System.Collections.Generic;
using System.Linq;

namespace QuotationCryptocurrency.Database.Repositories
{
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
