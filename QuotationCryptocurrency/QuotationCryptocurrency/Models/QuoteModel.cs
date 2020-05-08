using System;

namespace QuotationCryptocurrency.Models
{
    public class QuoteModel
    {
        public int Id { get; set; }
        public int CryptoId { get; set; }
        public double Price { get; set; }
        public double? PercentChange1h { get; set; }
        public double? PercentChange24h { get; set; }
        public double? MarketCap { get; set; }
        public DateTime LastUpdated { get; set; }

        public QuoteModel()
        {
        }

        public QuoteModel(QuotationModel quotation)
        {
            CryptoId = quotation.Id;
            Price = quotation.Price;
            PercentChange1h = quotation.PercentChange1H;
            PercentChange24h = quotation.PercentChange24H;
            MarketCap = quotation.MarketCap;
            LastUpdated = quotation.LastUpdated;
        }
    }
}
