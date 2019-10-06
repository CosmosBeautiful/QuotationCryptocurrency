﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuotationCryptocurrency.FilterModels.Quotation;
using QuotationCryptocurrency.Models;
using QuotationCryptocurrency.Quotations;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;

namespace QuotationCryptocurrency.Controllers
{
    public class QuotationController : Controller
    {
        private readonly QuotationContext db;

        private readonly IQuotation _quotation;

        private readonly IMapper _mapper;

        public QuotationController(QuotationContext context, IQuotation quotation, IMapper mapper)
        {
            db = context;
            _quotation = quotation;
            _mapper = mapper;
        }

        public IActionResult Index(int pageData = 1, QuotationSortType sortOrder = QuotationSortType.None, string selectedName = "")
        {
            List<QuotationView> quotationsView = db.QuotationsView.ToList();

            List<QuotationModel> quotations = new List<QuotationModel>();
            foreach (var item in quotationsView)
            {
                quotations.Add(_mapper.Map<QuotationModel>(item));
            }

            var viewModel = new QuotationViewModel(quotations, pageData, sortOrder, selectedName);
            return View("Index", viewModel);
        }

        public IActionResult Load()
        {
            IEnumerable<QuotationModel> quotations = _quotation.GetQuotation().Cast<QuotationModel>();

            foreach (var item in quotations)
            {
                //(if) Find
                //try

                Quote quote = new Quote()
                {
                    CryptoId = item.Id,
                    Price = item.Price,
                    PercentChange1h = item.PercentChange1h,
                    PercentChange24h = item.PercentChange24h,
                    MarketCap = item.MarketCap,
                    LastUpdated = item.LastUpdated,
                };

                db.Quotes.Add(quote);
            }

            db.SaveChanges();

            return RedirectPermanent("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}