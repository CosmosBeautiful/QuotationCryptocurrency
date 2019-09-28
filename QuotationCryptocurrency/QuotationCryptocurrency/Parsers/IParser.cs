using QuotationCryptocurrency.Models;
using System.Collections.Generic;

namespace QuotationCryptocurrency.Parsers
{
    public interface IParser
    {
        List<IModel> ParsersyQuotationFromRequest(IModel response);
    }
}
