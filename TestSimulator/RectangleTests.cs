using Simulator;
using System.Numerics;
using Xunit.Sdk;

namespace TestSimulator
{
    public class RectangleTests
    {
        [Fact]
        public void Constructor_ValidCoordinates_ShouldSetCorners()
        {
            //Arrange
            int x1 = 0, y1 = 0, x2 = 5, y2 = 5;

            //Act
            var rec = new Rectangle(x1, y1, x2, y2);

            //Assert
            Assert.Equal((rec.X1, rec.Y1, rec.X2, rec.Y2), (x1, y1, x2, y2));
        }

        [Fact]
        public void Constructor_ValidPoints_ShouldSetCorners()
        {
            //Arrange
            Point p1 = new(0 , 0), p2 = new(2, 2);

            //Act
            var rec = new Rectangle(p1, p2);

            //Assert
            Assert.Equal((rec.X1, rec.Y1, rec.X2, rec.Y2), (p1.X, p1.Y, p2.X, p2.Y));
        }

        [Theory]
        [InlineData(2, 2, 0, 0)]
        [InlineData(-3, -2, -20, -19)]
        [InlineData(0, 0, -3, -3)]
        [InlineData(2, 0, -2, -1)]

        public void Constructor_PointsInWrongOrder_ShouldReturnProperPoints(int a, int b, int c, int d)
        {
            //Arrange
            //Act
            var rec = new Rectangle(a, b, c, d);

            //Assert
            Assert.Equal((c, d, a, b), (rec.X1, rec.Y1, rec.X2, rec.Y2));

        }

        [Theory]
        [InlineData(0, 0, 10, 0)]
        [InlineData(0, 10, 10, 10)]
        [InlineData(0, -7, 10, -7)]

        public void Constructor_InvalidPoints_ShouldThrowException(int x1, int y1, int x2, int y2)
        {
            var p1 = new Point(x1, y1);
            var p2 = new Point(x2, y2);

            Assert.Throws<ArgumentException>(() => new Rectangle(p1, p2));
        }

        [Theory]
        [InlineData(0, 0, 2, 2, 0, 0, true)]
        [InlineData(0, 0, 2, 2, -1, 0, false)]
        [InlineData(0, 0, 2, 2, 1, 1, true)]
        [InlineData(-10, -10, -5, -5, -7, -7, true)]

        public void Contains_ShouldReturnIfPointIsInRectangle(int x1, int y1, int x2, int y2, int a, int b, bool expected)
        {
            var rec = new Rectangle(x1, y1, x2, y2);
            var p = new Point(a, b);

            var result = rec.Contains(p);

            Assert.Equal(result, expected);
        }
    }
}
