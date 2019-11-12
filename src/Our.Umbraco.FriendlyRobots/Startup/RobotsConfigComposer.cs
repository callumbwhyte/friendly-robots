using System.Configuration;
using Our.Umbraco.FriendlyRobots.Configuration;
using Our.Umbraco.FriendlyRobots.Extensions;
using Umbraco.Core.Composing;

namespace Our.Umbraco.FriendlyRobots.Startup
{
    public class RobotsConfigComposer : IUserComposer
    {
        private const string Prefix = "Umbraco.Robots";

        public void Compose(Composition composition)
        {
            composition.RegisterUnique(factory => GetConfiguration());
        }

        private RobotsConfiguration GetConfiguration()
        {
            var userAgent = ConfigurationManager.AppSettings[Prefix + ".UserAgent"];

            var allow = ConfigurationManager.AppSettings[Prefix + ".Allow"].SplitOrDefault();
            var disallow = ConfigurationManager.AppSettings[Prefix + ".Disallow"].SplitOrDefault();
            var sitemaps = ConfigurationManager.AppSettings[Prefix + ".Sitemaps"].SplitOrDefault();

            var configuration = new RobotsConfiguration
            {
                UserAgent = userAgent,
                Allow = allow,
                Disallow = disallow,
                Sitemaps = sitemaps
            };

            return configuration;
        }
    }
}