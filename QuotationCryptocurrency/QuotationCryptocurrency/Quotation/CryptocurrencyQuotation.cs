using QuotationCryptocurrency.Models;
using QuotationCryptocurrency.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace QuotationCryptocurrency.Quotation
{
    public class CryptocurrencyQuotation : IQuotation
    {
        private readonly IRequest Request;

        public CryptocurrencyQuotation(IRequest request)
        {
            this.Request = request;
        }

        public string Get()
        {
            IModel response = Request.Send();

            return "";
        }
    }
}