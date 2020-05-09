using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuotationCryptocurrency.Database.Contexts;
using System.IO;
using System.Linq;
using QuotationCryptocurrency.Database.Models;
using QuotationCryptocurrency.Database.Repositories;

namespace QuotationCryptocurrency.Database.Tests
{
    [TestClass]
    public class QuotationRepositoryTests
    {
        private static TestContext TestContext;

        private static QuotationContext DB { get; set; }

        [AssemblyInitialize]
        public static void InitializeTests(TestContext testContext)
        {
            TestContext = testContext;

            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json");

            IConfigurationRoot configuration = builder.Build();

            var _options = new DbContextOptionsBuilder<QuotationContext>()
                .UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                .Options;

            DB = new QuotationContext(_options);
        }

        [TestMethod]
        public void DatabaseConnection()
        {
            // arrange
            IQuotationRepository repository = new QuotationRepository(DB);

            //act
            List<Quotation> quotations = repository.Get().ToList();

            //assert
            Assert.AreEqual(true, (quotations.Count > 0), "No database connection");
        }
    }
}
