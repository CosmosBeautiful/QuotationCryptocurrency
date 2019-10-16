using System;

namespace QuotationCryptocurrency.Business.DTO
{
    public class QuotationDTO
    {
        public int Id { get; set; }
        public int CryptoId { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public double Price { get; set; }
        public double? PercentChange1h { get; set; }
        public double? PercentChange24h { get; set; }
        public double? MarketCap { get; set; }
        public DateTime LastUpdated { get; set; }

        public override bool Equals(object other)
        {
            if (other is QuotationDTO)
            {
                var quotation = other as QuotationDTO;
                return ( (Id == quotation.Id) && (CryptoId == quotation.CryptoId) && (Name == quotation.Name) 
                    && (Symbol == quotation.Symbol) && (Price == quotation.Price) && (PercentChange1h == quotation.PercentChange1h) 
                    && (PercentChange24h == quotation.PercentChange24h) && (MarketCap == quotation.MarketCap)
                    && (LastUpdated == quotation.LastUpdated)
                    );
            }

            return false;
        }

        public override int GetHashCode()
        {
            return (Id * CryptoId * Name.GetHashCode() * Symbol.GetHashCode() * Price.GetHashCode() * PercentChange1h.GetHashCode()
                * PercentChange24h.GetHashCode() * MarketCap.GetHashCode() * LastUpdated.GetHashCode()
                );
        }
    }
}
