using System;
using System.Collections.Generic;
using Our.Umbraco.Extensions.Composing;
using Our.Umbraco.FriendlyRobots.Builders;

namespace Our.Umbraco.FriendlyRobots.Composing
{
    public class RobotsCollection : LazyKeyValueCollection<IRobotsBuilder>
    {
        private IDictionary<string, Lazy<IRobotsBuilder>> _collection;

        public RobotsCollection(IDictionary<string, Lazy<IRobotsBuilder>> collection)
            : base(collection)
        {
            _collection = collection;
        }

        public IEnumerable<string> Paths => _collection.Keys;
    }
}