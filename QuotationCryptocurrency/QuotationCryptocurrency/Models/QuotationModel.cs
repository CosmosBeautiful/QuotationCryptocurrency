using System;

namespace QuotationCryptocurrency.Models
{
    public class QuotationModel : IModel
    {
        public int Id { get; set; }
        public int CryptoId { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public double Price { get; set; }
        public double? PercentChange1H { get; set; }
        public double? PercentChange24H { get; set; }
        public double? MarketCap { get; set; }
        public DateTime LastUpdated { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is QuotationModel other)
            {
                return ((Id == other.Id) && (CryptoId == other.CryptoId)  && (Name == other.Name) && (Symbol == other.Symbol) 
                    && (Symbol == other.Symbol) && (Price.Equals(other.Price)) && (Equals(PercentChange1H, other.PercentChange1H)) 
                    && (Equals(PercentChange24H, other.PercentChange24H)) && (Equals(MarketCap, other.MarketCap)) 
                    && (LastUpdated == other.LastUpdated));
            }

            return false;
        }

        public override int GetHashCode()
        {
            return (Id * CryptoId * Name.GetHashCode() * Symbol.GetHashCode() * Price.GetHashCode() * PercentChange1H.GetHashCode() 
                    * PercentChange24H.GetHashCode() * MarketCap.GetHashCode() * LastUpdated.GetHashCode());
        }
    }
}
