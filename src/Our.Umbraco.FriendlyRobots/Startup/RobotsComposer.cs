using System.Configuration;
using Our.Umbraco.FriendlyRobots.Configuration;
using Our.Umbraco.FriendlyRobots.Extensions;
using Umbraco.Core;
using Umbraco.Core.Composing;

namespace Our.Umbraco.FriendlyRobots.Startup
{
    public class RobotsComposer : IUserComposer
    {
        public void Compose(Composition composition)
        {
            composition.Components().Append<RobotsRouteComponent>();

            composition.Register(factory => GetConfiguration());
        }

        private RobotsConfiguration GetConfiguration()
        {
            var userAgent = ConfigurationManager.AppSettings[Constants.ConfigPrefix + "UserAgent"];

            var allow = ConfigurationManager.AppSettings[Constants.ConfigPrefix + "Allow"].SplitOrDefault();
            var disallow = ConfigurationManager.AppSettings[Constants.ConfigPrefix + "Disallow"].SplitOrDefault();
            var sitemaps = ConfigurationManager.AppSettings[Constants.ConfigPrefix + "Sitemaps"].SplitOrDefault();

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