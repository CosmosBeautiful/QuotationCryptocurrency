using System.Linq;
using QuotationCryptocurrency.Database.Models;

namespace QuotationCryptocurrency.Database.Repositories
{
    public interface IQuery<out T> where T : IData
    {
        IQueryable<T> Get();

        T Find(int? id);
    }
}
