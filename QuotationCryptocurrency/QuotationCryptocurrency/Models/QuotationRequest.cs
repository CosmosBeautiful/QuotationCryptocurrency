using Microsoft.AspNetCore.Mvc;
using QuotationCryptocurrency.Database.Models.Filter;
using QuotationCryptocurrency.Database.Models.Sort;

namespace QuotationCryptocurrency.Models
{
    public class QuotationRequest
    {
        [FromQuery]
        public int PageNumber { get; set; }

        [FromQuery]
        public QuotationSortType SortOrder { get; set; }

        [FromBody]
        public QuotationFilterData FilterData { get; set; }
    }
}
