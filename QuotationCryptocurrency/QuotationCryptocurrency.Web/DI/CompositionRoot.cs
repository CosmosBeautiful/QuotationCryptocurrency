using AutoMapper;
using LightInject;
using QuotationCryptocurrency.Database.Repositories;
using QuotationCryptocurrency.Request;
using QuotationCryptocurrency.Request.Parameters.CoinMarkerCap;
using QuotationCryptocurrency.Request.Requests;
using QuotationCryptocurrency.Web.Services;

namespace QuotationCryptocurrency.Web.DI
{
    public class CompositionRoot : ICompositionRoot
    {
        public void Compose(IServiceRegistry services)
        {
            RegisterMapper(services);

            services.RegisterScoped<IRequest<CoinMarkerCapParam>, CoinMarkerCapRequest>();
            services.RegisterScoped<IQuotationService, QuotationService>();
            services.RegisterScoped<IQuotationRepository, QuotationRepository>();
            services.RegisterScoped<ICryptoRepository, CryptoRepository>();
            services.RegisterScoped<IQuoteRepository, QuoteRepository>();
        }

        public void RegisterMapper(IServiceRegistry services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new QuotationCryptocurrency.Web.Mappings.MappingProfile());
            });

            services.Register<IMapper>(x => new Mapper(mappingConfig));
        }
    }
}
