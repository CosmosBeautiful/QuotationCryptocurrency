using System;
using Newtonsoft.Json;

namespace QuotationCryptocurrency.Request.Parameters.CoinMarkerCap
{
    public class CointMarkerCapCurrencyParam
    {
        [JsonProperty("price")]
        public double? Price { get; set; }

        [JsonProperty("volume_24h")]
        public double? Volume24h { get; set; }

        [JsonProperty("percent_change_1h")]
        public double? PercentChange1h { get; set; }

        [JsonProperty("percent_change_24h")]
        public double? PercentChange24h { get; set; }

        [JsonProperty("percent_change_7d")]
        public double? PercentChange7d { get; set; }

        [JsonProperty("market_cap")]
        public double? MarketCap { get; set; }

        [JsonProperty("last_updated")]
        public DateTime LastUpdated { get; set; }
    }
}
