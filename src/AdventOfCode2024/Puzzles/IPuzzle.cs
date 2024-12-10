namespace AdventOfCode2024.Puzzles;

public interface IPuzzle
{
    Task Prepare();
    
    Task<string> SolvePart1();

    Task<string> SolvePart2();
}