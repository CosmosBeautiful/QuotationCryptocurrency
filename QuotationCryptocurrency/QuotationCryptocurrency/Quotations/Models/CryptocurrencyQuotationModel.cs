using QuotationCryptocurrency.Models;
using System;

namespace QuotationCryptocurrency.Quotations
{
    public class CryptocurrencyQuotationModel : IModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Symbol { get; set; }

        public double Price { get; set; }

        public double? PercentChange1h { get; set; }

        public double? PercentChange24h { get; set; }

        public double? MarketCap { get; set; }

        public DateTime LastUpdated { get; set; }

    }
}
