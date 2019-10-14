using Newtonsoft.Json;
using System;

namespace QuotationCryptocurrency.Request.Parameters
{
    public class CoinMarkerCapParam : IParam
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("num_market_pairs")]
        public int NumMarkerPairs { get; set; }

        [JsonProperty("date_added")]
        public DateTime DateAdded { get; set; }

        [JsonProperty("total_supply")]
        public Nullable<double> TotalSupply { get; set; }

        [JsonProperty("platform")]
        public object Platform { get; set; }

        [JsonProperty("cmc_rank")]
        public int CmcRank { get; set; }

        [JsonProperty("last_updated")]
        public DateTime LastUpdated { get; set; }

        [JsonProperty("quote")]
        public CointMarkerCapQuoteParam Quote { get; set; }
    }
}
