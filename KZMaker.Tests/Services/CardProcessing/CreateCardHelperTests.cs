using KZMaker.Core.Models;
using KZMaker.Core.Services.CardProcessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace KZMaker.Tests.Services
{
    public class CreateCardHelperTests
    {
        [Fact]
        public void AddRequiredItemsToCard_WithValidData_ShouldWork()
        {
            //Arrange
            var helper = new CreateCardHelper();

            List<RequiredItem> expected = new List<RequiredItem>()
            {
                new RequiredItem(){ Item = "Nożyczki"},
                new RequiredItem(){ Item = "Igła i nitka"},
                new RequiredItem(){ Item = "Nóż"}
            };

            string lines = "";

            //Act
            helper.AddRequiredItemsToCard(ref lines, expected);

            string[] splittedLines = lines.Split(", ");

            //Assert
            for (int i = 0; i < expected.Count(); i++)
            {
                Assert.Equal(expected[i].Item, splittedLines[i]);
            }
        }

        [Fact]
        public void AddRequiredItemsToCard_WithNoItems_ShouldReturnEmptyString()
        {
            //Arrange
            var helper = new CreateCardHelper();

            List<RequiredItem> expected = new List<RequiredItem>();

            string lines = "";

            //Act
            helper.AddRequiredItemsToCard(ref lines, expected);

            //Assert
            Assert.True(string.IsNullOrEmpty(lines));
        }

        [Theory]
        [InlineData(1, "Stycznia")]
        [InlineData(2, "Lutego")]
        [InlineData(3, "Marca")]
        [InlineData(4, "Kwietnia")]
        [InlineData(5, "Maja")]
        [InlineData(6, "Czerwca")]
        [InlineData(7, "Lipca")]
        [InlineData(8, "Sierpnia")]
        [InlineData(9, "Września")]
        [InlineData(10, "Października")]
        [InlineData(11, "Listopada")]
        [InlineData(12, "Grudnia")]
        public void GetMonthString_WithValidData_ShouldWork(int month, string expected)
        {
            //Arrange
            var helper = new CreateCardHelper();

            //Act
            var actual = helper.GetMonthString(month);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(13)]
        public void GetMonthString_WithInvalidData_ShouldThrowException(int month)
        {
            var helper = new CreateCardHelper();

            Assert.Throws<ArgumentOutOfRangeException>("month", () => helper.GetMonthString(month));
        }
    }
}
