using AutoMapper;
using QuotationCryptocurrency.Business.DTO;
using QuotationCryptocurrency.Database.Models;
using QuotationCryptocurrency.Models;
using QuotationCryptocurrency.Request.Parameters;

namespace QuotationCryptocurrency.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<QuotationDTO, QuotationModel>()
                .ForMember(x => x.Id, s => s.MapFrom(x => x.Id))
                .ForMember(x => x.CryptoId, s => s.MapFrom(x => x.CryptoId))
                .ForMember(x => x.Name, s => s.MapFrom(x => x.Name))
                .ForMember(x => x.Symbol, s => s.MapFrom(x => x.Symbol))
                .ForMember(x => x.Price, s => s.MapFrom(x => x.Price))
                .ForMember(x => x.PercentChange1h, s => s.MapFrom(x => x.PercentChange1h))
                .ForMember(x => x.PercentChange24h, s => s.MapFrom(x => x.PercentChange24h))
                .ForMember(x => x.MarketCap, s => s.MapFrom(x => x.MarketCap))
                .ForMember(x => x.LastUpdated, s => s.MapFrom(x => x.LastUpdated));
        }
    }
}
