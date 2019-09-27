using QuotationCryptocurrency.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuotationCryptocurrency.Request
{
    public interface IRequest
    {
        IModel Send();
    }
}