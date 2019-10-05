using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuotationCryptocurrency.Models
{
    [Table("cryptos")]
    public class Crypto
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("symbol")]
        public string Symbol { get; set; }

        [ForeignKey("CryptoId")]
        public ICollection<Quote> Quotes { get; set; }

    }
}
