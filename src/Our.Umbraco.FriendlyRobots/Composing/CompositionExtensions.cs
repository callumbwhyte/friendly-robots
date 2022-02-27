using Our.Umbraco.FriendlyRobots.Builders;
using Umbraco.Core.Composing;

namespace Our.Umbraco.FriendlyRobots.Composing
{
    public static class CompositionExtensions
    {
        public static void RegisterRobots<T>(this Composition composition, string path)
            where T : IRobotsBuilder
        {
            composition.WithCollectionBuilder<RobotsCollectionBuilder>()
                .Add<T>(path);
        }

        public static void RemoveRobots(this Composition composition, string path)
        {
            composition.WithCollectionBuilder<RobotsCollectionBuilder>()
                .Remove(path);
        }
    }
}