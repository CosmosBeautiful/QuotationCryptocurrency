using AutoMapper;
using QuotationCryptocurrency.Models;
using QuotationCryptocurrency.Quotations;
using QuotationCryptocurrency.Requests.CoinMarkerCap;
using System.Collections.Generic;

namespace QuotationCryptocurrency.Parsers
{
    public class CoinMarkerCapParser : IParser
    {
        private readonly IMapper _mapper;

        public CoinMarkerCapParser(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<IModel> ParsersyQuotationFromRequest(IModel response)
        {
            CoinMarkerCapParams parapms = (CoinMarkerCapParams)response;

            List<IModel> list = new List<IModel>();

            foreach (var item in parapms.Data)
            {
                list.Add(_mapper.Map<QuotationModel>(item));
            }

            return list;
        }
    }
}
