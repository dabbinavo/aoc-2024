using Autofac;

namespace AdventOfCode2024.Missions;

public static class MissionBootStrapper
{
    public static void Register(ContainerBuilder builder)
    {
        builder.RegisterType<ReconcileLocationLists>().Named<IMission>("1");
    }
}