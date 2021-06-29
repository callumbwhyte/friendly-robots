using Our.Umbraco.Extensions.Composing;
using Our.Umbraco.FriendlyRobots.Builders;
using Umbraco.Core.Composing;

namespace Our.Umbraco.FriendlyRobots.Composing
{
    internal class RobotsCollectionBuilder : LazyKeyValueCollectionBuilder<RobotsCollectionBuilder, RobotsCollection, IRobotsBuilder>
    {
        protected override Lifetime CollectionLifetime => Lifetime.Request;
    }
}