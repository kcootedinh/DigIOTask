using System.Threading.Tasks;
using HttpLogParser.ConsoleApp;
using Shouldly;
using Xunit;

namespace HttpLogParser.Tests
{
    public class HttpLogParsingTests
    {
        [Fact]
        public async Task ExampleDataLog_UniqueIPAddresses_EqualsEleven()
        {
            //11
            var logTestData = await Resources.GetLogTestData();
            var results = HttpLogAnalytics.Parse(logTestData);
            results.UniqueIps.ShouldBe(11);
        }

        [Fact]
        public async Task ExampleDataLog_MostActiveIps_EqualsThree()
        {
            //168.41.191.40
            //50.112.00.11
            //177.71.128.21
            //72.44.32.10
            var logTestData = await Resources.GetLogTestData();
            var results = HttpLogAnalytics.Parse(logTestData);
            results.MostActiveIps.Count.ShouldBe(3);
        }

        [Fact]
        public async Task ExampleDataLog_MostVisited_EqualsThree()
        {
            // /docs/manage-websites/
            // /faq/
            var logTestData = await Resources.GetLogTestData();
            var results = HttpLogAnalytics.Parse(logTestData);
            results.MostVisitedUrls.Count.ShouldBe(3);
        }
    }
}