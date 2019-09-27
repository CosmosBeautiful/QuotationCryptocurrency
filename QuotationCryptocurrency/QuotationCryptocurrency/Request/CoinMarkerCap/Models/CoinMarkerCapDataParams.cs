using Newtonsoft.Json;
using System;

namespace QuotationCryptocurrency.Request.CoinMarkerCap
{
    public class CoinMarkerCapDataParams
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("slub")]
        public int Slub { get; set; }

        [JsonProperty("num_marker_pairs")]
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
        public CointMarkerCapQuoteParams Quote { get; set; }
    }
}