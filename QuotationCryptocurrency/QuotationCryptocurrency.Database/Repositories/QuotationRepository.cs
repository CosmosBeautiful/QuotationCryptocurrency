using QuotationCryptocurrency.Database.Contexts;
using QuotationCryptocurrency.Database.Helpers;
using QuotationCryptocurrency.Database.Models;
using QuotationCryptocurrency.Database.Models.Filter;
using QuotationCryptocurrency.Database.Models.Pagination;
using QuotationCryptocurrency.Database.Models.Sort;
using System.Linq;

namespace QuotationCryptocurrency.Database.Repositories
{
    public interface IQuotationRepository : IQuery<QuotationDataView>
    {
        IQueryable<QuotationDataView> Get(QuotationSortType sortOrder, QuotationFilterData filterData, PaginationData paginationData);

        IQueryable<QuotationDataView> GetBySort(QuotationSortType sortOrder);

        IQueryable<QuotationDataView> GetByPagination(PaginationData paginationData);

        IQueryable<QuotationDataView> GetByFilter(QuotationFilterData filterData);

        int GetTotalCount(QuotationSortType sortOrder, QuotationFilterData filterData);
    }

    public class QuotationRepository : IQuotationRepository
    {
        private readonly QuotationContext DB;

        public QuotationRepository(QuotationContext db)
        {
            DB = db;
        }

        public IQueryable<QuotationDataView> Get()
        {
            IQueryable<QuotationDataView> quotations = DB.QuotationsView;
            return quotations;
        }

        public IQueryable<QuotationDataView> Get(QuotationSortType sortOrder, QuotationFilterData filterData, PaginationData paginationData)
        {
            IQueryable<QuotationDataView> quotations = this.Get()
                .OrderBySortType(sortOrder)
                .WhereByFilterData(filterData)
                .Pagination(paginationData);

            return quotations;
        }

        public IQueryable<QuotationDataView> GetBySort(QuotationSortType sortOrder)
        {
            var quotations = DB.QuotationsView.OrderBySortType(sortOrder);

            return quotations;
        }

        public IQueryable<QuotationDataView> GetByFilter(QuotationFilterData filterData)
        {
            var quotations = DB.QuotationsView.WhereByFilterData(filterData);

            return quotations;
        }

        public IQueryable<QuotationDataView> GetByPagination(PaginationData paginationData)
        {
            var quotations = DB.QuotationsView.Pagination(paginationData);
            
            return quotations;
        }

        public int GetTotalCount(QuotationSortType sortOrder, QuotationFilterData filterData)
        {
            int quotationsCount = DB.QuotationsView
                .OrderBySortType(sortOrder)
                .WhereByFilterData(filterData)
                .Count();

            return quotationsCount;
        }

        public QuotationDataView Find(int? id)
        {
            var quotation = this.Get()?.Where(x => x.Id == id)
                .FirstOrDefault();

            return quotation;
        }
    }
}
