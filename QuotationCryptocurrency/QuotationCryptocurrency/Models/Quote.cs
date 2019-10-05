using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuotationCryptocurrency.Models
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


        //public int CryptoInfoKey { get; set; }

        //[ForeignKey("CryptoInfoKey")]
        //public Crypto Crypto { get; set; }
    }
}
