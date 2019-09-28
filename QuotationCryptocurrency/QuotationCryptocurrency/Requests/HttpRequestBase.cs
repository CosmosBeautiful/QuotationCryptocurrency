using QuotationCryptocurrency.Models;
using System.Net.Http;

namespace QuotationCryptocurrency.Requests
{
    public abstract class HttpRequestBase : IRequest
    {
        protected abstract HttpClient GetСustomizedHttpClient();
        protected abstract string GetСustomizedUrl();

        protected abstract IModel ConvertModel(string responseBody);

        public virtual IModel Send()
        {
            using (var client = GetСustomizedHttpClient())
            {
                string url = GetСustomizedUrl();
                var response = client.GetAsync(url).Result;
                var responseBody = response.Content.ReadAsStringAsync().Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException(responseBody);
                }

                IModel model = ConvertModel(responseBody);
                return model;
            }
        }
    }
}