using System.Reflection;
using System.Text.RegularExpressions;

namespace AdventOfCode2024.Puzzles;

public partial class ReconcileLocationLists : IPuzzle
{
    private List<int> List1 {get; set;} = [];

    private List<int> List2 {get; set;} = [];

    public async Task Prepare()
    {
        (List1, List2) = await LoadLists("AdventOfCode2024.Resources.day._1.input");
    }

    public Task<string> SolvePart1()
    {
        var result = CalculateTotalDistance(List1, List2);
        return Task.FromResult($"The total distance is {result}");
    }

    public Task<string> SolvePart2()
    {
        var result = CalculateSimilarityScore(List1, List2);
        return Task.FromResult($"The similarity score is {result}");
    }

    public static int CalculateTotalDistance(IList<int> list1, IList<int> list2)
    {
        return list1
            .Order()
            .Zip(list2.Order(), (a, b) => Math.Abs(a - b))
            .Sum();
    }

    public static int CalculateSimilarityScore(IList<int> list1, IList<int> list2)
    {
        var score = list1
            .Select(x => x * list2.Count(y => y == x))
            .Sum();

        return score;
    }

    
    public static async Task<(List<int>, List<int>)> LoadLists(string uri, Assembly? assembly = null)
    {
        assembly ??= typeof(ReconcileLocationLists).Assembly;
        
        await using var stream = assembly.GetManifestResourceStream(uri)
            ?? throw new Exception($"Resource {uri} not found.");
        
        using var reader = new StreamReader(stream);
        
        var input = await reader.ReadToEndAsync();

        var lines = input.Split("\n", StringSplitOptions.RemoveEmptyEntries);

        var list1 = new List<int>();
        var list2 = new List<int>();

        foreach (var line in lines)
        {
            var entries = TrimRegex().Split(line);
            list1.Add(int.Parse(entries[0].Trim()));
            list2.Add(int.Parse(entries[1].Trim()));
        }

        return (list1, list2);
    }

    [GeneratedRegex(@"\s+")]
    private static partial Regex TrimRegex();
}