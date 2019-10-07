using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using QuotationCryptocurrency.Models;
using QuotationCryptocurrency.Quotations;

namespace QuotationCryptocurrency.Parsers
{
    public class QuotationRepositoryParser : IParser<QuotationModel, QuotationView>
    {
  
        private readonly IMapper _mapper;

        public QuotationRepositoryParser(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<QuotationModel> Parse(List<QuotationView> responseData)
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
