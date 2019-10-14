using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using QuotationCryptocurrency.Request.Configurations;
using QuotationCryptocurrency.Request.Parameters;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace QuotationCryptocurrency.Request
{
    public class CoinMarkerCapRequest : HttpRequestBase<CoinMarkerCapParam>
    {
        private CoinMarkerCapConfig CoinMarkerCapConfig { get; set; }

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
            CoinMarkerCapResponseParam responseObject = JsonConvert.DeserializeObject<CoinMarkerCapResponseParam>(responseBody);
            List<CoinMarkerCapParam> models = responseObject.Data.ToList();
            return models;
        }
    }
}