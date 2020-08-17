using System.Linq;
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

            if (string.IsNullOrWhiteSpace(userAgent) == false)
            {
                userAgent = "*";
            }

            stringBuilder.AppendLine("User-agent: " + userAgent);

            if (_robotsConfig.Disallow.Any() == false
                && _robotsConfig.Allow.Any() == false)
            {
                stringBuilder.AppendLine("Allow: /");
            }

            if (_robotsConfig.Disallow.Any() == true)
            {
                foreach (var path in _robotsConfig.Disallow)
                {
                    stringBuilder.AppendLine("Disallow: " + path);
                }
            }

            if (_robotsConfig.Allow.Any() == true)
            {
                foreach (var path in _robotsConfig.Allow)
                {
                    stringBuilder.AppendLine("Allow: " + path);
                }
            }

            if (_robotsConfig.Sitemaps.Any() == true)
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