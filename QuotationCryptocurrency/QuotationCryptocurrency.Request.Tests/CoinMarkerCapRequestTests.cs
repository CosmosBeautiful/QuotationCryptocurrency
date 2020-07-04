using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuotationCryptocurrency.Request.Parameters.CoinMarkerCap;
using QuotationCryptocurrency.Request.Tests.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace QuotationCryptocurrency.Request.Tests
{
    [TestClass]
    public class CoinMarkerCapRequestTests
    {
        [TestMethod]
        public void VerificationOfSendingRequestApi()
        {
            // arrange
            IRequest<CoinMarkerCapParam> request = ConfigurationHelper.CreateCoinMarkerCapRequest();

            //act
            List<CoinMarkerCapParam> coinMarkerCapParams = request.SendAndGetResult();

            //assert
            Assert.IsTrue(coinMarkerCapParams.Any(), "No response from api");
        }
    }
}
