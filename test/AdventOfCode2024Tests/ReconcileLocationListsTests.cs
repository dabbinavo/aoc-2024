using AdventOfCode2024.Missions;

namespace AdventOfCode2024Tests;

public class ReconcileLocationListsTests
{
    private readonly List<int> list1 = [3, 4, 2, 1, 3, 3];
    private readonly List<int> list2 = [4, 3, 5, 3, 9, 3];

    [Fact]
    public async Task FetchInputTest()
    {
        // Arrange
        var uri = "AdventOfCode2024Tests.Resources.day._1.input";

        // Act
        var result = await ReconcileLocationLists.FetchInput(uri, typeof(ReconcileLocationListsTests).Assembly);

        // Assert
        Assert.Equal(list1, result.list1);
        Assert.Equal(list2, result.list2);
    }

    [Fact]
    public void ReconcileListsTest()
    {
        // Act
        var result = ReconcileLocationLists.ReconcileLists(list1, list2);

        // Assert
        Assert.Equal(11, result);
    }
}
