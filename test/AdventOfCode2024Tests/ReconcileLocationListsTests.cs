using AdventOfCode2024.Puzzles;

namespace AdventOfCode2024Tests;

public class ReconcileLocationListsTests
{
    
    public static readonly List<int> expectedList1 = [3, 4, 2, 1, 3, 3];
    public static readonly List<int> expectedList2 = [4, 3, 5, 3, 9, 3];

    [Fact]
    public async Task FetchInputTest()
    {
        // Arrange
        var uri = "AdventOfCode2024Tests.Resources.day._1.input";

        // Act
        var (list1, list2) = await ReconcileLocationLists.LoadLists(uri, typeof(ReconcileLocationListsTests).Assembly);

        // Assert
        Assert.Equal(expectedList1, list1);
        Assert.Equal(expectedList2, list2);
    }

    [Fact]
    public void ReconcileListsTest()
    {
        // Act
        var result = ReconcileLocationLists.CalculateTotalDistance(expectedList1, expectedList2);

        // Assert
        Assert.Equal(11, result);
    }

    [Fact]
    public void CalculateSimilarityScoreTest()
    {
        // Act
        var result = ReconcileLocationLists.CalculateSimilarityScore(expectedList1, expectedList2);

        // Assert
        Assert.Equal(31, result);
    }
}
