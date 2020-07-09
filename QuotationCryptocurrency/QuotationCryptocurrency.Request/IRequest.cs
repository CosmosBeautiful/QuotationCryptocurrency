using System.Collections.Generic;
using QuotationCryptocurrency.Request.Parameters;

namespace QuotationCryptocurrency.Request
{
    public interface IRequest<TResult> where TResult : IParam
    {
        List<TResult> SendAndGetResult();
    }
}
