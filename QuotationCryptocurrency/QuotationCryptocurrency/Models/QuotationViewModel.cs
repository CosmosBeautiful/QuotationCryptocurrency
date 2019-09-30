using QuotationCryptocurrency.FilterModels.Quotation;
using QuotationCryptocurrency.Quotations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuotationCryptocurrency.Models
{
    public class QuotationViewModel
    {
        public IEnumerable<QuotationModel> Quotations { get; set; }
        public PageNavigation PageNavigation { get; set; }
        public QuotationSortModel SortModel { get; set; }
        public QuotationFilters FilterModel { get; set; }

        public QuotationViewModel(IEnumerable<QuotationModel> quotations, int page, QuotationSortType sortType, string selectedName) 
        {
            Quotations = quotations;
            SortModel = new QuotationSortModel(sortType);
            FilterModel = new QuotationFilters(selectedName);
            PageNavigation = new PageNavigation(Quotations.Count(), page);

            Quotations = GetFilterQuotations(Quotations, selectedName);
            Quotations = GetSortQuotations(Quotations, sortType);
            Quotations = GetSelectedElementsQuotations(Quotations, page);
        }

        private IEnumerable<QuotationModel> GetSortQuotations(IEnumerable<QuotationModel> quotations, QuotationSortType sortType)
        {
            IEnumerable<QuotationModel> sortQuotations; 

            switch (sortType)
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
                case QuotationSortType.PercentChange1hAsc:
                    sortQuotations = quotations.OrderBy(s => s.PercentChange1h);
                    break;
                case QuotationSortType.PercentChange1hDesc:
                    sortQuotations = quotations.OrderByDescending(s => s.PercentChange1h);
                    break;
                case QuotationSortType.PercentChange24hAsc:
                    sortQuotations = quotations.OrderBy(s => s.PercentChange24h);
                    break;
                case QuotationSortType.PercentChange24hDesc:
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
                default:
                    sortQuotations = quotations;
                    break;
            }

            return sortQuotations;
        }

        private IEnumerable<QuotationModel> GetFilterQuotations(IEnumerable<QuotationModel> quotations, string selectedName)
        {
            IEnumerable<QuotationModel> filterQuotations = quotations;

            if (!String.IsNullOrEmpty(selectedName))
            {
                filterQuotations = quotations.Where(p => p.Name.Contains(selectedName));
            }

            return filterQuotations;
        }

        private IEnumerable<QuotationModel> GetSelectedElementsQuotations(IEnumerable<QuotationModel> quotations, int page)
        {
            IEnumerable<QuotationModel> selectedElementsQuotations = quotations.Skip((page - 1) * PageNavigation.PageSize).Take(PageNavigation.PageSize).ToList();
            return selectedElementsQuotations;
        }
    }
}
