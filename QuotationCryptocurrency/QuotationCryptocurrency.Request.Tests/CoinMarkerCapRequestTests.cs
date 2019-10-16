﻿using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using QuotationCryptocurrency.Request.Configurations;
using QuotationCryptocurrency.Request.Parameters;
using System.Collections.Generic;

namespace QuotationCryptocurrency.Request.Tests.Requests
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
            IRequest<CoinMarkerCapParam> request = new CoinMarkerCapRequest(mockConfig.Object);

            //act
            List<CoinMarkerCapParam> coinMarkerCapParams = request.Send();

            //assert
            Assert.AreEqual(true, (coinMarkerCapParams.Count > 0), "No response from api");
        }
    }
}