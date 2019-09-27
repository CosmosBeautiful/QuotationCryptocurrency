using Newtonsoft.Json;
using QuotationCryptocurrency.Models;
using QuotationCryptocurrency.Request.CoinMarkerCap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace QuotationCryptocurrency.Request
{
    public class CoinMarkerCapHttpRequest : HttpRequestBase
    {
        private string GetParameters()
        {
            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["start"] = "1";
            queryString["limit"] = "5000";
            queryString["convert"] = "USD";

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