using AutoMapper;
using QuotationCryptocurrency.Models;
using QuotationCryptocurrency.Quotations;
using QuotationCryptocurrency.Requests.CoinMarkerCap;
using System.Collections.Generic;

namespace QuotationCryptocurrency.Parsers
{
    public class CoinMarkerCapParser : IParser<QuotationModel, CoinMarkerCapDataParams>
    {
        private readonly IMapper _mapper;

        public CoinMarkerCapParser(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<QuotationModel> Parse(List<CoinMarkerCapDataParams> responseData)
        {
            List<QuotationModel> list = new List<QuotationModel>();

            foreach (var item in responseData)
            {
                list.Add(_mapper.Map<QuotationModel>(item));
            }

            return list;
        }
    }
}
