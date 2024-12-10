using Autofac;

namespace AdventOfCode2024.Puzzles;

public static class PuzzleBootStrapper
{
    public static void Register(ContainerBuilder builder)
    {
        builder.RegisterType<HistorianHysteria>().Named<IPuzzle>("1");
        builder.RegisterType<RedNosedReports>().Named<IPuzzle>("2");
    }
}