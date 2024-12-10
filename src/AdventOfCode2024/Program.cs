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

        PuzzleBootStrapper.Register(builder);

        var container = builder.Build();

        while (true)
        {
            Console.Write("Enter the puzzle number [1...24] or 'exit': ");
            var puzzleNumber = Console.ReadLine();

            if (puzzleNumber == null)
            {
                continue;
            }

            if (puzzleNumber == "exit")
            {
                break;
            }

            if (container.TryResolveNamed<IPuzzle>(puzzleNumber, out var puzzle))
            {
                await puzzle.Prepare();

                var solution1 = await puzzle.SolvePart1();
                Console.WriteLine($"Part 1: {solution1}");

                var solution2 = await puzzle.SolvePart2();
                Console.WriteLine($"Part 2: {solution2}");
            }
            else
            {
                Console.WriteLine("Puzzle not found.");
            }
            Console.WriteLine();
        }

        return 0;
    }
}
