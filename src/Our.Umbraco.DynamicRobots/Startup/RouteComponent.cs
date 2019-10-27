using System.Web.Routing;
using Our.Umbraco.DynamicRobots.Routing;
using Umbraco.Core.Composing;
using Umbraco.Web;

namespace Our.Umbraco.DynamicRobots.Startup
{
    internal class RouteComponet : IComponent
    {
        private readonly IUmbracoContextFactory _umbracoContextFactory;

        public RouteComponet(IUmbracoContextFactory umbracoContextFactory)
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