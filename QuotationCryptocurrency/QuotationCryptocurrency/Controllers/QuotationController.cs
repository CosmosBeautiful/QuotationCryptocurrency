using Microsoft.AspNetCore.Mvc;
using QuotationCryptocurrency.FilterModels.Quotation;
using QuotationCryptocurrency.Models;
using QuotationCryptocurrency.Parsers;
using QuotationCryptocurrency.Quotations;
using QuotationCryptocurrency.Repository;
using System.Collections.Generic;
using System.Diagnostics;

namespace QuotationCryptocurrency.Controllers
{
    public class QuotationController : Controller
    {
        private readonly IQuotationRepository _quotationRepository;

        private readonly IParser<QuotationModel, QuotationView> _parser;

        public QuotationController(IQuotationRepository quotationRepository, IParser<QuotationModel, QuotationView> parser)
        {
            _quotationRepository = quotationRepository;
            _parser = parser;
        }

        public IActionResult Index(int pageData = 1, QuotationSortType sortOrder = QuotationSortType.None, string selectedName = "")
        {
            List<QuotationView> quotationsView = _quotationRepository.Get();

            QuotationViewModel quotationsViewModel = new QuotationViewModel(pageData, sortOrder, selectedName);

            IEnumerable<QuotationModel> quotationModels = _parser.Parse(quotationsView);
            quotationModels =  quotationsViewModel.GetSortedQuotationModel(quotationModels);

            TempData.Set("quotationsViewModel", quotationsViewModel);

            return View("Index", quotationModels);
        }

        public IActionResult Sort(QuotationSortType sortOrder = QuotationSortType.None)
        {
            List<QuotationView> quotationsView = _quotationRepository.Get();
            IEnumerable<QuotationModel> quotationModels = _parser.Parse(quotationsView);

            QuotationSortModel SortModel = new QuotationSortModel(sortOrder);

            var quotationsViewModel = TempData.Get<QuotationViewModel>("quotationsViewModel");

            quotationModels = quotationsViewModel.GetSortModel(quotationModels, SortModel);
            TempData.Set("quotationsViewModel", quotationsViewModel);

            return View("Index", quotationModels);
        }


        public IActionResult Filter(QuotationFilters quotationFilters)
        {
            List<QuotationView> quotationsView = _quotationRepository.Get();
            IEnumerable<QuotationModel> quotationModels = _parser.Parse(quotationsView);

            var quotationsViewModel = TempData.Get<QuotationViewModel>("quotationsViewModel");

            quotationModels = quotationsViewModel.GetFilterModel(quotationModels, quotationFilters);
            TempData.Set("quotationsViewModel", quotationsViewModel);

            return View("Index", quotationModels);
        }

        public IActionResult Page(int pageData = 1)
        {
            List<QuotationView> quotationsView = _quotationRepository.Get();
            IEnumerable<QuotationModel> quotationModels = _parser.Parse(quotationsView);

            var quotationsViewModel = TempData.Get<QuotationViewModel>("quotationsViewModel");

            quotationModels = quotationsViewModel.GetPage(quotationModels, pageData);
            TempData.Set("quotationsViewModel", quotationsViewModel);

            return View("Index", quotationModels);
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