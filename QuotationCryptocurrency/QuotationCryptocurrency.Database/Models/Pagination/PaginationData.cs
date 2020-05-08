namespace QuotationCryptocurrency.Database.Models.Pagination
{
    public class PaginationData
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; } = 15;

        public bool IsValid => PageSize > 0 && PageNumber > 0;

        public PaginationData(int pageNumber)
        {
            this.PageNumber = (pageNumber > 0) ? pageNumber : 1;
        }
    }
}
