using System;
using Xunit;
using TriangleApp;

namespace TriangleApp.Tests
{
    public class TriangleTests
    {
        [Theory]
        [InlineData(3, 3, 3, TriangleType.Equilateral)]
        [InlineData(5, 5, 8, TriangleType.Isosceles)]
        [InlineData(3, 4, 5, TriangleType.Scalene)]
        [InlineData(1, 2, 3, TriangleType.NotTriangle)]  
        [InlineData(0, 4, 5, TriangleType.NotTriangle)]  
        public void DetermineTriangleType_ReturnsCorrectType(double a, double b, double c, TriangleType expected)
        {
            var result = Triangle.DetermineTriangleType(a, b, c);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(3, 4, 5, true)]
        [InlineData(1, 2, 3, false)]  
        [InlineData(0, 4, 5, false)] 
        [InlineData(-3, 4, 5, false)] 
        public void IsValidTriangle_ReturnsCorrectValidation(double a, double b, double c, bool expected)
        {
            var result = Triangle.IsValidTriangle(a, b, c);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(3, 4, 5, 6)]
        [InlineData(5, 5, 8, 12)]
        [InlineData(6, 6, 6, 15.588457268119896)]
        public void CalculateArea_ReturnsCorrectArea(double a, double b, double c, double expected)
        {
            var result = Triangle.CalculateArea(a, b, c);
            Assert.Equal(expected, result, 5); 
        }

        [Fact]
        public void CalculateArea_WithInvalidTriangle_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => Triangle.CalculateArea(1, 2, 3));
        }
    }
}
