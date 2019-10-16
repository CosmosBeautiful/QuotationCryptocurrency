using AutoMapper;
using QuotationCryptocurrency.Business.DTO;
using QuotationCryptocurrency.Database.Models;
using QuotationCryptocurrency.Request.Parameters;

namespace QuotationCryptocurrency.Business.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<QuotationView, QuotationDTO>()
                .ForMember(x => x.Id, s => s.MapFrom(x => x.Id))
                .ForMember(x => x.CryptoId, s => s.MapFrom(x => x.CryptoId))
                .ForMember(x => x.Name, s => s.MapFrom(x => x.Name))
                .ForMember(x => x.Symbol, s => s.MapFrom(x => x.Symbol))
                .ForMember(x => x.Price, s => s.MapFrom(x => x.Price))
                .ForMember(x => x.PercentChange1h, s => s.MapFrom(x => x.PercentChange1h))
                .ForMember(x => x.PercentChange24h, s => s.MapFrom(x => x.PercentChange24h))
                .ForMember(x => x.MarketCap, s => s.MapFrom(x => x.MarketCap))
                .ForMember(x => x.LastUpdated, s => s.MapFrom(x => x.LastUpdated));

            CreateMap<Crypto, CryptoDTO>()
                .ForMember(x => x.Id, s => s.MapFrom(x => x.Id))
                .ForMember(x => x.Name, s => s.MapFrom(x => x.Name))
                .ForMember(x => x.Symbol, s => s.MapFrom(x => x.Symbol));

            CreateMap<Quote, QuoteDTO>()
                .ForMember(x => x.Id, s => s.MapFrom(x => x.Id))
                .ForMember(x => x.Price, s => s.MapFrom(x => x.Price))
                .ForMember(x => x.PercentChange1h, s => s.MapFrom(x => x.PercentChange1h))
                .ForMember(x => x.PercentChange24h, s => s.MapFrom(x => x.PercentChange24h))
                .ForMember(x => x.MarketCap, s => s.MapFrom(x => x.MarketCap))
                .ForMember(x => x.LastUpdated, s => s.MapFrom(x => x.LastUpdated));

            CreateMap<CoinMarkerCapParam, QuotationDTO>()
                .ForMember(x => x.Id, s => s.MapFrom(x => x.Id))
                .ForMember(x => x.CryptoId, s => s.MapFrom(x => x.Id))
                .ForMember(x => x.Name, s => s.MapFrom(x => x.Name))
                .ForMember(x => x.Symbol, s => s.MapFrom(x => x.Symbol))
                .ForMember(x => x.Price, s => s.MapFrom(x => x.Quote.Currency.Price))
                .ForMember(x => x.PercentChange1h, s => s.MapFrom(x => x.Quote.Currency.PercentChange1h))
                .ForMember(x => x.PercentChange24h, s => s.MapFrom(x => x.Quote.Currency.PercentChange24h))
                .ForMember(x => x.MarketCap, s => s.MapFrom(x => x.Quote.Currency.MarketCap))
                .ForMember(x => x.LastUpdated, s => s.MapFrom(x => x.Quote.Currency.LastUpdated));
        }
    }
}
