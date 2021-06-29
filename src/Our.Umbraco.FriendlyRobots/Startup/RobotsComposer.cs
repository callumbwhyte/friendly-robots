using Our.Umbraco.FriendlyRobots.Builders;
using Our.Umbraco.FriendlyRobots.Composing;
using Our.Umbraco.FriendlyRobots.Configuration;
using Umbraco.Core;
using Umbraco.Core.Composing;

namespace Our.Umbraco.FriendlyRobots.Startup
{
    public class RobotsComposer : IUserComposer
    {
        public void Compose(Composition composition)
        {
            composition.Components().Append<RobotsComponent>();

            composition.Register(factory => RobotsConfiguration.Create(), Lifetime.Singleton);

            composition.RegisterRobots<RobotsBuilder>("robots.txt");
        }
    }
}