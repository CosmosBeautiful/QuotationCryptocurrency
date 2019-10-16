﻿using QuotationCryptocurrency.Database.Models;
using System.Collections.Generic;
using System.Linq;

namespace QuotationCryptocurrency.Database.Repositories
{
    public class QuotationRepository : IQuotationRepository
    {
        private readonly QuotationContext _db;

        public QuotationRepository(QuotationContext db)
        {
            _db = db;
        }

        public List<QuotationView> Get()
        {
            List<QuotationView> quotations = _db.QuotationsView.ToList();
            return quotations;
        }
    }
}
