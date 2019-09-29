namespace QuotationCryptocurrency.FilterModels.CryptocurrencyQuotation
{
    public class CryptocurrencyQuotationSortModel
    {
        public CryptocurrencyQuotationSortType IdSort { get; private set; }
        public CryptocurrencyQuotationSortType NameSort { get; private set; }
        public CryptocurrencyQuotationSortType SymbolSort { get; private set; }
        public CryptocurrencyQuotationSortType PriceSort { get; private set; }
        public CryptocurrencyQuotationSortType PercentChange1hSort { get; private set; }
        public CryptocurrencyQuotationSortType PercentChange24hSort { get; private set; }
        public CryptocurrencyQuotationSortType MarketCapSort { get; private set; }
        public CryptocurrencyQuotationSortType LastUpdatedSort { get; private set; }

        public CryptocurrencyQuotationSortModel(CryptocurrencyQuotationSortType sortOrder)
        {
            IdSort = sortOrder == CryptocurrencyQuotationSortType.IdAsc ? CryptocurrencyQuotationSortType.IdDesc : CryptocurrencyQuotationSortType.IdAsc;
            NameSort = sortOrder == CryptocurrencyQuotationSortType.NameAsc ? CryptocurrencyQuotationSortType.NameDesc : CryptocurrencyQuotationSortType.NameAsc;
            SymbolSort = sortOrder == CryptocurrencyQuotationSortType.SymbolAsc ? CryptocurrencyQuotationSortType.SymbolDesc : CryptocurrencyQuotationSortType.SymbolAsc;
            PriceSort = sortOrder == CryptocurrencyQuotationSortType.PriceAsc ? CryptocurrencyQuotationSortType.PriceDesc : CryptocurrencyQuotationSortType.PriceAsc;
            PercentChange1hSort = sortOrder == CryptocurrencyQuotationSortType.PercentChange1hAsc ? CryptocurrencyQuotationSortType.PercentChange1hDesc : CryptocurrencyQuotationSortType.PercentChange1hAsc;
            PercentChange24hSort = sortOrder == CryptocurrencyQuotationSortType.PercentChange24hAsc ? CryptocurrencyQuotationSortType.PercentChange24hDesc : CryptocurrencyQuotationSortType.PercentChange24hAsc;
            MarketCapSort = sortOrder == CryptocurrencyQuotationSortType.MarketCapAsc ? CryptocurrencyQuotationSortType.MarketCapDesc : CryptocurrencyQuotationSortType.MarketCapAsc;
            LastUpdatedSort = sortOrder == CryptocurrencyQuotationSortType.LastUpdatedAsc ? CryptocurrencyQuotationSortType.LastUpdatedDesc : CryptocurrencyQuotationSortType.LastUpdatedAsc;
        }
    }
}
