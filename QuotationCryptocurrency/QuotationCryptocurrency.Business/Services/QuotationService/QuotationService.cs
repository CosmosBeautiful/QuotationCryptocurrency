using AutoMapper;
using QuotationCryptocurrency.Business.DTO;
using QuotationCryptocurrency.Database.Models;
using QuotationCryptocurrency.Database.Repositories;
using QuotationCryptocurrency.Request;
using QuotationCryptocurrency.Request.Parameters;
using System.Collections.Generic;

namespace QuotationCryptocurrency.Business.Services
{
    public class QuotationService : IQuotationService
    {
        private IQuotationRepository _quotationRepository;
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
            _quotationRepository = quotationRepository;
            _cryptoRepository = cryptoRepository;
            _quoteRepository = quoteRepository;
            _request = request;
            _mapper = mapper;
        }

        public List<QuotationDTO> Get()
        {
            List<Quotation> quotations = _quotationRepository.Get();
            List<QuotationDTO> quotationsDTO = _mapper.Map<List<QuotationDTO>>(quotations);

            return quotationsDTO;
        }

        private bool IsСryptNotExist(List<CryptoDTO> cryptos, QuotationDTO item)
        {
            return (cryptos.Find(x => x.Id == item.Id) == null);
        }

        private void CreateCrypto(QuotationDTO quotation)
        {
            CryptoDTO cryptoDTO = new CryptoDTO(quotation);
            Crypto crypto = _mapper.Map<Crypto>(cryptoDTO);

            _cryptoRepository.Add(crypto);
        }

        public void Update()
        {
            List<CoinMarkerCapParam> coinMarkerCapParams = _request.Send();
            List<QuotationDTO> updateQuotationsDTO = _mapper.Map<List<QuotationDTO>>(coinMarkerCapParams);

            List<Crypto> cryptos = _cryptoRepository.Get();
            List<CryptoDTO> cryptosDTO = _mapper.Map<List<CryptoDTO>>(cryptos);


            List<QuoteDTO> newQuotesDTO = new List<QuoteDTO>();
            foreach (QuotationDTO item in updateQuotationsDTO)
            {
                if (IsСryptNotExist(cryptosDTO, item))
                {
                    CreateCrypto(item);
                }

                QuoteDTO newQuoteDTO = new QuoteDTO(item);
                newQuotesDTO.Add(newQuoteDTO);
            }

            List<Quote> newQuotes = _mapper.Map<List<Quote>>(newQuotesDTO);
            _quoteRepository.AddRange(newQuotes);
        }
    }
}
