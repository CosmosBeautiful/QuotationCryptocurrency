using Newtonsoft.Json;

namespace QuotationCryptocurrency.Requests.CoinMarkerCap
{
    public class CointMarkerCapQuoteParams
    {
        [JsonProperty("USD")]
        public CointMarkerCapCurrencyParams Currency { get; set; }
    }
}