using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuotationCryptocurrency.Database.Repositories;
using QuotationCryptocurrency.FilterModels.Quotation;
using QuotationCryptocurrency.Models;
using System.Collections.Generic;
using System.Diagnostics;
using QuotationCryptocurrency.Services;

namespace QuotationCryptocurrency.Controllers
{
    [Authorize]
    public class QuotationController : Controller
    {
        private readonly IQuotationService _quotationService;
        private readonly IQuotationRepository _quotationRepository;

        private readonly IMapper _mapper;

        public QuotationController(IQuotationService quotationService, IMapper mapper, IQuotationRepository quotationRepository)
        {
            _quotationService = quotationService;
            _quotationRepository = quotationRepository;
            _mapper = mapper;
        } 

        public IActionResult Index(int pageData = 1, QuotationSortType sortOrder = QuotationSortType.None, string selectedName = "")
        {
            var quotations = _quotationRepository.Get();
            var models = _mapper.Map<List<QuotationModel>>(quotations);

            var quotationsViewModel = new QuotationViewModel(pageData, sortOrder, selectedName);
            var quotationsSorted =  quotationsViewModel.GetSortedQuotationModel(models);

            TempData.Set("quotationsViewModel", quotationsViewModel);
            return View("Index", quotationsSorted);
        }

        public IActionResult Sort(QuotationSortType sortOrder = QuotationSortType.None)
        {
            var quotations = _quotationRepository.Get();
            var quotationModels = _mapper.Map<List<QuotationModel>>(quotations);

            var quotationsViewModel = TempData.Get<QuotationViewModel>("quotationsViewModel");

            var sortModel = new QuotationSortModel(sortOrder);
            var models = quotationsViewModel.GetSortModel(quotationModels, sortModel);

            TempData.Set("quotationsViewModel", quotationsViewModel);
            return View("Index", models);
        }

        public IActionResult Filter(QuotationFilters quotationFilters = null)
        {
            var quotations = _quotationRepository.Get();
            var quotationModels = _mapper.Map<List<QuotationModel>>(quotations);

            var quotationsViewModel = TempData.Get<QuotationViewModel>("quotationsViewModel");

            var models = quotationsViewModel.GetFilterModel(quotationModels, quotationFilters);

            TempData.Set("quotationsViewModel", quotationsViewModel);
            return View("Index", models);
        }

        public IActionResult Page(int pageData = 1)
        {
            var quotations = _quotationRepository.Get();
            var quotationModels = _mapper.Map<List<QuotationModel>>(quotations);

            var quotationsViewModel = TempData.Get<QuotationViewModel>("quotationsViewModel");

            var models = quotationsViewModel.GetPage(quotationModels, pageData);

            TempData.Set("quotationsViewModel", quotationsViewModel);
            return View("Index", models);
        }

        public IActionResult Update()
        {
            _quotationService.Update();
            return RedirectPermanent("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}