using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuotationCryptocurrency.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.Core.Internal;
using QuotationCryptocurrency.Database.Models.Filter;
using QuotationCryptocurrency.Database.Models.Pagination;
using QuotationCryptocurrency.Database.Models.Sort;
using QuotationCryptocurrency.Database.Repositories;

namespace QuotationCryptocurrency.Tests.Models
{
    [TestClass]
    public class QuotationViewModelTests
    {
        #region Create Objects for CorrectCreateQuotationViewModel
        private List<QuotationModel> CreateQuotations()
        {
            var quotations = new List<QuotationModel>()
            {
                new QuotationModel()
                {
                    Id = 1,
                    CryptoId = 1,
                    Name = "Bitcoin",
                    Symbol = "BTC",
                    Price = 8226.69420583,
                    PercentChange1H = 0.195943,
                    PercentChange24H = 2.18019,
                    MarketCap = 147763866698.346,
                    LastUpdated = DateTime.Parse("2019-09-28T04:46:34.000Z")
                },
                new QuotationModel()
                {
                    Id = 1,
                    CryptoId = 1,
                    Name = "Ethereum",
                    Symbol = "ETH",
                    Price = 169.11,
                    PercentChange1H = 0.546,
                    PercentChange24H = 1.9856,
                    MarketCap = 18255409958.650,
                    LastUpdated = DateTime.Parse("2019-09-28T04:22:32.000Z")
                },
                new QuotationModel()
                {
                    Id = 1,
                    CryptoId = 1,
                    Name = "Bitcoin Cash",
                    Symbol = "BCH",
                    Price = 218.40,
                    PercentChange1H = 0.4943,
                    PercentChange24H = 5.4519,
                    MarketCap = 3937891858.454,
                    LastUpdated = DateTime.Parse("2019-09-28T04:20:45.000Z")
                }
            };

            return quotations;
        }

        private List<QuotationModel> CreateEquationQuotationViewModel()
        {
            var equationQuotation = new List<QuotationModel>()
            {
                new QuotationModel()
                {
                    Id = 1,
                    CryptoId = 1,
                    Name = "Bitcoin",
                    Symbol = "BTC",
                    Price = 8226.69420583,
                    PercentChange1H = 0.195943,
                    PercentChange24H = 2.18019,
                    MarketCap = 147763866698.346,
                    LastUpdated = DateTime.Parse("2019-09-28T04:46:34.000Z")
                },
                new QuotationModel()
                {
                    Id = 1,
                    CryptoId = 1,
                    Name = "Ethereum",
                    Symbol = "ETH",
                    Price = 169.11,
                    PercentChange1H = 0.546,
                    PercentChange24H = 1.9856,
                    MarketCap = 18255409958.650,
                    LastUpdated = DateTime.Parse("2019-09-28T04:22:32.000Z")
                },
                new QuotationModel()
                {
                    Id = 1,
                    CryptoId = 1,
                    Name = "Bitcoin Cash",
                    Symbol = "BCH",
                    Price = 218.40,
                    PercentChange1H = 0.4943,
                    PercentChange24H = 5.4519,
                    MarketCap = 3937891858.454,
                    LastUpdated = DateTime.Parse("2019-09-28T04:20:45.000Z")
                }
            };

            return equationQuotation;
        }
        #endregion

        [TestMethod]
        public void CorrectCreateQuotationViewModel()
        {
            // arrange
            List<QuotationModel> equationQuotation = CreateEquationQuotationViewModel();

            List<QuotationModel> quotations = CreateQuotations();
            
            int page = 1;
            int totalCount = quotations.Count;

            string nameFilter = "Bit";
            var sortOrder = QuotationSortType.PercentChange24HAsc;

            //act
            var filterData = new QuotationFilterData
            {
                Name = nameFilter
            };

            var paginationData = new PaginationData(page);
            var paginationModel = new PaginationModel(paginationData, totalCount);
            var actualQuotationModel = new QuotationViewModel(quotations, sortOrder, filterData, paginationModel);

            //assert
            CollectionAssert.AreEqual(equationQuotation, actualQuotationModel.Quotations.ToList());
            Assert.AreEqual(sortOrder, actualQuotationModel.SortModel);
            Assert.AreEqual(nameFilter, actualQuotationModel.FilterData.Name);
            Assert.IsTrue(actualQuotationModel.FilterData.Symbol.IsNullOrEmpty());
        }
    }
}
