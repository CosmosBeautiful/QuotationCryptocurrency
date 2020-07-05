using QuotationCryptocurrency.Database.Models;
using System.Linq;
using QuotationCryptocurrency.Database.Models.Pagination;

namespace QuotationCryptocurrency.Database.Helpers
{
    public static class PaginationHelpers
    {
        public static IQueryable<QuotationDataView> Pagination(this IQueryable<QuotationDataView> quotations, PaginationData paginationData)
        {
            if (paginationData.IsValid == false)
            {
                return quotations;
            }

            int pageNumberBySql = (paginationData.PageNumber - 1);

            IQueryable<QuotationDataView> paginationQuotations = quotations.Skip(pageNumberBySql * paginationData.PageSize)
                .Take(paginationData.PageSize);

            return paginationQuotations;
        }
    }
}
