using AutoMapper;
using QuotationCryptocurrency.FilterModels.Quotation;
using QuotationCryptocurrency.Models;
using QuotationCryptocurrency.Parsers;
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
        private readonly IParser<QuotationModel, QuotationView> _parser;

        public QuotationRepository(QuotationContext context, IQuotation quotation, IParser<QuotationModel, QuotationView> parser)
        {
            db = context;
            _quotation = quotation;
            _parser = parser;
        }

        private bool IsСryptNotExist(List<QuotationView> quotationsView, QuotationModel item)
        {
            return quotationsView.Find(x => x.Id == item.Id) == null;
        }

        private void AddCrypto(QuotationModel quotation)
        {
            Crypto crypto = new Crypto(quotation);
            db.Cryptos.Add(crypto);
            db.SaveChanges();
        }

        public List<QuotationModel> Get()
        {
            List<QuotationView> quotationsView = db.QuotationsView.ToList();
            List<QuotationModel> quotationModels = _parser.Parse(quotationsView);
            return quotationModels;
        }

        public void UpdateQuotes()
        {
            IEnumerable<QuotationModel> quotations = _quotation.GetQuotation().Cast<QuotationModel>();
            List<QuotationView> quotationsView = db.QuotationsView.ToList();

            foreach (QuotationModel item in quotations)
            {
                if (IsСryptNotExist(quotationsView, item))
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