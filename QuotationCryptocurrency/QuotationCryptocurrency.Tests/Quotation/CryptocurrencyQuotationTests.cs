using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using QuotationCryptocurrency.Models;
using QuotationCryptocurrency.Parsers;
using QuotationCryptocurrency.Quotations;
using QuotationCryptocurrency.Requests;
using System.Collections.Generic;

namespace QuotationCryptocurrency.Tests.Quotation
{
    [TestClass]
    public class CryptocurrencyQuotationTests
    {
        [TestMethod]
        public void GetQuotation()
        {
            // arrange
            Mock<IRequest> mockRequest = new Mock<IRequest>();
            mockRequest
               .Setup(repo => repo.Send())
               .Returns(new Mock<IModel>().Object);

            Mock<IParser> mockParser = new Mock<IParser>();
            mockParser
               .Setup(repo => repo.ParsersyQuotationFromRequest(It.IsAny<IModel>()))
               .Returns(new List<IModel>());

            var cryptocurrencyQuotation = new CryptocurrencyQuotation(mockRequest.Object, mockParser.Object);

            //act
            cryptocurrencyQuotation.GetQuotation();

            //assert
            mockRequest.VerifyAll();
            mockParser.VerifyAll();
        }
    }
}
