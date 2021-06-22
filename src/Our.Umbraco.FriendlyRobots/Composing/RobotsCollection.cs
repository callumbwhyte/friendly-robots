using System.Collections.Generic;
using Our.Umbraco.FriendlyRobots.Builders;
using Umbraco.Core.Composing;

namespace Our.Umbraco.FriendlyRobots.Composing
{
    public class RobotsCollection : Dictionary<string, IRobotsBuilder>, IBuilderCollection<IRobotsBuilder>
    {
        public RobotsCollection(IDictionary<string, IRobotsBuilder> collection)
            : base(collection)
        {

        }

        IEnumerator<IRobotsBuilder> IEnumerable<IRobotsBuilder>.GetEnumerator()
            => this.Values.GetEnumerator();
    }
}