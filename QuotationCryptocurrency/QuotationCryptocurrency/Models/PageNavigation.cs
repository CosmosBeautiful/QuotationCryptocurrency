using Newtonsoft.Json;
using System;

namespace QuotationCryptocurrency.Models
{
    public class PageNavigation
    {
        [JsonProperty]
        public int PageNumber { get; private set; }

        [JsonProperty]
        public int TotalPages { get; private set; }

        [JsonProperty]
        public int PageSize { get; private set; }

        public bool HasPreviousPage
        {
            get
            {
                return (PageNumber > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (PageNumber < TotalPages);
            }
        }

        public PageNavigation(int pageNumber, int pageSize = 10)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public void SetCountElements(int count)
        {
            TotalPages = (int)Math.Ceiling(count / (double)PageSize);
            PageNumber = (PageNumber > TotalPages) ? TotalPages : PageNumber;
        }
    }
}
