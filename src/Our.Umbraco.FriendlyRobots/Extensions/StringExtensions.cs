using System;

namespace Our.Umbraco.FriendlyRobots.Extensions
{
    internal static class StringExtensions
    {
        public static string[] SplitOrDefault(this string value, char separator = ',')
        {
            if (string.IsNullOrWhiteSpace(value) == false)
            {
                return value.Split(separator);
            }

            return new string[] { };
        }
    }
}