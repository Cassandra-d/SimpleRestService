using System;
using System.Configuration;
using System.Linq;

namespace Common
{
    public class ConfigurationHelper
    {
        private ConfigurationHelper()
        {
        }

        public static string GetValue(string configKey)
        {
            if (!ConfigurationManager.AppSettings.AllKeys.Contains(configKey))
                throw new InvalidOperationException($"The key {configKey} isn't presented in config file");

            return ConfigurationManager.AppSettings.Get(configKey);
        }

        public static string GetValueOrDefault(string configKey)
        {
            if (!ConfigurationManager.AppSettings.AllKeys.Contains(configKey))
                return string.Empty;

            return ConfigurationManager.AppSettings.Get(configKey);
        }
    }
}
