using System.Text;
using Our.Umbraco.FriendlyRobots.Configuration;
using Umbraco.Core.Models.PublishedContent;

namespace Our.Umbraco.FriendlyRobots.Builders
{
    public class RobotsBuilder : IRobotsBuilder
    {
        private readonly RobotsConfiguration _robotsConfig;

        public RobotsBuilder(RobotsConfiguration robotsConfig)
        {
            _robotsConfig = robotsConfig;
        }

        public string BuildRobots(IPublishedContent startNode)
        {
            var stringBuilder = new StringBuilder();

            var userAgent = _robotsConfig.UserAgent;

            if (string.IsNullOrWhiteSpace(userAgent) == true)
            {
                userAgent = "*";
            }

            stringBuilder.AppendLine("User-agent: " + userAgent);

            if (_robotsConfig.Disallow == null && _robotsConfig.Allow == null)
            {
                stringBuilder.AppendLine("Allow: /");
            }

            if (_robotsConfig.Disallow != null)
            {
                foreach (var path in _robotsConfig.Disallow)
                {
                    stringBuilder.AppendLine("Disallow: " + path);
                }
            }

            if (_robotsConfig.Allow != null)
            {
                foreach (var path in _robotsConfig.Allow)
                {
                    stringBuilder.AppendLine("Allow: " + path);
                }
            }

            if (_robotsConfig.Sitemaps != null)
            {
                foreach (var path in _robotsConfig.Sitemaps)
                {
                    stringBuilder.AppendLine("Sitemap: " + path);
                }
            }

            var robotsTxt = stringBuilder.ToString();

            return robotsTxt;
        }
    }
}