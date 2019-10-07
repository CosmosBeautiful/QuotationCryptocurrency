using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuotationCryptocurrency.Mappings;
using QuotationCryptocurrency.Parsers;
using QuotationCryptocurrency.Quotations;
using QuotationCryptocurrency.Requests.CoinMarkerCap;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuotationCryptocurrency.Tests.Parsers
{
    [TestClass]
    public class CoinMarkerCapParserTests
    {
        private IMapper CreateMapper()
        {
            var mappingConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            return mapper;
        }

        #region Create Objects for ParsersyQuotationFromRequest
        private List<CoinMarkerCapDataParams> CreateCoinMarkerCapDataParams()
        {
            var data = new List<CoinMarkerCapDataParams>
            {
                new CoinMarkerCapDataParams()
                {
                    Id = 1,
                    Name = "Bitcoin",
                    Symbol = "BTC",
                    Slug = "bitcoin",
                    NumMarkerPairs = 8112,
                    DateAdded = DateTime.Parse("2013-04-28T00:00:00.000Z"),
                    TotalSupply = 17961512,
                    Platform = null,
                    CmcRank = 1,
                    LastUpdated = DateTime.Parse("2019-09-28T04:46:34.000Z"),
                    Quote = new CointMarkerCapQuoteParams()
                    {
                        Currency = new CointMarkerCapCurrencyParams()
                        {
                            Price = 8226.69420583,
                            Volume24h = 15849701886.0833,
                            PercentChange1h = 0.195943,
                            PercentChange24h = 2.18019,
                            PercentChange7d = -18.8255,
                            MarketCap = 147763866698.346,
                            LastUpdated = DateTime.Parse("2019-09-28T04:46:34.000Z")
                        }
                    }
                }
            };

            return data;
        }

        private List<QuotationModel> CreateCryptocurrencyQuotationModels()
        {
            var list = new List<QuotationModel>()
            {
                new QuotationModel()
                {
                    Id = 1,
                    Name = "Bitcoin",
                    Symbol = "BTC",
                    Price = 8226.69420583,
                    PercentChange1h = 0.195943,
                    PercentChange24h = 2.18019,
                    MarketCap = 147763866698.346,
                    LastUpdated = DateTime.Parse("2019-09-28T04:46:34.000Z")
                }
            };

            return list;
        }
        #endregion

        [TestMethod]
        public void ParsersyQuotationFromRequest()
        {
            // arrange
            IMapper mapper = CreateMapper();
            var parser = new CoinMarkerCapParser(mapper);

            List<CoinMarkerCapDataParams> responseData = CreateCoinMarkerCapDataParams();
            List<QuotationModel> equationModels = CreateCryptocurrencyQuotationModels();

            //act
            List<QuotationModel> actualModels = parser.Parse(responseData);

            //assert
            CollectionAssert.AreEqual(equationModels, actualModels);
        }
    }
}
