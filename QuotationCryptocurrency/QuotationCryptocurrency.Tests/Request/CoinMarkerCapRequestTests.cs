using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using QuotationCryptocurrency.Configurations;
using QuotationCryptocurrency.Requests;
using QuotationCryptocurrency.Requests.CoinMarkerCap;

namespace QuotationCryptocurrency.Tests.Request
{
    [TestClass]
    public class CoinMarkerCapRequestTests
    {
        private Mock<IOptions<CoinMarkerCapConfig>> CreateCoinMarkerCapConfig()
        {
            CoinMarkerCapConfig config = new CoinMarkerCapConfig()
            {
                ApiUrl = "https://pro-api.coinmarketcap.com/v1/cryptocurrency/listings/latest",
                ApiKey = "f34514dd-d398-4561-82c1-b9552c59d4ee",
                StartElem = 1,
                LimitElem = 50,
                Currency = "USD"
            };

            var mockConfig = new Mock<IOptions<CoinMarkerCapConfig>>();
            mockConfig.Setup(ap => ap.Value).Returns(config);

            return mockConfig;
        }

        [TestMethod]
        public void VerificationOfSendingRequestApi()
        {
            // arrange
            Mock<IOptions<CoinMarkerCapConfig>> mockConfig = CreateCoinMarkerCapConfig();
            IRequest request = new CoinMarkerCapHttpRequest(mockConfig.Object);

            //act
            CoinMarkerCapParams response = (CoinMarkerCapParams)request.Send();

            //assert
            Assert.AreEqual(true, (response.Data.Length > 0), "No response from api");
        }
    }
}