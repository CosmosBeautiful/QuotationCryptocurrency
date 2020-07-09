using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using QuotationCryptocurrency.Database.Contexts;
using QuotationCryptocurrency.Database.Repositories;
using QuotationCryptocurrency.Request;
using QuotationCryptocurrency.Request.Configurations;
using QuotationCryptocurrency.Request.Parameters.CoinMarkerCap;
using QuotationCryptocurrency.Request.Requests;
using QuotationCryptocurrency.Web.Services;

namespace QuotationCryptocurrency.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<QuotationContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("QuotationConnection")));

            services.Configure<CoinMarkerCapConfig>(Configuration.GetSection("CoinMarkerCap"));

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new QuotationCryptocurrency.Web.Mappings.MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddTransient<IRequest<CoinMarkerCapParam>, CoinMarkerCapRequest>();
            services.AddTransient<IQuotationService, QuotationService>();
            services.AddTransient<IQuotationRepository, QuotationRepository>();
            services.AddTransient<ICryptoRepository, CryptoRepository>();
            services.AddTransient<IQuoteRepository, QuoteRepository>();

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
