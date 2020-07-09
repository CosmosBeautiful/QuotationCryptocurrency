using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuotationCryptocurrency.Request;
using QuotationCryptocurrency.Request.Parameters.CoinMarkerCap;
using System.Collections.Generic;
using System.Linq;
using QuotationCryptocurrency.Request.Tests.Helpers;

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
