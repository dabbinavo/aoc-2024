using System.Reflection;
using AdventOfCode2024.Helpers;

namespace AdventOfCode2024.Puzzles;

public class RedNosedReports : IPuzzle
{
    public List<Report> reports = [];

    public async Task Prepare()
    {
        reports = await ParseInput("AdventOfCode2024.Resources.day._2.input");
    }

    public Task<string> SolvePart1()
    {
        var result = GetNumberOfSafeReports();
        return Task.FromResult($"The number of safe reports is {result}");
    }

    public Task<string> SolvePart2()
    {
        return Task.FromResult("Not implemented yet");
    }

    public static async Task<List<Report>> ParseInput(string uri, Assembly? assembly = null)
    {
        assembly ??= typeof(HistorianHysteria).Assembly;

        var input = await ResourceHelper.LoadResource(uri, assembly);

        var reports = input.Split("\n", StringSplitOptions.RemoveEmptyEntries);

        var result = new List<Report>();

        foreach (var report in reports)
        {
            var levels = report.Split(" ").Select(int.Parse).ToList();
            result.Add(new Report(levels));
        }

        return result;
    }

    public int GetNumberOfSafeReports()
    {
        int safeReportCount = 0;
        foreach (var report in reports)
        {
            var levels = report.Levels;
            var distances = levels
                .Zip(levels.Skip(1))
                .Select(x => x.Second - x.First);
            var isSafe = (distances.All(x => x >= 0) || distances.All(x => x <= 0)) && distances.All(x => Math.Abs(x) >= 1 && Math.Abs(x) <= 3);
            if (isSafe)
            {
                safeReportCount++;
            }
        }
        return safeReportCount;
    }
}

public record Report(List<int> Levels);