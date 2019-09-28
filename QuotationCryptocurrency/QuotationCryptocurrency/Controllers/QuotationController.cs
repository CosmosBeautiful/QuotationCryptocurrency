using Microsoft.AspNetCore.Mvc;
using QuotationCryptocurrency.Models;
using QuotationCryptocurrency.Quotations;
using System.Collections.Generic;
using System.Diagnostics;

namespace QuotationCryptocurrency.Controllers
{
    public class QuotationController : Controller
    {
        private readonly IQuotation _quotation;
        public QuotationController(IQuotation quotation)
        {
            _quotation = quotation;
        }

        public IActionResult Index()
        {
            List<IModel> list = _quotation.GetQuotation();

            return View(list);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}