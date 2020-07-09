using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using QuotationCryptocurrency.Request.Configurations;
using QuotationCryptocurrency.Request.Parameters.CoinMarkerCap;

namespace QuotationCryptocurrency.Request.Requests
{
    public class CoinMarkerCapRequest : HttpRequestBase<CoinMarkerCapParam>
    {
        private CoinMarkerCapConfig CoinMarkerCapConfig { get; }

        public CoinMarkerCapRequest(IOptions<CoinMarkerCapConfig> CoinMarkerCapOptions)
        {
            CoinMarkerCapConfig = CoinMarkerCapOptions.Value;
        }

        private string GetQueryParameters()
        {
            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["start"] = CoinMarkerCapConfig.StartElem.ToString();
            queryString["limit"] = CoinMarkerCapConfig.LimitElem.ToString();
            queryString["convert"] = CoinMarkerCapConfig.Currency;

            return queryString.ToString();
        }

        protected override string GetUrl()
        {
            var queryParameters = GetQueryParameters();
            var url = $"{CoinMarkerCapConfig.ApiUrl}?{queryParameters}";

            return url;
        }

        protected override HttpClient GetHttpClient()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-CMC_PRO_API_KEY", CoinMarkerCapConfig.ApiKey);

            return client;
        }

        protected override List<CoinMarkerCapParam> ParserResponse(string responseBody)
        {
            var responseObject = JsonConvert.DeserializeObject<CoinMarkerCapResponseParam>(responseBody);
            List<CoinMarkerCapParam> models = responseObject.Data.ToList();
            return models;
        }
    }
}