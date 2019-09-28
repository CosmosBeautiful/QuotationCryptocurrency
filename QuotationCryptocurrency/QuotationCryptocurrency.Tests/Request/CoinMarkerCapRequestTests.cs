using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuotationCryptocurrency.Requests;
using QuotationCryptocurrency.Requests.CoinMarkerCap;

namespace QuotationCryptocurrency.Tests.Request
{
    [TestClass]
    public class CoinMarkerCapRequestTests
    {
        [TestMethod]
        public void VerificationOfSendingRequestApi()
        {
            // arrange
            IRequest request = new CoinMarkerCapHttpRequest();

            //act
            CoinMarkerCapParams response = (CoinMarkerCapParams)request.Send();

            //assert
            Assert.AreEqual(true, (response.Data.Length > 0), "No response from api");
        }
    }
}