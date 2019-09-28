using QuotationCryptocurrency.Models;

namespace QuotationCryptocurrency.Requests
{
    public interface IRequest
    {
        IModel Send();
    }
}