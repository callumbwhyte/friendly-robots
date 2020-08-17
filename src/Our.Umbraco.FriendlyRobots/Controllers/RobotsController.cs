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
            var startNode = UmbracoContext.PublishedRequest.PublishedContent;

            if (startNode == null)
            {
                return HttpNotFound();
            }

            var robotsTxt = _robotsBuilder.BuildRobots(startNode);

            if (string.IsNullOrWhiteSpace(robotsTxt) == true)
            {
                return HttpNotFound();
            }

            return Content(robotsTxt, "text/text", Encoding.UTF8);
        }
    }
}