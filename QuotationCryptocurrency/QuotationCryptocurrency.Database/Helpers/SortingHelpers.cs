using QuotationCryptocurrency.Database.Models;
using QuotationCryptocurrency.Database.Models.Sort;
using System.Linq;

namespace QuotationCryptocurrency.Database.Helpers
{
    public static class SortingHelpers
    {
        public static IQueryable<QuotationDataView> OrderBySortType(this IQueryable<QuotationDataView> quotations, QuotationSortType sortOrder)
        {
            IQueryable<QuotationDataView> sortQuotations;
            switch (sortOrder)
            {
                case QuotationSortType.IdAsc:
                    sortQuotations = quotations.OrderBy(s => s.Id);
                    break;
                case QuotationSortType.IdDesc:
                    sortQuotations = quotations.OrderByDescending(s => s.Id);
                    break;
                case QuotationSortType.NameAsc:
                    sortQuotations = quotations.OrderBy(s => s.Name);
                    break;
                case QuotationSortType.NameDesc:
                    sortQuotations = quotations.OrderByDescending(s => s.Name);
                    break;
                case QuotationSortType.SymbolAsc:
                    sortQuotations = quotations.OrderBy(s => s.Symbol);
                    break;
                case QuotationSortType.SymbolDesc:
                    sortQuotations = quotations.OrderByDescending(s => s.Symbol);
                    break;
                case QuotationSortType.PriceAsc:
                    sortQuotations = quotations.OrderBy(s => s.Price);
                    break;
                case QuotationSortType.PriceDesc:
                    sortQuotations = quotations.OrderByDescending(s => s.Price);
                    break;
                case QuotationSortType.PercentChange1HAsc:
                    sortQuotations = quotations.OrderBy(s => s.PercentChange1h);
                    break;
                case QuotationSortType.PercentChange1HDesc:
                    sortQuotations = quotations.OrderByDescending(s => s.PercentChange1h);
                    break;
                case QuotationSortType.PercentChange24HAsc:
                    sortQuotations = quotations.OrderBy(s => s.PercentChange24h);
                    break;
                case QuotationSortType.PercentChange24HDesc:
                    sortQuotations = quotations.OrderByDescending(s => s.PercentChange24h);
                    break;
                case QuotationSortType.MarketCapAsc:
                    sortQuotations = quotations.OrderBy(s => s.MarketCap);
                    break;
                case QuotationSortType.MarketCapDesc:
                    sortQuotations = quotations.OrderByDescending(s => s.MarketCap);
                    break;
                case QuotationSortType.LastUpdatedAsc:
                    sortQuotations = quotations.OrderBy(s => s.LastUpdated);
                    break;
                case QuotationSortType.LastUpdatedDesc:
                    sortQuotations = quotations.OrderByDescending(s => s.LastUpdated);
                    break;
                case QuotationSortType.None:
                    sortQuotations = quotations;
                    break;
                default:
                    sortQuotations = quotations;
                    break;
            }

            return sortQuotations;
        }
    }
}
