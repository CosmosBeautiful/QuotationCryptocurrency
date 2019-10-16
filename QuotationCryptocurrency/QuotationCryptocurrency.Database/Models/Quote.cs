using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuotationCryptocurrency.Database.Models
{
    [Table("quotes")]
    public class Quote
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("crypto_id")]
        public int CryptoId { get; set; }

        [Column("price")]
        public double Price { get; set; }

        [Column("percent_change_1h")]
        public double? PercentChange1h { get; set; }

        [Column("percent_change_24h")]
        public double? PercentChange24h { get; set; }

        [Column("market_cap")]
        public double? MarketCap { get; set; }

        [Column("date_updated")]
        public DateTime LastUpdated { get; set; }

        public Quote()
        {
        }

        //public Quote(QuotationModel quotation)
        //{
        //    CryptoId = quotation.Id;
        //    Price = quotation.Price;
        //    PercentChange1h = quotation.PercentChange1h;
        //    PercentChange24h = quotation.PercentChange24h;
        //    MarketCap = quotation.MarketCap;
        //    LastUpdated = quotation.LastUpdated;
        //}
    }
}
