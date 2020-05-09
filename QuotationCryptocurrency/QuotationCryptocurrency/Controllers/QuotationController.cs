using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuotationCryptocurrency.Database.Models.Filter;
using QuotationCryptocurrency.Database.Models.Sort;
using QuotationCryptocurrency.Database.Repositories;
using QuotationCryptocurrency.Models;
using QuotationCryptocurrency.Services;
using System.Collections.Generic;
using System.Linq;
using QuotationCryptocurrency.Database.Models.Pagination;

namespace QuotationCryptocurrency.Controllers
{
    public class QuotationController : Controller
    {
        private readonly IMapper Mapper;

        private readonly IQuotationService QuotationService;

        private readonly IQuotationRepository QuotationRepository;

        public QuotationController(IQuotationService quotationService, IMapper mapper, IQuotationRepository quotationRepository)
        {
            QuotationService = quotationService;
            QuotationRepository = quotationRepository;
            Mapper = mapper;
        } 

        public IActionResult Index(int pageNumber = 1, QuotationSortType sortOrder = QuotationSortType.None, QuotationFilterData filterData = null)
        {
            var paginationData = new PaginationData(pageNumber);

            var quotations = QuotationRepository.Get(sortOrder, filterData, paginationData).ToList();
            var quotationModels = Mapper.Map<List<QuotationModel>>(quotations);

            var quotationCount = QuotationRepository.GetTotalCount(sortOrder, filterData);
            var paginationModel = new PaginationModel(paginationData, quotationCount);

            var model = new QuotationViewModel(quotationModels, sortOrder, filterData, paginationModel);

            return View("Index", model);
        }

        public IActionResult Update()
        {
            QuotationService.Update();
            return RedirectPermanent("Index");
        }
    }
}