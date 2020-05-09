using Newtonsoft.Json;

namespace QuotationCryptocurrency.Request.Parameters.CoinMarkerCap
{
    public class CoinMarkerCapResponseParam
    {
        [JsonProperty("status")]
        public CoinMarkerCapStatusParam Status { get; set; }

        [JsonProperty("data")]
        public CoinMarkerCapParam[] Data { get; set; }
    }
}
