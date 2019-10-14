using QuotationCryptocurrency.Request.Parameters;
using System;
using System.Collections.Generic;

namespace QuotationCryptocurrency.Request
{
    public interface IRequest<TResult> where TResult : IParam
    {
        List<TResult> Send();
    }
}
