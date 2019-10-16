using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuotationCryptocurrency.Business.DTO;
using QuotationCryptocurrency.Business.Services;
using QuotationCryptocurrency.FilterModels.Quotation;
using QuotationCryptocurrency.Models;
using System.Collections.Generic;
using System.Diagnostics;

namespace QuotationCryptocurrency.Controllers
{
    [Authorize]
    public class QuotationController : Controller
    {
        private readonly IQuotationService _quotationService;

        private readonly IMapper _mapper;

        public QuotationController(IQuotationService quotationService, IMapper mapper)
        {
            _quotationService = quotationService;
            _mapper = mapper;
        } 

        public IActionResult Index(int pageData = 1, QuotationSortType sortOrder = QuotationSortType.None, string selectedName = "")
        {

            List<QuotationDTO> quotationsDTO = _quotationService.Get();
            List<QuotationModel> quotations = _mapper.Map<List<QuotationModel>>(quotationsDTO);


            QuotationViewModel quotationsViewModel = new QuotationViewModel(pageData, sortOrder, selectedName);
            IEnumerable<QuotationModel> quotationsSorted =  quotationsViewModel.GetSortedQuotationModel(quotations);

            TempData.Set("quotationsViewModel", quotationsViewModel);
            return View("Index", quotationsSorted);
        }

        public IActionResult Sort(QuotationSortType sortOrder = QuotationSortType.None)
        {
            List<QuotationDTO> quotationsDTO = _quotationService.Get();
            List<QuotationModel> quotations = _mapper.Map<List<QuotationModel>>(quotationsDTO);

            QuotationViewModel quotationsViewModel = TempData.Get<QuotationViewModel>("quotationsViewModel");

            QuotationSortModel SortModel = new QuotationSortModel(sortOrder);
            IEnumerable<QuotationModel> quotationModels = quotationsViewModel.GetSortModel(quotations, SortModel);

            TempData.Set("quotationsViewModel", quotationsViewModel);
            return View("Index", quotationModels);
        }

        public IActionResult Filter(QuotationFilters quotationFilters = null)
        {

            List<QuotationDTO> quotationsDTO = _quotationService.Get();
            List<QuotationModel> quotations = _mapper.Map<List<QuotationModel>>(quotationsDTO);

            QuotationViewModel quotationsViewModel = TempData.Get<QuotationViewModel>("quotationsViewModel");

            IEnumerable<QuotationModel> quotationModels = quotationsViewModel.GetFilterModel(quotations, quotationFilters);

            TempData.Set("quotationsViewModel", quotationsViewModel);
            return View("Index", quotationModels);
        }

        public IActionResult Page(int pageData = 1)
        {
            List<QuotationDTO> quotationsDTO = _quotationService.Get();
            List<QuotationModel> quotations = _mapper.Map<List<QuotationModel>>(quotationsDTO);

            QuotationViewModel quotationsViewModel = TempData.Get<QuotationViewModel>("quotationsViewModel");

            IEnumerable<QuotationModel> quotationModels = quotationsViewModel.GetPage(quotations, pageData);

            TempData.Set("quotationsViewModel", quotationsViewModel);
            return View("Index", quotationModels);
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