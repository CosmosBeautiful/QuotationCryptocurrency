using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using QuotationCryptocurrency.Business.DTO;
using QuotationCryptocurrency.Business.Mapper;
using QuotationCryptocurrency.Business.Services;
using QuotationCryptocurrency.Database.Models;
using QuotationCryptocurrency.Database.Repositories;
using QuotationCryptocurrency.Request;
using QuotationCryptocurrency.Request.Parameters;
using System;
using System.Collections.Generic;

namespace QuotationCryptocurrency.Business.Tests
{
    [TestClass]
    public class QuotationServiceTests
    {
        private static Mock<IQuotationRepository> _mockQuotationRepository;
        private static Mock<ICryptoRepository> _mockCryptoRepository;
        private static Mock<IQuoteRepository> _mockQuoteRepository;
        private static Mock<IRequest<CoinMarkerCapParam>> _mockRequest;

        private static IMapper _mapper;

        [ClassInitialize]
        public static void InitializeTests(TestContext testContext)
        {
            _mockQuotationRepository = new Mock<IQuotationRepository>();
            _mockCryptoRepository = new Mock<ICryptoRepository>();
            _mockQuoteRepository = new Mock<IQuoteRepository>();
            _mockRequest = new Mock<IRequest<CoinMarkerCapParam>>();

            _mapper = CreateMapper();
        }

        private static IMapper CreateMapper()
        {
            var mappingConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            return mapper;
        }

        [TestMethod]
        public void Get()
        {
            ////arrange
            //var quotationsView = new List<Quotation>()
            //{
            //    new Quotation()
            //    {
            //        Id = 1,
            //        CryptoId = 1,
            //        Name = "Bitcoin",
            //        Symbol = "BTC",
            //        Price = 8226.69420583,
            //        PercentChange1h = 0.195943,
            //        PercentChange24h = 2.18019,
            //        MarketCap = 147763866698.346,
            //        LastUpdated = DateTime.Parse("2019-09-28T04:46:34.000Z")
            //    }
            //};
            //var equationQuotationsDTO = new List<QuotationDTO>()
            //{ 
            //    new QuotationDTO()
            //    {
            //        Id = 1,
            //        CryptoId = 1,
            //        Name = "Bitcoin",
            //        Symbol = "BTC",
            //        Price = 8226.69420583,
            //        PercentChange1h = 0.195943,
            //        PercentChange24h = 2.18019,
            //        MarketCap = 147763866698.346,
            //        LastUpdated = DateTime.Parse("2019-09-28T04:46:34.000Z")
            //    }
            //};

            //_mockQuotationRepository
            //    .Setup(repo => repo.Get())
            //    .Returns(quotationsView);

            //IQuotationService quotationService = new QuotationService(
            //    _mockQuotationRepository.Object, _mockCryptoRepository.Object, _mockQuoteRepository.Object,
            //    _mockRequest.Object, _mapper
            //    );

            ////act
            //List<QuotationDTO> actualQuotationsDTO = quotationService.Get();

            ////assert
            //CollectionAssert.AreEqual(equationQuotationsDTO, actualQuotationsDTO);
        }
    }
}
