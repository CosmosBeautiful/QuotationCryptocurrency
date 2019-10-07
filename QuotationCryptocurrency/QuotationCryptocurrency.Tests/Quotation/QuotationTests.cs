using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using QuotationCryptocurrency.Models;
using QuotationCryptocurrency.Parsers;
using QuotationCryptocurrency.Quotations;
using QuotationCryptocurrency.Requests;
using QuotationCryptocurrency.Requests.CoinMarkerCap;
using System;
using System.Collections.Generic;

namespace QuotationCryptocurrency.Tests.Quotation
{
    [TestClass]
    public class QuotationTests
    {
        [TestMethod]
        public void GetQuotation()
        {
            // arrange
            var resultParams = new CoinMarkerCapParams()
            {
                Data = new CoinMarkerCapDataParams[]
                {
                }
            };

            Mock<IRequest> mockRequest = new Mock<IRequest>();
            mockRequest
               .Setup(repo => repo.Send())
               .Returns(resultParams);

            Mock<IParser<QuotationModel, CoinMarkerCapDataParams>> mockParser = new Mock<IParser<QuotationModel, CoinMarkerCapDataParams>>();
            mockParser
               .Setup(repo => repo.Parse(It.IsAny<List<CoinMarkerCapDataParams>>()))
               .Returns(new List<QuotationModel>());

            var quotation = new Quotations.Quotation(mockRequest.Object, mockParser.Object);

            //act
            quotation.GetQuotation();

            //assert
            mockRequest.VerifyAll();
            mockParser.VerifyAll();
        }
    }
}
