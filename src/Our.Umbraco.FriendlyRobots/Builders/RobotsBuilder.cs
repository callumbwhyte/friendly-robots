using System.Text;
using Our.Umbraco.FriendlyRobots.Configuration;
using Umbraco.Core.Models.PublishedContent;

namespace Our.Umbraco.FriendlyRobots.Builders
{
    public class RobotsBuilder : IRobotsBuilder
    {
        private readonly RobotsConfiguration _config;

        public RobotsBuilder(RobotsConfiguration config)
        {
            _config = config;
        }

        public string BuildRobots(IPublishedContent node, string culture)
        {
            var stringBuilder = new StringBuilder();

            var userAgent = _config.UserAgent;

            if (string.IsNullOrWhiteSpace(userAgent) == true)
            {
                userAgent = "*";
            }

            stringBuilder.AppendLine("User-agent: " + userAgent);

            if (_config.Disallow == null && _config.Allow == null)
            {
                stringBuilder.AppendLine("Allow: /");
            }

            if (_config.Allow != null)
            {
                foreach (var path in _config.Allow)
                {
                    stringBuilder.AppendLine("Allow: " + path);
                }
            }

            if (_config.Disallow != null)
            {
                foreach (var path in _config.Disallow)
                {
                    stringBuilder.AppendLine("Disallow: " + path);
                }
            }

            if (_config.Sitemaps != null)
            {
                foreach (var path in _config.Sitemaps)
                {
                    stringBuilder.AppendLine("Sitemap: " + path);
                }
            }

            var robotsTxt = stringBuilder.ToString();

            return robotsTxt;
        }
    }
}