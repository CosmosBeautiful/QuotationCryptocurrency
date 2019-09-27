using Newtonsoft.Json;
using QuotationCryptocurrency.Models;

namespace QuotationCryptocurrency.Request.CoinMarkerCap
{
    public class CoinMarkerCapParams: IModel
    {
        //[JsonProperty("status")]
        //public int Status { get; set; }

        [JsonProperty("data")]
        public CoinMarkerCapDataParams[] Data { get; set; }
    }
}