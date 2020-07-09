using QuotationCryptocurrency.Database.Models.Pagination;
using System;

namespace QuotationCryptocurrency.Web.Models
{
    public class PaginationModel
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public int TotalCount { get; set; }

        public int TotalPages => (int) Math.Ceiling(TotalCount / (double) PageSize);

        public bool HasPreviousPage => PageNumber > 1;

        public bool HasNextPage => PageNumber < TotalPages;

        public PaginationModel(PaginationData paginationData, int totalCount)
        {
            this.PageNumber = (paginationData.PageNumber < totalCount)
                ? paginationData.PageNumber 
                : totalCount;

            this.PageSize = paginationData.PageSize;
            this.TotalCount = totalCount;
        }
    }
}
