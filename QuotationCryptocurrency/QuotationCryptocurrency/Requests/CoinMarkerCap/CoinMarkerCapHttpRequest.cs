using Newtonsoft.Json;
using QuotationCryptocurrency.Models;
using QuotationCryptocurrency.Requests.CoinMarkerCap;
using System.Net.Http;
using System.Web;

namespace QuotationCryptocurrency.Requests
{
    public class CoinMarkerCapHttpRequest : HttpRequestBase
    {
        public const string StartElem = "1";
        public const string LimitElem = "5000";
        public const string Convert = "USD";

        private string GetParameters()
        {
            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["start"] = StartElem;
            queryString["limit"] = LimitElem;
            queryString["convert"] = Convert;

            return queryString.ToString();
        }

        protected override string GetСustomizedUrl()
        {
            var parameters = GetParameters();
            var url = $"https://pro-api.coinmarketcap.com/v1/cryptocurrency/listings/latest" + "?" + parameters;

            return url;
        }

        protected override HttpClient GetСustomizedHttpClient()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-CMC_PRO_API_KEY", "f34514dd-d398-4561-82c1-b9552c59d4ee");

            return client;
        }

        protected override IModel ConvertModel(string responseBody)
        {
            IModel quotation = JsonConvert.DeserializeObject<CoinMarkerCapParams>(responseBody);
            return quotation;
        }
    }
}