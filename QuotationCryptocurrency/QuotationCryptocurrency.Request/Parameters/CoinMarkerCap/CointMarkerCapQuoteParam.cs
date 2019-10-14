using Newtonsoft.Json;
using System;

namespace QuotationCryptocurrency.Request.Parameters
{
    public class CointMarkerCapQuoteParam
    {
        [JsonProperty("USD")]
        public CointMarkerCapCurrencyParam Currency { get; set; }
    }
}
