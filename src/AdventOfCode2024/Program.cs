// See https://aka.ms/new-console-template for more information

using AdventOfCode2024.Missions;
using Autofac;

namespace AdventOfCode2024;

class Program
{
    static async Task<int> Main(string[] args)
    {
        Console.WriteLine("Welcome to Advent of Code 2024!");
        Console.WriteLine("-------------------------------");

        var builder = new ContainerBuilder();

        MissionBootStrapper.Register(builder);

        var container = builder.Build();

        while (true)
        {
            Console.Write("Enter the mission number [1...24] or 'exit': ");
            var missionNumber = Console.ReadLine();

            if (missionNumber == null)
            {
                continue;
            }

            if (missionNumber == "exit")
            {
                break;
            }

            if (container.TryResolveNamed<IMission>(missionNumber, out var mission))
            {
                var output = await mission.Execute();
                Console.WriteLine(output);
            }
            else
            {
                Console.WriteLine("Mission not found.");
            }
            Console.WriteLine();
        }

        return 0;
    }
}
