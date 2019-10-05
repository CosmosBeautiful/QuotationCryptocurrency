﻿using AutoMapper;
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

            IModel responseCoinMarkerCapParams = CreateCoinMarkerCapParams();
            List<IModel> equationModels = CreateCryptocurrencyQuotationModels();

            //act
            List<IModel> actualModels = parser.Parse(responseCoinMarkerCapParams);

            //assert
            CollectionAssert.AreEqual(equationModels, actualModels);
        }
    }
}
