using QuotationCryptocurrency.Database.Models;
using System.Linq;
using QuotationCryptocurrency.Database.Models.Pagination;

namespace QuotationCryptocurrency.Database.Helpers
{
    public static class PaginationHelpers
    {
        public static IQueryable<Quotation> Pagination(this IQueryable<Quotation> quotations, PaginationData paginationData)
        {
            if (paginationData.IsValid == false)
            {
                return quotations;
            }

            int pageNumberBySql = (paginationData.PageNumber - 1);

            IQueryable<Quotation> paginationQuotations = quotations.Skip(pageNumberBySql * paginationData.PageSize)
                .Take(paginationData.PageSize);

            return paginationQuotations;
        }
    }
}
