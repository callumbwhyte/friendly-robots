using System.Web.Routing;
using Our.Umbraco.Extensions.Routing;
using Umbraco.Core.Composing;
using Umbraco.Web;

namespace Our.Umbraco.FriendlyRobots.Startup
{
    internal class RobotsRouteComponent : IComponent
    {
        private readonly IUmbracoContextFactory _umbracoContextFactory;

        public RobotsRouteComponent(IUmbracoContextFactory umbracoContextFactory)
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