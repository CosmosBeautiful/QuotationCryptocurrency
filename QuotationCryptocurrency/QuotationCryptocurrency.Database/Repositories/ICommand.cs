using QuotationCryptocurrency.Database.Models;

namespace QuotationCryptocurrency.Database.Repositories
{
    public interface ICommand<T> where T : IData
    {
        T Create(T data);

        void Update(T data);

        void Delete(int id);
    }
}
