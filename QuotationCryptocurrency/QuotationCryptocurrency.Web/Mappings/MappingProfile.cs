using AutoMapper;
using QuotationCryptocurrency.Database.Models;
using QuotationCryptocurrency.Request.Parameters.CoinMarkerCap;
using QuotationCryptocurrency.Web.Models;

namespace QuotationCryptocurrency.Web.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMapQuotation();

            CreateMapCrypto();

            CreateMapQuote();
        }

        public void CreateMapQuotation()
        {
            CreateMap<QuotationDataView, QuotationModel>()
                .ForMember(x => x.Id, s => s.MapFrom(x => x.Id))
                .ForMember(x => x.CryptoId, s => s.MapFrom(x => x.CryptoId))
                .ForMember(x => x.Name, s => s.MapFrom(x => x.Name))
                .ForMember(x => x.Symbol, s => s.MapFrom(x => x.Symbol))
                .ForMember(x => x.Price, s => s.MapFrom(x => x.Price))
                .ForMember(x => x.PercentChange1H, s => s.MapFrom(x => x.PercentChange1h))
                .ForMember(x => x.PercentChange24H, s => s.MapFrom(x => x.PercentChange24h))
                .ForMember(x => x.MarketCap, s => s.MapFrom(x => x.MarketCap))
                .ForMember(x => x.LastUpdated, s => s.MapFrom(x => x.LastUpdated));

            CreateMap<CoinMarkerCapParam, QuotationModel>()
                .ForMember(x => x.Id, s => s.MapFrom(x => x.Id))
                .ForMember(x => x.CryptoId, s => s.MapFrom(x => x.Id))
                .ForMember(x => x.Name, s => s.MapFrom(x => x.Name))
                .ForMember(x => x.Symbol, s => s.MapFrom(x => x.Symbol))
                .ForMember(x => x.Price, s => s.MapFrom(x => x.Quote.Currency.Price))
                .ForMember(x => x.PercentChange1H, s => s.MapFrom(x => x.Quote.Currency.PercentChange1h))
                .ForMember(x => x.PercentChange24H, s => s.MapFrom(x => x.Quote.Currency.PercentChange24h))
                .ForMember(x => x.MarketCap, s => s.MapFrom(x => x.Quote.Currency.MarketCap))
                .ForMember(x => x.LastUpdated, s => s.MapFrom(x => x.Quote.Currency.LastUpdated));
        }

        public void CreateMapCrypto()
        {
            CreateMap<CryptoData, CryptoModel>()
                .ForMember(x => x.Id, s => s.MapFrom(x => x.Id))
                .ForMember(x => x.Name, s => s.MapFrom(x => x.Name))
                .ForMember(x => x.Symbol, s => s.MapFrom(x => x.Symbol));

            CreateMap<CryptoModel, CryptoData>()
                .ForMember(x => x.Id, s => s.MapFrom(x => x.Id))
                .ForMember(x => x.Name, s => s.MapFrom(x => x.Name))
                .ForMember(x => x.Symbol, s => s.MapFrom(x => x.Symbol));
        }

        public void CreateMapQuote()
        {
            CreateMap<QuoteData, QuoteModel>()
                .ForMember(x => x.Id, s => s.MapFrom(x => x.Id))
                .ForMember(x => x.Price, s => s.MapFrom(x => x.Price))
                .ForMember(x => x.PercentChange1h, s => s.MapFrom(x => x.PercentChange1h))
                .ForMember(x => x.PercentChange24h, s => s.MapFrom(x => x.PercentChange24h))
                .ForMember(x => x.MarketCap, s => s.MapFrom(x => x.MarketCap))
                .ForMember(x => x.LastUpdated, s => s.MapFrom(x => x.LastUpdated));

            CreateMap<QuoteModel, QuoteData>()
                .ForMember(x => x.Id, s => s.MapFrom(x => x.Id))
                .ForMember(x => x.Price, s => s.MapFrom(x => x.Price))
                .ForMember(x => x.PercentChange1h, s => s.MapFrom(x => x.PercentChange1h))
                .ForMember(x => x.PercentChange24h, s => s.MapFrom(x => x.PercentChange24h))
                .ForMember(x => x.MarketCap, s => s.MapFrom(x => x.MarketCap))
                .ForMember(x => x.LastUpdated, s => s.MapFrom(x => x.LastUpdated));
        }
    }
}
