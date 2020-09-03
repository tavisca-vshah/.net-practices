using System;
using CovrletDemo;
using Xunit;

namespace CovrletDemoTests
{
    public class FizzBuzzGeneratorTest 
    {
        [Fact]
        public void ShouldRaiseErrorWhenNumberIsNegative()
        {
            // Arrange
            int input = -100;

            // Act
            Action act  = () => FizzBuzzGenerator.Generate(input);

            // Assert
            Assert.Throws<ArgumentException>(act);
        }
    }
}
