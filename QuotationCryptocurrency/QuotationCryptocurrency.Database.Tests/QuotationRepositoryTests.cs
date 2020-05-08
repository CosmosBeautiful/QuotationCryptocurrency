using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuotationCryptocurrency.Database.Contexts;
using System.IO;

namespace QuotationCryptocurrency.Database.Tests
{
    [TestClass]
    public class QuotationRepositoryTests
    {
        private static TestContext _testContext;
        private static QuotationContext _db { get; set; }

        [AssemblyInitialize]
        public static void InitializeTests(TestContext testContext)
        {
            _testContext = testContext;

            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json");

            IConfigurationRoot configuration = builder.Build();

            var _options = new DbContextOptionsBuilder<QuotationContext>()
                .UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                .Options;

            _db = new QuotationContext(_options);
        }

        //[TestMethod]
        //public void DatabaseConnection()
        //{
        //    // arrange
        //    IQuotationRepository repository = new QuotationRepository(_db);

        //    //act
        //    List<Quotation> quotations = repository.Get();

        //    //assert
        //    Assert.AreEqual(true, (quotations.Count > 0), "No database connection");
        //}
    }
}
