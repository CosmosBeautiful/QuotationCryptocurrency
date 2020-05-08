using QuotationCryptocurrency.Database.Models.Filter;
using QuotationCryptocurrency.Database.Models.Sort;
using System.Collections.Generic;

namespace QuotationCryptocurrency.Models
{
    public class QuotationViewModel
    {
        public IList<QuotationModel> Quotations { get; set; }

        public QuotationSortType SortModel { get; set; }

        public QuotationFilterData FilterData { get; set; }

        public PaginationModel PaginationModel { get; set; }

        public QuotationViewModel(IList<QuotationModel> quotations, QuotationSortType sortModel, QuotationFilterData filterData, PaginationModel paginationModel)
        {
            this.Quotations = quotations;
            this.SortModel = sortModel;
            this.FilterData = filterData;
            this.PaginationModel = paginationModel;
        }
    }
}
