using System.Reflection;
using System.Text.RegularExpressions;

namespace AdventOfCode2024.Missions;

public partial class ReconcileLocationLists : IMission
{
    public async Task<string> Execute()
    {
        var (list1, list2) = await FetchInput("AdventOfCode2024.Resources.day._1.input");
        var result = ReconcileLists(list1, list2);
        
        return $"The result is {result}";
    }

    public static async Task<(IList<int> list1, IList<int> list2)> FetchInput(string uri, Assembly? assembly = null)
    {
        assembly ??= typeof(ReconcileLocationLists).Assembly;
        
        // print all resources
        foreach (var name in assembly.GetManifestResourceNames())
        {
            Console.WriteLine(name);
        }

        await using var stream = assembly.GetManifestResourceStream(uri)
            ?? throw new Exception($"Resource {uri} not found.");
        
        using var reader = new StreamReader(stream);
        
        var input = await reader.ReadToEndAsync();

        var lines = input.Split("\n", StringSplitOptions.RemoveEmptyEntries);

        List<int> list1 = [];
        List<int> list2 = [];

        foreach (var line in lines)
        {
            var entries = TrimRegex().Split(line);
            list1.Add(int.Parse(entries[0].Trim()));
            list2.Add(int.Parse(entries[1].Trim()));
        }

        return (list1, list2);
    }

    public static int ReconcileLists(IList<int> list1, IList<int> list2)
    {
        return list1
            .Order()
            .Zip(list2.Order(), (a, b) => Math.Abs(a - b))
            .Sum();
    }

    [GeneratedRegex(@"\s+")]
    private static partial Regex TrimRegex();
}