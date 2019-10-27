using System;

namespace Our.Umbraco.FriendlyRobots.Configuration
{
    public class RobotsConfiguration
    {
        public string UserAgent { get; set; }

        public string[] Allow { get; set; }

        public string[] Disallow { get; set; }

        public string[] Sitemaps { get; set; }
    }
}