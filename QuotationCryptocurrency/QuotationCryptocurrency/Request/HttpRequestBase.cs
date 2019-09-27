using Newtonsoft.Json;
using QuotationCryptocurrency.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace QuotationCryptocurrency.Request
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