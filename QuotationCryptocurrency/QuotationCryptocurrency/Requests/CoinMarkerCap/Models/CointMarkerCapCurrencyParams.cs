using Newtonsoft.Json;
using System;

namespace QuotationCryptocurrency.Requests.CoinMarkerCap
{
    public class CointMarkerCapCurrencyParams
    {
        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("volume_24h")]
        public Nullable<double> Volume24h { get; set; }

        [JsonProperty("percent_change_1h")]
        public Nullable<double> PercentChange1h { get; set; }

        [JsonProperty("percent_change_24h")]
        public Nullable<double> PercentChange24h { get; set; }

        [JsonProperty("percent_change_7d")]
        public Nullable<double> PercentChange7d { get; set; }

        [JsonProperty("market_cap")]
        public Nullable<double> MarketCap { get; set; }

        [JsonProperty("last_updated")]
        public DateTime LastUpdated { get; set; }
    }
}