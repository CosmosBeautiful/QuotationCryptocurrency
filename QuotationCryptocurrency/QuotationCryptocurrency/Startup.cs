using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuotationCryptocurrency.Data;
using QuotationCryptocurrency.Database;
using QuotationCryptocurrency.Database.Contexts;
using QuotationCryptocurrency.Database.Repositories;
using QuotationCryptocurrency.Request;
using QuotationCryptocurrency.Request.Configurations;
using QuotationCryptocurrency.Request.Parameters;
using QuotationCryptocurrency.Request.Parameters.CoinMarkerCap;
using QuotationCryptocurrency.Request.Requests;
using QuotationCryptocurrency.Services;

namespace QuotationCryptocurrency
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<QuotationContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("QuotationConnection")));
            services.AddDefaultIdentity<IdentityUser>()
                .AddDefaultUI(UIFramework.Bootstrap4)
                .AddEntityFrameworkStores<ApplicationDbContext>();


            services.AddOptions();
            services.Configure<CoinMarkerCapConfig>(Configuration.GetSection("CoinMarkerCap"));

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new QuotationCryptocurrency.Mappings.MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddTransient<IRequest<CoinMarkerCapParam>, CoinMarkerCapRequest>();
            services.AddTransient<IQuotationRepository, QuotationRepository>();
            services.AddTransient<ICryptoRepository, CryptoRepository>();
            services.AddTransient<IQuoteRepository, QuoteRepository>();


            services.AddTransient<IQuotationService, QuotationService>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
