using System.Text;
using System.Web.Mvc;
using Our.Umbraco.FriendlyRobots.Builders;
using Umbraco.Web.Mvc;

namespace Our.Umbraco.FriendlyRobots.Controllers
{
    public class RobotsController : RenderMvcController
    {
        private readonly IRobotsBuilder _robotsBuilder;

        public RobotsController(IRobotsBuilder robotsBuilder)
        {
            _robotsBuilder = robotsBuilder;
        }

        public ActionResult RenderRobots()
        {
            var request = UmbracoContext.PublishedRequest;

            var startNode = request?.PublishedContent;

            if (startNode == null)
            {
                return HttpNotFound();
            }

            var culture = request?.Culture.Name;

            if (culture == null)
            {
                return HttpNotFound();
            }

            var robotsTxt = builder.BuildRobots(startNode, culture);

            if (string.IsNullOrWhiteSpace(robotsTxt) == true)
            {
                return HttpNotFound();
            }

            return Content(robotsTxt, "text/text", Encoding.UTF8);
        }
    }
}