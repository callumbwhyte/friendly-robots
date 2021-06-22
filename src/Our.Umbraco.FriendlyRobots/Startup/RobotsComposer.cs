using Our.Umbraco.FriendlyRobots.Builders;
﻿using Our.Umbraco.FriendlyRobots.Configuration;
using Umbraco.Core;
using Umbraco.Core.Composing;

namespace Our.Umbraco.FriendlyRobots.Startup
{
    public class RobotsComposer : IUserComposer
    {
        public void Compose(Composition composition)
        {
            composition.Components().Append<RobotsRouteComponent>();

            composition.RegisterUnique<IRobotsBuilder, RobotsBuilder>();

            composition.Register(factory => RobotsConfiguration.Create());
        }
    }
}