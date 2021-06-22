using Our.Umbraco.FriendlyRobots.Helpers;

namespace Our.Umbraco.FriendlyRobots.Configuration
{
    public class RobotsConfiguration
    {
        public string UserAgent { get; set; }

        public string[] Allow { get; set; }

        public string[] Disallow { get; set; }

        public string[] Sitemaps { get; set; }

        public static RobotsConfiguration Create()
        {
            var config = new RobotsConfiguration();

            ConfigurationHelper.SetProperty(Constants.ConfigPrefix + "UserAgent", value => config.UserAgent = value);

            ConfigurationHelper.SetProperty(Constants.ConfigPrefix + "Allow", value => config.Allow = value);

            ConfigurationHelper.SetProperty(Constants.ConfigPrefix + "Disallow", value => config.Disallow = value);

            ConfigurationHelper.SetProperty(Constants.ConfigPrefix + "Sitemaps", value => config.Sitemaps = value);

            return config;
        }
    }
}