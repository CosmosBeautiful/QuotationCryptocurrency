using Microsoft.AspNetCore.Mvc;
using QuotationCryptocurrency.FilterModels.Quotation;
using QuotationCryptocurrency.Models;
using QuotationCryptocurrency.Repository;
using System.Collections.Generic;
using System.Diagnostics;

namespace QuotationCryptocurrency.Controllers
{
    public class QuotationController : Controller
    {
        private readonly IQuotationRepository _quotationRepository;

        public QuotationController(IQuotationRepository quotationRepository)
        {
            _quotationRepository = quotationRepository;
        }

        public IActionResult Index(int pageData = 1, QuotationSortType sortOrder = QuotationSortType.None, string selectedName = "")
        {
            List<QuotationView> quotationsView = _quotationRepository.Get();

            QuotationViewModel viewModel = _quotationRepository.CreateViewModel(quotationsView, pageData, sortOrder, selectedName);

            return View("Index", viewModel);
        }

        public IActionResult Load()
        {
            _quotationRepository.UpdateQuotes();

            return RedirectPermanent("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}