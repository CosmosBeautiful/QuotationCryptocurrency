using QuotationCryptocurrency.Models;
using QuotationCryptocurrency.Parsers;
using QuotationCryptocurrency.Requests;
using QuotationCryptocurrency.Requests.CoinMarkerCap;
using System.Collections.Generic;
using System.Linq;

namespace QuotationCryptocurrency.Quotations
{
    public class Quotation : IQuotation
    {
        private readonly IRequest _request;
        private readonly IParser<QuotationModel, CoinMarkerCapDataParams> _parser;

        public Quotation(IRequest request, IParser<QuotationModel, CoinMarkerCapDataParams> parser)
        {
            _request = request;
            _parser = parser;
        }

        public IEnumerable<IModel> GetQuotation()
        {
            CoinMarkerCapParams response = (CoinMarkerCapParams)_request.Send();

            IEnumerable<IModel> list = _parser.Parse(response.Data.ToList());

            return list;
        }
    }
}