using Umbraco.Core.Models.PublishedContent;

namespace Our.Umbraco.FriendlyRobots.Builders
{
    public interface IRobotsBuilder
    {
        string BuildRobots(IPublishedContent startNode);
    }
}