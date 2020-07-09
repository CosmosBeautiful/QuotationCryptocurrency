using System.Collections.Generic;
using System.Net.Http;
using QuotationCryptocurrency.Request.Parameters;

namespace QuotationCryptocurrency.Request
{
    public abstract class HttpRequestBase<TResult> : IRequest<TResult> where TResult : IParam
    {
        protected abstract HttpClient GetHttpClient();

        protected abstract string GetUrl();

        protected abstract List<TResult> ParserResponse(string responseBody);

        public virtual List<TResult> SendAndGetResult()
        {
            using (var client = GetHttpClient())
            {
                string url = GetUrl();
                var response = client.GetAsync(url).Result;
                var responseBody = response.Content.ReadAsStringAsync().Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException(responseBody);
                }

                List<TResult> models = ParserResponse(responseBody);
                return models;
            }
        }
    }
}
