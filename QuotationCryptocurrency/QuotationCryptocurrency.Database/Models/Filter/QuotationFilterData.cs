using System;
using System.Text.Json.Serialization;

namespace QuotationCryptocurrency.Database.Models.Filter
{
    public class QuotationFilterData
    {
        public string Name { get; set; }

        public string Symbol { get; set; }

        [JsonIgnore]
        public bool IsFilterName => string.IsNullOrEmpty(Name) == false;

        [JsonIgnore]
        public bool IsFilterSymbol => string.IsNullOrEmpty(Symbol) == false;
    }
}
