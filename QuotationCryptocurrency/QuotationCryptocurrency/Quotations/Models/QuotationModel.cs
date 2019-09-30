using QuotationCryptocurrency.Models;
using System;

namespace QuotationCryptocurrency.Quotations
{
    public class QuotationModel : IModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Symbol { get; set; }

        public double Price { get; set; }

        public double? PercentChange1h { get; set; }

        public double? PercentChange24h { get; set; }

        public double? MarketCap { get; set; }

        public DateTime LastUpdated { get; set; }


        public override bool Equals(object obj)
        {
            if (obj is QuotationModel)
            {
                var other = obj as QuotationModel;
                return ((Id == other.Id) && (Name == other.Name) && (Symbol == other.Symbol) && (Symbol == other.Symbol) 
                    && (Price == other.Price) && (PercentChange1h == other.PercentChange1h) && (PercentChange24h == other.PercentChange24h)
                    && (MarketCap == other.MarketCap) && (LastUpdated == other.LastUpdated));
            }

            return false;
        }

        public override int GetHashCode()
        {
            return Id * Name.GetHashCode() * Symbol.GetHashCode() * Price.GetHashCode() * PercentChange1h.GetHashCode() * PercentChange24h.GetHashCode() * MarketCap.GetHashCode() * LastUpdated.GetHashCode();
        }
    }
}
