using System.Web.Routing;
using Our.Umbraco.Extensions.Routing;
using Our.Umbraco.FriendlyRobots.Composing;
using Umbraco.Core;
using Umbraco.Core.Composing;
using Umbraco.Web;

namespace Our.Umbraco.FriendlyRobots.Startup
{
    internal class RobotsComponent : IComponent
    {
        private readonly RobotsCollection _robotsCollection;
        private readonly IUmbracoContextFactory _contextFactory;

        public RobotsComponent(RobotsCollection robotsCollection, IUmbracoContextFactory contextFactory)
        {
            _robotsCollection = robotsCollection;
            _contextFactory = contextFactory;
        }

        public void Initialize()
        {
            foreach (var path in _robotsCollection.Paths)
            {
                var values = new
                {
                    controller = "Robots",
                    action = "RenderRobots"
                };

                var routeHandler = new RootNodeByDomainRouteHandler(_contextFactory);

                RouteTable.Routes.MapUmbracoRoute(path.ToSafeAlias(), path, values, routeHandler);
            }
        }

        public void Terminate()
        {

        }
    }
}