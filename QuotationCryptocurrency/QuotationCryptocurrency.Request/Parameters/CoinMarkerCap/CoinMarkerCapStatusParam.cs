using System;
using Newtonsoft.Json;

namespace QuotationCryptocurrency.Request.Parameters.CoinMarkerCap
{
    public class CoinMarkerCapStatusParam
    {
        [JsonProperty("error_code")]
        public int ErrorCode { get; set; }

        [JsonProperty("error_message")]
        public string ErrorMessage { get; set; }

        [JsonProperty("elapsed")]
        public int Elapsed { get; set; }

        [JsonProperty("credit_count")]
        public int CreditCount { get; set; }

        [JsonProperty("notice")]
        public string Notice { get; set; }

        [JsonProperty("timestamp")]
        public DateTime Date { get; set; }
    }
}
