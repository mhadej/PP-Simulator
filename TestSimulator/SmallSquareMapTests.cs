using Simulator;
using Simulator.Maps;

namespace TestSimulator;

public class SmallSquareMapTests
{
    [Fact]
    public void Constructor_ValidSize_ShouldSetSize()
    {
        // Arrange
        int size = 15;
        // Act
        var map = new SmallSquareMap(size);
        // Assert
        Assert.Equal(size, map.Size);
    }

    [Theory]
    [InlineData(23)]
    [InlineData(3)]
    public void
        Constructor_InvalidSize_ShouldThrowArgumentOutOfRangeException (int size)
    {
        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => new SmallSquareMap(size));
    }

    [Theory]
    [InlineData(19, 19, 20, true)]
    [InlineData(3, 4, 5, true)]
    [InlineData(20, 20, 20, false)]
    [InlineData(6, 1, 5, false)]
    public void Exist_ShouldReturnCorrectValue(int x, int y, int size, bool expected)
    {
        // Arrange
        var map = new SmallSquareMap(size);
        var point = new Point(x, y);
        // Act
        var result = map.Exist(point);
        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(5, 10, Direction.Up, 5, 11)]
    [InlineData(0, 0, Direction.Down, 0, 0)]
    [InlineData(0, 8, Direction.Left, 0, 8)]
    [InlineData(14, 10, Direction.Right, 14, 10)]
    [InlineData(5, 5, Direction.Left, 4, 5)]

    public void Next_ShouldReturnCorrectNextPoint(int x, int y, Direction direction, int a, int b)
    {
        // Arrange
        var map = new SmallSquareMap(15);
        var point = new Point(x, y);
        var expected = new Point(a, b);
        // Act
        var nextPoint = map.Next(point, direction);
        // Assert
        Assert.Equal(expected, nextPoint);
    }

    [Theory]
    [InlineData(5, 10, Direction.Up, 6, 11)]
    [InlineData(14, 10, Direction.Right, 14, 10)]
    [InlineData(0, 0, Direction.Down, 0, 0)]
    [InlineData(0, 8, Direction.Left, 0, 8)]
    public void NextDiagonal_ShouldReturnCorrectNextPoint(int x, int y, Direction direction, int a, int b)
    {
        // Arrange
        var map = new SmallSquareMap(15);
        var point = new Point(x, y);
        var expected = new Point(a, b);
        // Act
        var nextPoint = map.NextDiagonal(point, direction);
        // Assert
        Assert.Equal(expected, nextPoint);
    }
}