using System.Web.Routing;
using Our.Umbraco.FriendlyRobots.Routing;
using Umbraco.Core.Composing;
using Umbraco.Web;

namespace Our.Umbraco.FriendlyRobots.Startup
{
    internal class RobotsRouteComponet : IComponent
    {
        private readonly IUmbracoContextFactory _umbracoContextFactory;

        public RobotsRouteComponet(IUmbracoContextFactory umbracoContextFactory)
        {
            _umbracoContextFactory = umbracoContextFactory;
        }

        public void Initialize()
        {
            RouteTable.Routes.MapUmbracoRoute(
                Constants.RobotsRouteName,
                Constants.RobotsRouteUrl,
                new
                {
                    controller = "Robots",
                    action = "RenderRobots"
                },
                new RootNodeByDomainRouteHandler(_umbracoContextFactory)
            );
        }

        public void Terminate()
        {

        }
    }
}