﻿using Microsoft.Extensions.Configuration;

namespace StoreInfo.Common.Helpers
{
    public static class ConfigurationHelper
    {
        public static IConfiguration GetConfigurationSection(string section)
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build()
                .GetSection(section);
        }

        public static T GetConfigurationValue<T>(string section)
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build()
                .GetValue<T>(section);
        }
    }
}
