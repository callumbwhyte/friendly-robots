using Umbraco.Core;
using Umbraco.Core.Composing;

namespace Our.Umbraco.FriendlyRobots.Startup
{
    public class RobotsRouteComposer : IUserComposer
    {
        public void Compose(Composition composition)
        {
            composition.Components().Insert<RobotsRouteComponent>();
        }
    }
}