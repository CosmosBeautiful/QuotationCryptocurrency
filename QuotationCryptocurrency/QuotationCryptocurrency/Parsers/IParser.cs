using QuotationCryptocurrency.Models;
using System.Collections.Generic;

namespace QuotationCryptocurrency.Parsers
{
    public interface IParser<TResult, TInput>  
        where TResult : IModel 
        where TInput : IModel
    {
        List<TResult> Parse(List<TInput> models);
    }
}
