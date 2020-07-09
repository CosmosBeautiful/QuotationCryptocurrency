using Microsoft.Extensions.Options;
using Moq;
using QuotationCryptocurrency.Request.Configurations;
using QuotationCryptocurrency.Request.Parameters.CoinMarkerCap;
using QuotationCryptocurrency.Request.Requests;
using QuotationCryptocurrency.Web.Common.Tests.Helpers;

namespace QuotationCryptocurrency.Request.Tests.Helpers
{
    public static class ConfigurationHelper
    {
        private const string CoinMarkerCapSection = "CoinMarkerCap";

        private static IRequest<CoinMarkerCapParam> _CoinMarketCapRequest;
        public static IRequest<CoinMarkerCapParam> CoinMarketCapRequest
        {
            get
            {
                if (_CoinMarketCapRequest == null)
                {
                    _CoinMarketCapRequest = CreateCoinMarkerCapRequest();
                    return _CoinMarketCapRequest;
                }
                return _CoinMarketCapRequest;
            }
        }

        public static IRequest<CoinMarkerCapParam> CreateCoinMarkerCapRequest()
        {
            IOptions<CoinMarkerCapConfig> optionConfig = GetCoinMarkerCapConfig();
            IRequest<CoinMarkerCapParam> request = new CoinMarkerCapRequest(optionConfig);
            return request;
        }

        private static IOptions<CoinMarkerCapConfig> GetCoinMarkerCapConfig()
        {
            var config = new CoinMarkerCapConfig
            {
                ApiUrl = AppSettingsHelper.GetSetting<string>(CoinMarkerCapSection, "ApiUrl"),
                ApiKey = AppSettingsHelper.GetSetting<string>(CoinMarkerCapSection, "ApiKey"),
                StartElem = AppSettingsHelper.GetSetting<int>(CoinMarkerCapSection, "StartElem"),
                LimitElem = AppSettingsHelper.GetSetting<int>(CoinMarkerCapSection, "LimitElem"),
                Currency = AppSettingsHelper.GetSetting<string>(CoinMarkerCapSection, "Currency")
            };

            var mockConfig = new Mock<IOptions<CoinMarkerCapConfig>>();
            mockConfig.Setup(ap => ap.Value).Returns(config);

            return mockConfig.Object;
        }
    }
}
