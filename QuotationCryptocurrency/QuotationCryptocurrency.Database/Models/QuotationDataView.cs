using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuotationCryptocurrency.Database.Models
{
    [Table("quotation_view")]
    public class QuotationDataView : IData
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("crypto_id")]
        public int CryptoId { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("symbol")]
        public string Symbol { get; set; }

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
    }
}
