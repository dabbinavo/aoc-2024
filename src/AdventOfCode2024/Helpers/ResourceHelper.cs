using System.Reflection;

namespace AdventOfCode2024.Helpers;

public static class ResourceHelper
{
    public static async Task<string> LoadResource(string uri, Assembly assembly)
    {
        var stream = assembly.GetManifestResourceStream(uri);
        if (stream == null)
        {
            throw new ArgumentException($"Resource {uri} not found in assembly {assembly.FullName}");
        }

        using var reader = new StreamReader(stream);
        var content = await reader.ReadToEndAsync();
        return content;
    }
}