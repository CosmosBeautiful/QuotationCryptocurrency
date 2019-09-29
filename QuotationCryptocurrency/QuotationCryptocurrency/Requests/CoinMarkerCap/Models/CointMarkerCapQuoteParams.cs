using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using QuotationCryptocurrency.Configurations;

namespace QuotationCryptocurrency.Requests.CoinMarkerCap
{
    public class CointMarkerCapQuoteParams
    {
        [JsonProperty("USD")]
        public CointMarkerCapCurrencyParams Currency { get; set; }
    }
}