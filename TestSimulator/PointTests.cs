using Simulator;
using Simulator.Maps;

namespace TestSimulator
{
    public class PointTests
    {
        [Theory]
        [InlineData(0,   0, (Direction)0,  0, 1)]
        [InlineData(9,   9, (Direction)1, 10, 9)]
        [InlineData(10,  0, (Direction)2, 10, -1)]
        [InlineData(-2, -4, (Direction)3, -3, -4)]

        public void Next_ShouldReturnCorrectPoint(int x, int y, Direction direction, int a, int b)
        {
            //Arrange
            
            var point = new Point(x,  y);
            var expected = new Point(a, b);

            //Act
            var result = point.Next(direction);

            //Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData( 0,  0, (Direction)0,  1,  1)]
        [InlineData( 7,  9, (Direction)1,  8,  8)]
        [InlineData(10, -3, (Direction)2,  9, -4)]
        [InlineData(-2, -4, (Direction)3, -3, -3)]

        public void NextDiagonal_ShouldReturnCorrectPoint(int x, int y, Direction direction, int a, int b)
        {
            //Arrange

            var point1 = new Point(x, y);
            var expected = new Point(a, b);

            //Act
            var result = point1.NextDiagonal(direction);

            //Assert
            Assert.Equal(expected, result);
        }
    }
}
