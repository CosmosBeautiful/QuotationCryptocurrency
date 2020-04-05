using AutoMapper;
using QuotationCryptocurrency.Database.Models;
using QuotationCryptocurrency.Database.Repositories;
using QuotationCryptocurrency.Models;
using QuotationCryptocurrency.Request;
using QuotationCryptocurrency.Request.Parameters;
using System.Collections.Generic;

namespace QuotationCryptocurrency.Services
{
    public interface IQuotationService
    {
        void Update();
    }

    public class QuotationService : IQuotationService
    {
        private ICryptoRepository _cryptoRepository;
        private IQuoteRepository _quoteRepository;

        private IRequest<CoinMarkerCapParam> _request;

        private IMapper _mapper;

        public QuotationService(
            IQuotationRepository quotationRepository,
            ICryptoRepository cryptoRepository,
            IQuoteRepository quoteRepository,
            IRequest<CoinMarkerCapParam> request,
            IMapper mapper
            )
        {
            _cryptoRepository = cryptoRepository;
            _quoteRepository = quoteRepository;
            _request = request;
            _mapper = mapper;
        }

        public void Update()
        {
            var coinMarkerCapParams = _request.Send();
            var updateQuotationsDTO = _mapper.Map<List<QuotationModel>>(coinMarkerCapParams);

            var crypts = _cryptoRepository.Get();
            var cryptsModels = _mapper.Map<List<CryptoModel>>(crypts);

            var newQuotesDTO = new List<QuoteModel>();
            foreach (QuotationModel item in updateQuotationsDTO)
            {
                if (IsCryptNotExist(cryptsModels, item))
                {
                    CreateCrypto(item);
                }

                QuoteModel newQuoteDTO = new QuoteModel(item);
                newQuotesDTO.Add(newQuoteDTO);
            }

            List<Quote> newQuotes = _mapper.Map<List<Quote>>(newQuotesDTO);
            _quoteRepository.AddRange(newQuotes);
        }

        private static bool IsCryptNotExist(List<CryptoModel> crypts, QuotationModel item)
        {
            return (crypts.Find(x => x.Id == item.Id) == null);
        }

        private void CreateCrypto(QuotationModel quotation)
        {
            CryptoModel cryptoDTO = new CryptoModel(quotation);
            Crypto crypto = _mapper.Map<Crypto>(cryptoDTO);

            _cryptoRepository.Add(crypto);
        }
    }
}
