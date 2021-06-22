using System;
using System.Configuration;

namespace Our.Umbraco.FriendlyRobots.Helpers
{
    internal static class ConfigurationHelper
    {
        public static void SetProperty(string key, Action<string> setValue)
        {
            var value = ConfigurationManager.AppSettings[key];

            if (string.IsNullOrWhiteSpace(value) == false)
            {
                setValue(value);
            }
        }

        public static void SetProperty(string key, Action<string[]> setValue, char separator = ',')
        {
            var value = ConfigurationManager.AppSettings[key];

            if (string.IsNullOrWhiteSpace(value) == false)
            {
                setValue(value.Split(separator));
            }
        }
    }
}