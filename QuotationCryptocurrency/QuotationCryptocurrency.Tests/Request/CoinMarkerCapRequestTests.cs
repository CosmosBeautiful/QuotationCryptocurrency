using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuotationCryptocurrency.Request;
using QuotationCryptocurrency.Request.CoinMarkerCap;

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