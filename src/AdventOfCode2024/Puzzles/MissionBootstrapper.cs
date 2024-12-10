using Autofac;

namespace AdventOfCode2024.Puzzles;

public static class MissionBootStrapper
{
    public static void Register(ContainerBuilder builder)
    {
        builder.RegisterType<ReconcileLocationLists>().Named<IPuzzle>("1");
    }
}