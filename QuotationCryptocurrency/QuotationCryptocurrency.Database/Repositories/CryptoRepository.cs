using QuotationCryptocurrency.Database.Contexts;
using QuotationCryptocurrency.Database.Models;
using System.Linq;

namespace QuotationCryptocurrency.Database.Repositories
{
    public interface ICryptoRepository : IRepository<CryptoData>
    {
    }

    public class CryptoRepository : ICryptoRepository
    {
        private readonly QuotationContext DB;

        public CryptoRepository(QuotationContext db)
        {
            DB = db;
        }

        public IQueryable<CryptoData> Get()
        {
            var cryptos = DB.Cryptos;
            return cryptos;
        }

        public CryptoData Find(int? id)
        {
            var crypto = this.Get()?.Where(x => x.Id == id)
                .FirstOrDefault();
            return crypto;
        }

        public CryptoData Create(CryptoData crypto)
        {
            var newCrypto = DB.Cryptos.Add(crypto);
            DB.SaveChanges();

            return newCrypto.Entity;
        }

        public void Update(CryptoData crypto)
        {
            DB.Cryptos.Update(crypto);
            DB.SaveChanges();
        }

        public void Delete(int id)
        {
            DB.Cryptos.Remove(new CryptoData { Id = id });
            DB.SaveChanges();
        }
    }
}
