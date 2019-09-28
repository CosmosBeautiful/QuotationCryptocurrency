using QuotationCryptocurrency.Models;
using QuotationCryptocurrency.Parsers;
using QuotationCryptocurrency.Requests;
using System.Collections.Generic;

namespace QuotationCryptocurrency.Quotations
{
    public class CryptocurrencyQuotation : IQuotation
    {
        private readonly IRequest _request;
        private readonly IParser _parser;

        public CryptocurrencyQuotation(IRequest request, IParser parser)
        {
            _request = request;
            _parser = parser;
        }

        public List<IModel> GetQuotation()
        {
            IModel response = _request.Send();

            List<IModel> list = _parser.ParsersyQuotationFromRequest(response);

            return list;
        }
    }
}