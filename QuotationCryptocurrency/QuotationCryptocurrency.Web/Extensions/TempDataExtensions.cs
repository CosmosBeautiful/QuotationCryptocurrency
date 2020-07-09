using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;

namespace QuotationCryptocurrency
{
    public static class TempDataExtensions
    {
        public static void Set<T>(this ITempDataDictionary tempData, string key, T value) where T : class
        {
            tempData[key] = JsonConvert.SerializeObject(value);
        }

        public static T Get<T>(this ITempDataDictionary tempData, string key) where T : class
        {
            tempData.TryGetValue(key, out object obj);
            if(obj == null)
            {
                return null;
            }

            T result = JsonConvert.DeserializeObject<T>((string)obj);
            return result;
        }

        public static T Peek<T>(this ITempDataDictionary tempData, string key) where T : class
        {
            T value = Get<T>(tempData, key);
            Set<T>(tempData, key, value);
            return value;
        }
    }
}
