using QuotationCryptocurrency.Models;
using System.Collections.Generic;

namespace QuotationCryptocurrency.Parsers
{
    public interface IParser
    {
        List<IModel> Parse(IModel models);
    }
}
