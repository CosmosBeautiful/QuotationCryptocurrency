namespace QuotationCryptocurrency.FilterModels.Quotation
{
    public class QuotationSortModel
    {
        public QuotationSortType IdSort { get; private set; }
        public QuotationSortType NameSort { get; private set; }
        public QuotationSortType SymbolSort { get; private set; }
        public QuotationSortType PriceSort { get; private set; }
        public QuotationSortType PercentChange1hSort { get; private set; }
        public QuotationSortType PercentChange24hSort { get; private set; }
        public QuotationSortType MarketCapSort { get; private set; }
        public QuotationSortType LastUpdatedSort { get; private set; }

        public QuotationSortModel(QuotationSortType sortOrder)
        {
            IdSort = sortOrder == QuotationSortType.IdAsc ? QuotationSortType.IdDesc : QuotationSortType.IdAsc;
            NameSort = sortOrder == QuotationSortType.NameAsc ? QuotationSortType.NameDesc : QuotationSortType.NameAsc;
            SymbolSort = sortOrder == QuotationSortType.SymbolAsc ? QuotationSortType.SymbolDesc : QuotationSortType.SymbolAsc;
            PriceSort = sortOrder == QuotationSortType.PriceAsc ? QuotationSortType.PriceDesc : QuotationSortType.PriceAsc;
            PercentChange1hSort = sortOrder == QuotationSortType.PercentChange1hAsc ? QuotationSortType.PercentChange1hDesc : QuotationSortType.PercentChange1hAsc;
            PercentChange24hSort = sortOrder == QuotationSortType.PercentChange24hAsc ? QuotationSortType.PercentChange24hDesc : QuotationSortType.PercentChange24hAsc;
            MarketCapSort = sortOrder == QuotationSortType.MarketCapAsc ? QuotationSortType.MarketCapDesc : QuotationSortType.MarketCapAsc;
            LastUpdatedSort = sortOrder == QuotationSortType.LastUpdatedAsc ? QuotationSortType.LastUpdatedDesc : QuotationSortType.LastUpdatedAsc;
        }
    }
}
