using QuotationCryptocurrency.Models;
using QuotationCryptocurrency.Parsers;
using QuotationCryptocurrency.Requests;
using System.Collections.Generic;

namespace QuotationCryptocurrency.Quotations
{
    public class Quotation : IQuotation
    {
        private readonly IRequest _request;
        private readonly IParser _parser;

        public Quotation(IRequest request, IParser parser)
        {
            _request = request;
            _parser = parser;
        }

        public IEnumerable<IModel> GetQuotation()
        {
            IModel response = _request.Send();

            IEnumerable<IModel> list = _parser.ParsersyQuotationFromRequest(response);

            return list;
        }
    }
}