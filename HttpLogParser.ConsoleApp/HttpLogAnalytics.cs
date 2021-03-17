using System;
using System.Collections.Immutable;

namespace HttpLogParser.ConsoleApp
{
    public class HttpLogAnalytics
    {
        public int UniqueIps { get; }
        public ImmutableList<string> MostActiveIps { get; }
        public ImmutableList<string> MostVisitedUrls { get; }

        public static HttpLogAnalytics Parse(string logData)
        {
            throw new NotImplementedException();
        }
    }
}