using AutoMapper;
using QuotationCryptocurrency.FilterModels.Quotation;
using QuotationCryptocurrency.Models;
using QuotationCryptocurrency.Quotations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuotationCryptocurrency.Repository
{
    public class QuotationRepository : IQuotationRepository
    {
        private readonly QuotationContext db;

        private readonly IQuotation _quotation;

        private readonly IMapper _mapper;

        public QuotationRepository(QuotationContext context, IQuotation quotation, IMapper mapper)
        {
            db = context;
            _quotation = quotation;
            _mapper = mapper;
        }

        private bool IsСryptExist(List<QuotationView> quotationsView, QuotationModel item)
        {
            return (quotationsView.Find(x => x.Id == item.Id) == null);
        }

        private void AddCrypto(QuotationModel quotation)
        {
            Crypto crypto = new Crypto(quotation);
            db.Cryptos.Add(crypto);
            db.SaveChanges();
        }

        public List<QuotationView> Get()
        {
            List<QuotationView> quotations = db.QuotationsView.ToList();
            return quotations;
        }

        public void UpdateQuotes()
        {
            IEnumerable<QuotationModel> quotations = _quotation.GetQuotation().Cast<QuotationModel>();
            List<QuotationView> quotationsView = db.QuotationsView.ToList();

            foreach (QuotationModel item in quotations)
            {
                if (!IsСryptExist(quotationsView, item))
                {
                    AddCrypto(item);
                }

                Quote quote = new Quote(item);
                db.Quotes.Add(quote);
            }

            db.SaveChanges();
        }
    }
}