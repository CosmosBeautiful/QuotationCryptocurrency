using QuotationCryptocurrency.Database.Models;

namespace QuotationCryptocurrency.Database.Repositories
{
    public interface IRepository<T> : IQuery<T>, ICommand<T> where T : IData
    {
    }
}
