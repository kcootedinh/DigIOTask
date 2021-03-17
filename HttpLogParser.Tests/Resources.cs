using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace HttpLogParser.Tests
{
    public static class Resources
    {
        private const string LogResource = "HttpLogParser.Tests.programming-task-example-data.log";

        private static async Task<string> GetResourceString(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();

            await using var stream = assembly.GetManifestResourceStream(resourceName);
            using var reader = new StreamReader(stream ?? throw new InvalidOperationException());

            return await reader.ReadToEndAsync();
        }

        public static async Task<string> GetLogTestData() => await GetResourceString(LogResource);
    }
}