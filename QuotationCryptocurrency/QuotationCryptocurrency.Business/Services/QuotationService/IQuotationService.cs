using QuotationCryptocurrency.Business.DTO;
using System.Collections.Generic;

namespace QuotationCryptocurrency.Business.Services
{
    public interface IQuotationService
    {
        List<QuotationDTO> Get();

        void Update();
    }
}
