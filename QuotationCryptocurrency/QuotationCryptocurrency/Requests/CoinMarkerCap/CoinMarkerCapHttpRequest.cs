using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using QuotationCryptocurrency.Configurations;
using QuotationCryptocurrency.Models;
using QuotationCryptocurrency.Requests.CoinMarkerCap;
using System.Net.Http;
using System.Web;

namespace QuotationCryptocurrency.Requests
{
    public class CoinMarkerCapHttpRequest : HttpRequestBase
    {
        private CoinMarkerCapConfig CoinMarkerCapConfig { get; set; }

        public CoinMarkerCapHttpRequest(IOptions<CoinMarkerCapConfig> CoinMarkerCapOptions)
        {
            CoinMarkerCapConfig = CoinMarkerCapOptions.Value;
        }

        private string GetParameters()
        {
            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["start"] = CoinMarkerCapConfig.StartElem.ToString();
            queryString["limit"] = CoinMarkerCapConfig.LimitElem.ToString();
            queryString["convert"] = CoinMarkerCapConfig.Currency;

            return queryString.ToString();
        }

        protected override string GetСustomizedUrl()
        {
            var parameters = GetParameters();
            var url = $"{CoinMarkerCapConfig.ApiUrl}?{parameters}";

            return url;
        }

        protected override HttpClient GetСustomizedHttpClient()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-CMC_PRO_API_KEY", CoinMarkerCapConfig.ApiKey);

            return client;
        }

        protected override IModel ConvertModel(string responseBody)
        {
            IModel quotation = JsonConvert.DeserializeObject<CoinMarkerCapParams>(responseBody);
            return quotation;
        }
    }
}