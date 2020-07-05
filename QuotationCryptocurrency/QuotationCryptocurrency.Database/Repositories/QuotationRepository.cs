using QuotationCryptocurrency.Database.Contexts;
using QuotationCryptocurrency.Database.Helpers;
using QuotationCryptocurrency.Database.Models;
using QuotationCryptocurrency.Database.Models.Filter;
using QuotationCryptocurrency.Database.Models.Pagination;
using QuotationCryptocurrency.Database.Models.Sort;
using System.Linq;

namespace QuotationCryptocurrency.Database.Repositories
{
    public interface IQuotationRepository : IRepository
    {
        IQueryable<QuotationDataView> Get();

        IQueryable<QuotationDataView> Get(QuotationSortType sortOrder, QuotationFilterData filterData, PaginationData paginationData);

        int GetTotalCount(QuotationSortType sortOrder, QuotationFilterData filterData);
    }

    public class QuotationRepository : IQuotationRepository
    {
        private readonly IQuotationContext DB;

        public QuotationRepository(IQuotationContext db)
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
            IQueryable<QuotationDataView> quotations = DB.QuotationsView
                .OrderBySortType(sortOrder)
                .WhereByFilterData(filterData)
                .Pagination(paginationData);

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

        public IQueryable<QuotationDataView> GetBySort(QuotationSortType sortOrder)
        {
            var quotations = DB.QuotationsView
                    .OrderBySortType(sortOrder);

            return quotations;
        }

        public IQueryable<QuotationDataView> GetByFilter(QuotationFilterData filterData)
        {
            var quotations = DB.QuotationsView
                .WhereByFilterData(filterData);

            return quotations;
        }

        public IQueryable<QuotationDataView> GetByPagination(PaginationData paginationData)
        {
            var quotations = DB.QuotationsView.Pagination(paginationData);
            
            return quotations;
        }
    }
}
