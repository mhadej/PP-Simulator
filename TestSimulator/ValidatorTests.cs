using Simulator;

namespace TestSimulator
{
    public class ValidatorTests
    {
        [Theory]
        [InlineData( 1,  1, 10,  1)]
        [InlineData(11,  1, 10, 10)]
        [InlineData(-1,  1, 10,  1)]
        [InlineData(50,  1, 50, 50)]
        [InlineData(-1, 20, 30, 20)]
        [InlineData( 5,  2,  9,  5)]

        public void Limiter_ShouldReturnCorrectValues(int input, int min, int max, int expected)
        {
            //Arrange
            //Act
            var result = Validator.Limiter(input, min, max);

            //Assert
            Assert.Equal(expected, result);
        }


        [Theory]
        [InlineData("Shrek", "Shrek", 1, 10, '3')]
        [InlineData("      ", "$$$", 3, 5, '$')]
        [InlineData("Puss in Boots – a clever and brave cat", "Puss in Boots – a cl", 4, 20, '%')]
        [InlineData("   ogre", "Ogre", 4, 6, ' ')]
        [InlineData("Dracula the Vampire", "D", 1, 1, 'O')]
        [InlineData("a                            troll name", "A?????????", 10, 15, '?')]

        public void Shortener_ShouldReturnCorrectValues(string input, string expected, int min, int max, char placeholder)
        {
            //Arrange
            //Act
            var result = Validator.Shortener(input, min, max, placeholder);

            //Assert
            Assert.Equal(expected, result);
        }
    }
}
