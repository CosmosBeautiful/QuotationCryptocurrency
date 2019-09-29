using Microsoft.AspNetCore.Mvc;
using QuotationCryptocurrency.FilterModels.CryptocurrencyQuotation;
using QuotationCryptocurrency.Models;
using QuotationCryptocurrency.Quotations;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace QuotationCryptocurrency.Controllers
{
    public class QuotationController : Controller
    {
        private readonly IQuotation _quotation;
        public QuotationController(IQuotation quotation)
        {
            _quotation = quotation;
        }

        public IActionResult Index(int pageData = 1, CryptocurrencyQuotationSortType sortOrder = CryptocurrencyQuotationSortType.None)
        {
            List<IModel> quotations = _quotation.GetQuotation();
            var viewModel = new CryptocurrencyQuotationViewModel(quotations, pageData, sortOrder);

            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}