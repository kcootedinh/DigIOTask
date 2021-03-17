using System;
using System.Collections.Immutable;
using System.Linq;

namespace HttpLogParser.ConsoleApp
{
    public class HttpLogAnalytics
    {
        public int UniqueIps { get; private init; }
        public ImmutableList<string> MostActiveIps { get; private init; }
        public ImmutableList<string> MostVisitedUrls { get; private init; }

        public static HttpLogAnalytics Parse(string logData)
        {
            var entries = logData.Split("\n", StringSplitOptions.RemoveEmptyEntries)
                .Select(entry => entry.Substring(0, entry.IndexOf(" ", StringComparison.Ordinal)))
                .ToArray();
            var uniqueIps = entries.Distinct().Count();

            return new HttpLogAnalytics
            {
                UniqueIps = uniqueIps,
                MostActiveIps = ImmutableList<string>.Empty,
                MostVisitedUrls = ImmutableList<string>.Empty
            };
        }
    }
}