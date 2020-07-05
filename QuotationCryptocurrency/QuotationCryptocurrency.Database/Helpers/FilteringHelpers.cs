using QuotationCryptocurrency.Database.Models;
using QuotationCryptocurrency.Database.Models.Filter;
using System.Linq;

namespace QuotationCryptocurrency.Database.Helpers
{
    public static class FilteringHelpers
    {
        public static IQueryable<QuotationDataView> WhereByFilterData(this IQueryable<QuotationDataView> quotations, QuotationFilterData filterData)
        {
            IQueryable<QuotationDataView> filterQuotations = quotations;

            if (filterData.IsFilterName)
            {
                filterQuotations = filterQuotations.Where(x => x.Name.Contains(filterData.Name));
            }

            if (filterData.IsFilterSymbol)
            {
                filterQuotations = filterQuotations.Where(x => x.Symbol.Contains(filterData.Symbol));
            }

            return filterQuotations ?? quotations;
        }
    }
}
