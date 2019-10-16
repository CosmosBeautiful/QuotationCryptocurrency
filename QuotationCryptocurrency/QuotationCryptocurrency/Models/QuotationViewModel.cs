using QuotationCryptocurrency.FilterModels.Quotation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuotationCryptocurrency.Models
{
    public class QuotationViewModel
    {
        public PageNavigation PageNavigation { get; set; }
        public QuotationSortModel SortModel { get; set; }
        public QuotationFilters FilterModel { get; set; }

        public QuotationViewModel(int page, QuotationSortType sortType, string selectedName) 
        {
            SortModel = new QuotationSortModel(sortType);
            FilterModel = new QuotationFilters(selectedName);
            PageNavigation = new PageNavigation(page);

        }

        public IEnumerable<QuotationModel> GetSortedQuotationModel(IEnumerable<QuotationModel> quotations)
        {
            IEnumerable<QuotationModel> sortedQuotations = quotations;

            sortedQuotations = GetFilteredQuotations(sortedQuotations);
            sortedQuotations = GetSortedQuotations(sortedQuotations);
            sortedQuotations = GetSelectedElementsQuotations(sortedQuotations);

            return sortedQuotations;
        }

        private IEnumerable<QuotationModel> GetSortedQuotations(IEnumerable<QuotationModel> quotations)
        {
            IEnumerable<QuotationModel> sortQuotations; 

            switch (SortModel.SortOrder)
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

        private IEnumerable<QuotationModel> GetFilteredQuotations(IEnumerable<QuotationModel> quotations)
        {
            IEnumerable<QuotationModel> filterQuotations = quotations;

            if (!String.IsNullOrEmpty(FilterModel.SelectedName))
            {
                filterQuotations = filterQuotations.Where(p => p.Name.Contains(FilterModel.SelectedName));
            }
            if (!String.IsNullOrEmpty(FilterModel.SelectedSymbol))
            {
                filterQuotations = filterQuotations.Where(p => p.Symbol.Contains(FilterModel.SelectedSymbol));
            }

            return filterQuotations;
        }

        private IEnumerable<QuotationModel> GetSelectedElementsQuotations(IEnumerable<QuotationModel> quotations)
        {
            PageNavigation.SetCountElements(quotations.Count());
            IEnumerable<QuotationModel> selectedElementsQuotations = quotations.Skip((PageNavigation.PageNumber - 1) * PageNavigation.PageSize).Take(PageNavigation.PageSize).ToList();
            return selectedElementsQuotations;
        }

        public IEnumerable<QuotationModel> GetSortModel(IEnumerable<QuotationModel> quotations, QuotationSortModel sortModel)
        {
            SortModel = sortModel;
            return GetSortedQuotationModel(quotations);
        }

        public IEnumerable<QuotationModel> GetFilterModel(IEnumerable<QuotationModel> quotations, QuotationFilters filterModel)
        {
            FilterModel = filterModel;
            return GetSortedQuotationModel(quotations);
        }

        public IEnumerable<QuotationModel> GetPage(IEnumerable<QuotationModel> quotations, int page)
        {
            PageNavigation = new PageNavigation(page);
            return GetSortedQuotationModel(quotations);
        }
    }
}
