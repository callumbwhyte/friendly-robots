using System.Text;
using System.Web.Mvc;
using System.Web.Routing;
using Our.Umbraco.FriendlyRobots.Builders;
using Our.Umbraco.FriendlyRobots.Composing;
using Umbraco.Web.Mvc;

namespace Our.Umbraco.FriendlyRobots.Controllers
{
#if !DEBUG
    [OutputCache(Duration = 900, VaryByCustom = "url", VaryByParam = "*")]
#endif
    public class RobotsController : RenderMvcController
    {
        private readonly RobotsCollection _robotsCollection;

        public RobotsController(RobotsCollection robotsCollection)
        {
            _robotsCollection = robotsCollection;
        }

        public ActionResult RenderRobots()
        {
            var route = ((Route)RouteData.Route).Url;

            if (_robotsCollection.TryGetValue(route, out IRobotsBuilder builder) == false)
            {
                return HttpNotFound();
            }

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