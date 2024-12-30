using AdventOfCode2024.Puzzles;

namespace AdventOfCode2024Tests;

public class RedNosedReportsTests
{
    public static readonly List<Report> expectedReports = [
        new Report([7, 6, 4, 2, 1]),
        new Report([1, 2, 7, 8, 9]),
        new Report([9, 7, 6, 2, 1]),
        new Report([1, 3, 2, 4, 5]),
        new Report([8, 6, 4, 4, 1]),
        new Report([1, 3, 6, 7, 9])
    ];

    [Fact]
    public async Task ParseInputTest()
    {
        // Arrange
        var uri = "AdventOfCode2024Tests.Resources.day._2.input";

        // Act
        var reports = await RedNosedReports.ParseInput(uri, typeof(RedNosedReportsTests).Assembly);

        // Assert
        expectedReports
            .Zip(reports)
            .ToList()
            .ForEach(x =>
            {
                Assert.Equal(x.First.Levels, x.Second.Levels);
            });
    }

    [Fact]
    public void GetNumberOfSafeReportsTest()
    {
        var redNosedReports = new RedNosedReports() { reports = expectedReports };
        // Act
        var result = redNosedReports.GetNumberOfSafeReports();

        // Assert
        Assert.Equal(2, result);
    }
}