using Newtonsoft.Json;

namespace QuotationCryptocurrency.Request.CoinMarkerCap
{
    public class CointMarkerCapQuoteParams
    {
        [JsonProperty("USD")]
        public CointMarkerCapCurrencyParams USD { get; set; }
    }
}