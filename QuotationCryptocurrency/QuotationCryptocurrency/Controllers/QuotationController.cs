using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuotationCryptocurrency.FilterModels.Quotation;
using QuotationCryptocurrency.Models;
using QuotationCryptocurrency.Quotations;
using QuotationCryptocurrency.Repository;
using System.Collections.Generic;
using System.Diagnostics;

namespace QuotationCryptocurrency.Controllers
{
    [Authorize]
    public class QuotationController : Controller
    {
        private readonly IQuotationRepository _quotationRepository;


        public QuotationController(IQuotationRepository quotationRepository)
        {
            _quotationRepository = quotationRepository;
        }

        public IActionResult Index(int pageData = 1, QuotationSortType sortOrder = QuotationSortType.None, string selectedName = "")
        {
            List<QuotationModel> quotationsView = _quotationRepository.Get();

            QuotationViewModel quotationsViewModel = new QuotationViewModel(pageData, sortOrder, selectedName);
            IEnumerable<QuotationModel> quotationModels =  quotationsViewModel.GetSortedQuotationModel(quotationsView);

            TempData.Set("quotationsViewModel", quotationsViewModel);
            return View("Index", quotationModels);
        }

        public IActionResult Sort(QuotationSortType sortOrder = QuotationSortType.None)
        {
            List<QuotationModel> quotationsView = _quotationRepository.Get();
            QuotationViewModel quotationsViewModel = TempData.Get<QuotationViewModel>("quotationsViewModel");

            QuotationSortModel SortModel = new QuotationSortModel(sortOrder);
            IEnumerable<QuotationModel> quotationModels = quotationsViewModel.GetSortModel(quotationsView, SortModel);

            TempData.Set("quotationsViewModel", quotationsViewModel);
            return View("Index", quotationModels);
        }


        public IActionResult Filter(QuotationFilters quotationFilters = null)
        {
            List<QuotationModel> quotationsView = _quotationRepository.Get();
            QuotationViewModel quotationsViewModel = TempData.Get<QuotationViewModel>("quotationsViewModel");

            IEnumerable<QuotationModel> quotationModels = quotationsViewModel.GetFilterModel(quotationsView, quotationFilters);

            TempData.Set("quotationsViewModel", quotationsViewModel);
            return View("Index", quotationModels);
        }

        public IActionResult Page(int pageData = 1)
        {
            List<QuotationModel> quotationsView = _quotationRepository.Get();
            QuotationViewModel quotationsViewModel = TempData.Get<QuotationViewModel>("quotationsViewModel");

            IEnumerable<QuotationModel> quotationModels = quotationsViewModel.GetPage(quotationsView, pageData);

            TempData.Set("quotationsViewModel", quotationsViewModel);
            return View("Index", quotationModels);
        }

        public IActionResult Update()
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