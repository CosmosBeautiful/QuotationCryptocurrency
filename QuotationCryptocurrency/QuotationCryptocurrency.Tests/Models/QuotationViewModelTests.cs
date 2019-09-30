using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuotationCryptocurrency.FilterModels.Quotation;
using QuotationCryptocurrency.Models;
using QuotationCryptocurrency.Quotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuotationCryptocurrency.Tests.Models
{
    [TestClass]
    public class QuotationViewModelTests
    {
        #region Create Objects for CorrectCreateQuotationViewModel
        private IEnumerable<QuotationModel> CreateQuotations()
        {
            var quotations = new List<QuotationModel>()
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
                },
                new QuotationModel()
                {
                    Id = 1,
                    Name = "Ethereum",
                    Symbol = "ETH",
                    Price = 169.11,
                    PercentChange1h = 0.546,
                    PercentChange24h = 1.9856,
                    MarketCap = 18255409958.650,
                    LastUpdated = DateTime.Parse("2019-09-28T04:22:32.000Z")
                },
                new QuotationModel()
                {
                    Id = 1,
                    Name = "Bitcoin Cash",
                    Symbol = "BCH",
                    Price = 218.40,
                    PercentChange1h = 0.4943,
                    PercentChange24h = 5.4519,
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
                    Name = "Bitcoin Cash",
                    Symbol = "BCH",
                    Price = 218.40,
                    PercentChange1h = 0.4943,
                    PercentChange24h = 5.4519,
                    MarketCap = 3937891858.454,
                    LastUpdated = DateTime.Parse("2019-09-28T04:20:45.000Z")
                },
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

            return equationQuotation;
        }
        #endregion

        [TestMethod]
        public void CorrectCreateQuotationViewModel()
        {
            // arrange
            IEnumerable<QuotationModel> quotations = CreateQuotations();
            int page = 1;
            QuotationSortType sortType = QuotationSortType.NameDesc;
            string selectedName = "Bit";

            List<QuotationModel> equationQuotation = CreateEquationQuotationViewModel();

            //act
            QuotationViewModel actualQuotation = new QuotationViewModel(quotations, page, sortType, selectedName);

            //assert
            var actualListQuotation = actualQuotation.Quotations.ToList();
            CollectionAssert.AreEqual(equationQuotation, actualListQuotation);
        }
    }
}
