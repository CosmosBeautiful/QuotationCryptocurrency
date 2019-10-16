using System;

namespace QuotationCryptocurrency.Business.DTO
{
    public class QuoteDTO
    {
        public int Id { get; set; }
        public int CryptoId { get; set; }
        public double Price { get; set; }
        public double? PercentChange1h { get; set; }
        public double? PercentChange24h { get; set; }
        public double? MarketCap { get; set; }
        public DateTime LastUpdated { get; set; }

        public QuoteDTO()
        {
        }

        public QuoteDTO(QuotationDTO quotation)
        {
            CryptoId = quotation.Id;
            Price = quotation.Price;
            PercentChange1h = quotation.PercentChange1h;
            PercentChange24h = quotation.PercentChange24h;
            MarketCap = quotation.MarketCap;
            LastUpdated = quotation.LastUpdated;
        }
    }
}
