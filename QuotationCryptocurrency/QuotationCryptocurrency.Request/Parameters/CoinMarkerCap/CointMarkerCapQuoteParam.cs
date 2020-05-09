using Newtonsoft.Json;

namespace QuotationCryptocurrency.Request.Parameters.CoinMarkerCap
{
    public class CointMarkerCapQuoteParam
    {
        [JsonProperty("USD")]
        public CointMarkerCapCurrencyParam Currency { get; set; }
    }
}
