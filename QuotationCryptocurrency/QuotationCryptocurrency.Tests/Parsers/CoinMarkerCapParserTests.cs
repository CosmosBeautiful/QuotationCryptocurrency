using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuotationCryptocurrency.Mappings;
using QuotationCryptocurrency.Models;
using QuotationCryptocurrency.Parsers;
using QuotationCryptocurrency.Quotations;
using QuotationCryptocurrency.Requests.CoinMarkerCap;
using System;
using System.Collections.Generic;

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
        private IModel CreateCoinMarkerCapParams()
        {
            var coinMarkerCapParams = new CoinMarkerCapParams()
            {
                Data = new CoinMarkerCapDataParams[]
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
                }
            };

            return coinMarkerCapParams;
        }

        private List<IModel> CreateCryptocurrencyQuotationModels()
        {
            var list = new List<IModel>()
            {
                new CryptocurrencyQuotationModel()
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

            IModel responseCoinMarkerCapParams = CreateCoinMarkerCapParams();
            List<IModel> expectedList = CreateCryptocurrencyQuotationModels();

            //act
            List<IModel> actualList = parser.ParsersyQuotationFromRequest(responseCoinMarkerCapParams);

            //assert
            //CollectionAssert.AreEqual(expectedList, actualList);
            
            for (int i = 0; i < expectedList.Count; i++)
            {
                var q1 = (CryptocurrencyQuotationModel)expectedList[i];
                var q2 = (CryptocurrencyQuotationModel)actualList[i];


                Assert.AreEqual(q1.Id, q2.Id);
                Assert.AreEqual(q1.Name, q2.Name);
                Assert.AreEqual(q1.Symbol, q2.Symbol);
                Assert.AreEqual(q1.Price, q2.Price);
                Assert.AreEqual(q1.PercentChange1h, q2.PercentChange1h);
                Assert.AreEqual(q1.PercentChange24h, q2.PercentChange24h);
                Assert.AreEqual(q1.MarketCap, q2.MarketCap);
                Assert.AreEqual(q1.LastUpdated, q2.LastUpdated);
            }
        }
    }
}
