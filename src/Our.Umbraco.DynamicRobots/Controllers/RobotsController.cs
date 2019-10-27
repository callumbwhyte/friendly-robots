using System.Linq;
using System.Text;
using System.Web.Mvc;
using Our.Umbraco.DynamicRobots.Configuration;
using Umbraco.Web.Mvc;

namespace Our.Umbraco.DynamicRobots.Controllers
{
    public class RobotsController : RenderMvcController
    {
        private readonly RobotsConfiguration _robotsConfig;

        public RobotsController(RobotsConfiguration robotsConfig)
        {
            _robotsConfig = robotsConfig;
        }

        public ActionResult RenderRobots()
        {
            var robotsTxt = BuildRobots();

            return Content(robotsTxt, "text/text", Encoding.UTF8);
        }

        private string BuildRobots()
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