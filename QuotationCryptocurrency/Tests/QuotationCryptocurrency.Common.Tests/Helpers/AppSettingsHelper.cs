using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace QuotationCryptocurrency.Web.Common.Tests.Helpers
{
    public static class AppSettingsHelper
    {
        private const string AppSettingsName = "appsettings.json";

        private static IConfigurationRoot _Configuration;
        private static IConfigurationRoot Configuration
        {
            get
            {
                if (_Configuration == null)
                {
                    _Configuration = GetConfiguration();
                    return _Configuration;
                }
                return _Configuration;
            }
        }

        public static IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(AppSettingsName);

            var configuration = builder.Build();
            return configuration;
        }

        public static T GetSetting<T>(string section, string name)
        {
            try
            {
                string settingString = Configuration?.GetSection(section)?[name] ?? string.Empty;

                T setting = (T)Convert.ChangeType(settingString, typeof(T));
                return setting;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
