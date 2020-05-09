using AutoMapper;
using QuotationCryptocurrency.Database.Models;
using QuotationCryptocurrency.Database.Repositories;
using QuotationCryptocurrency.Models;
using QuotationCryptocurrency.Request;
using QuotationCryptocurrency.Request.Parameters.CoinMarkerCap;
using System.Collections.Generic;

namespace QuotationCryptocurrency.Services
{
    public interface IQuotationService
    {
        void Update();
    }

    public class QuotationService : IQuotationService
    {
        private ICryptoRepository CryptoRepository;
        private IQuoteRepository QuoteRepository;

        private IRequest<CoinMarkerCapParam> Request;

        private IMapper Mapper;

        public QuotationService(
            IQuotationRepository quotationRepository,
            ICryptoRepository cryptoRepository,
            IQuoteRepository quoteRepository,
            IRequest<CoinMarkerCapParam> request,
            IMapper mapper
            )
        {
            CryptoRepository = cryptoRepository;
            QuoteRepository = quoteRepository;
            Request = request;
            Mapper = mapper;
        }

        public void Update()
        {
            var coinMarkerCapParams = Request.SendAndGetResult();
            var updateQuotations = Mapper.Map<List<QuotationModel>>(coinMarkerCapParams);

            var crypts = CryptoRepository.Get();
            var cryptsModels = Mapper.Map<List<CryptoModel>>(crypts);

            var newQuoteModels = new List<QuoteModel>();
            foreach (QuotationModel item in updateQuotations)
            {
                if (IsCryptNotExist(cryptsModels, item))
                {
                    CreateCrypto(item);
                }

                var newQuote = new QuoteModel(item);
                newQuoteModels.Add(newQuote);
            }

            List<Quote> newQuotes = Mapper.Map<List<Quote>>(newQuoteModels);
            QuoteRepository.AddRange(newQuotes);
        }

        private static bool IsCryptNotExist(List<CryptoModel> crypts, QuotationModel item)
        {
            return (crypts.Find(x => x.Id == item.Id) == null);
        }

        private void CreateCrypto(QuotationModel quotation)
        {
            CryptoModel cryptoDTO = new CryptoModel(quotation);
            Crypto crypto = Mapper.Map<Crypto>(cryptoDTO);

            CryptoRepository.Add(crypto);
        }
    }
}
