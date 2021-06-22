using System;
using System.Collections.Generic;
using System.Linq;
using Our.Umbraco.FriendlyRobots.Builders;
using Umbraco.Core;
using Umbraco.Core.Composing;

namespace Our.Umbraco.FriendlyRobots.Composing
{
    internal class RobotsCollectionBuilder : CollectionBuilderBase<RobotsCollectionBuilder, RobotsCollection, IRobotsBuilder>
    {
        private readonly IDictionary<string, Type> _paths;

        public RobotsCollectionBuilder()
        {
            _paths = new Dictionary<string, Type>();
        }

        public void Add<T>(string path)
            where T : IRobotsBuilder
        {
            _paths[path] = typeof(T);

            Configure(types => types.Add(typeof(T)));
        }

        public void Remove(string path)
        {
            _paths.Remove(path);
        }

        protected override Lifetime CollectionLifetime => Lifetime.Request;

        public override RobotsCollection CreateCollection(IFactory factory)
        {
            var collection = _paths.ToDictionary(x => x.Key, x => CreateItem(factory, x.Value));

            return factory.CreateInstance<RobotsCollection>(collection);
        }
    }
}