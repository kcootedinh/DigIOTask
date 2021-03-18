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
            var entries = logData.Split("\n", StringSplitOptions.RemoveEmptyEntries);

            var ipAddresses = entries.Select(ParseIpAddress).ToArray();
            var uniqueIps = ipAddresses.Distinct().Count();

            var requestedUrls = entries
                .Select(ParseRequestedUrl)
                .GroupBy(url => url)
                .OrderBy(group => group.Count())
                .Take(3)
                .Select(group => group.Key);

            var mostActiveIps = ipAddresses
                .GroupBy(ipAddress => ipAddress)
                .OrderBy(group => group.Count())
                .Take(3)
                .Select(group => group.Key);

            return new HttpLogAnalytics
            {
                UniqueIps = uniqueIps,
                MostActiveIps = ImmutableList.CreateRange(mostActiveIps),
                MostVisitedUrls = ImmutableList.CreateRange(requestedUrls)
            };
        }

        private static string ParseRequestedUrl(string logEntry)
        {
            var firstQuote = logEntry.IndexOf("\"", StringComparison.Ordinal);
            var secondQuote = logEntry.IndexOf("\"", firstQuote + 1, StringComparison.Ordinal);
            var httpRequest = logEntry.Substring(firstQuote + 1, secondQuote - firstQuote - 1);

            var firstSpace = httpRequest.IndexOf(" ", StringComparison.Ordinal);
            var lastSpace = httpRequest.LastIndexOf(" ", StringComparison.Ordinal);
            var url = httpRequest.Substring(firstSpace + 1, lastSpace - firstSpace - 1);

            return url;
        }

        public static string ParseIpAddress(string logEntry)
        {
            return logEntry.Substring(0, logEntry.IndexOf(" ", StringComparison.Ordinal));
        }
    }
}