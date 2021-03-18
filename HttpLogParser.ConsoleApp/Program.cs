using System;
using System.IO;
using HttpLogParser.ConsoleApp;

if (args.Length == 0)
{
    Console.WriteLine("Please specify an absolute path to a log file");
    return;
}

var logData = File.ReadAllText(args[0]);
var analytics = HttpLogAnalytics.Parse(logData);

Console.WriteLine($"Unique IP addresses: {analytics.UniqueIps} ");
Console.WriteLine($"Most active IP addresses: {Environment.NewLine}" +
                  $"* {analytics.MostActiveIps[0]} {Environment.NewLine}" +
                  $"* {analytics.MostActiveIps[1]} {Environment.NewLine}" +
                  $"* {analytics.MostActiveIps[2]} {Environment.NewLine}");
Console.WriteLine($"Most visited URLs: {Environment.NewLine}" +
                  $"* {analytics.MostVisitedUrls[0]} {Environment.NewLine}" +
                  $"* {analytics.MostVisitedUrls[1]} {Environment.NewLine}" +
                  $"* {analytics.MostVisitedUrls[2]} {Environment.NewLine}");