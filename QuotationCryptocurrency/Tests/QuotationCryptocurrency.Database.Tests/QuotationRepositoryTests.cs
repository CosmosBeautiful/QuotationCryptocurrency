using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuotationCryptocurrency.Database.Contexts;
using QuotationCryptocurrency.Database.Models;
using QuotationCryptocurrency.Database.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using QuotationCryptocurrency.Database.Tests.Helpers;

namespace QuotationCryptocurrency.Database.Tests
{
    [TestClass]
    public class QuotationRepositoryTests
    {
        private static QuotationContext DB { get; set; }

        #pragma warning disable IDE0060
        [AssemblyInitialize]
        public static void InitializeTests(TestContext testContext)
        {
            DB = ConfigurationHelper.GetQuotationContextTest();
        }
        #pragma warning restore IDE0060


        [TestMethod]
        public void DatabaseConnection()
        {
            try
            {
                //act
                IQuotationRepository repository = new QuotationRepository(DB);

                // arrange
                List<QuotationDataView> quotations = repository.Get().ToList();

                //assert
                Assert.IsTrue(quotations.Any(), "No elements in sequence");
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
