// See https://aka.ms/new-console-template for more information

using AdventOfCode2024.Puzzles;
using Autofac;

namespace AdventOfCode2024;

class Program
{
    static async Task<int> Main(string[] args)
    {
        Console.WriteLine("Welcome to Advent of Code 2024!");
        Console.WriteLine("-------------------------------");
        Console.WriteLine();

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

            if (container.TryResolveNamed<IPuzzle>(missionNumber, out var mission))
            {
                await mission.Prepare();

                var solution1 = await mission.SolvePart1();
                Console.WriteLine($"Part 1: {solution1}");

                var solution2 = await mission.SolvePart2();
                Console.WriteLine($"Part 2: {solution2}");
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
