using KZMaker.Core.Exceptions;
using KZMaker.Core.Models;
using KZMaker.Core.Services;
using KZMaker.Core.Services.CardProcessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace KZMaker.Tests.Services
{
    public class SaveCardHelperTests
    {
        [Fact]
        public void AddPointsToDraft_WithValidData_ShouldWork()
        {
            //Arrange
            var helper = new SaveCardHelper();
            string lines = "";

            List<Point> expected = new List<Point>()
            {
                new Point
                {
                    DisplayTime = "23:11",
                    Title = "Pionierka",
                    ZastepMember = "Jacek"
                },
                new Point
                {
                    DisplayTime = "13:31",
                    Title = "Budowa Igloo",
                    ZastepMember = "Mateusz"
                }
            };

            //Act
            helper.AddPointsToDraft(ref lines, expected);

            string[] splittedLines = lines.Split('*');

            //Assert
            for (int i = 0; i < expected.Count(); i++)
            {
                Assert.Equal($"{expected[i].DisplayTime}${expected[i].Title}${expected[i].ZastepMember}", splittedLines[i]);
            }
        }

        [Fact]
        public void AddPointsToDraft_WithNoPoints_ShouldReturnEmptyString()
        {
            //Arrange
            var helper = new SaveCardHelper();
            string lines = "";

            List<Point> expected = new List<Point>();

            //Act
            helper.AddPointsToDraft(ref lines, expected);

            //Assert
            Assert.True(string.IsNullOrEmpty(lines));
        }

        [Fact]
        public void AddRequiredItemsToDraft_WithValidData_ShouldWork()
        {
            //Arrange
            var helper = new SaveCardHelper();
            string lines = "";

            List<RequiredItem> expected = new List<RequiredItem>()
            {
                new RequiredItem(){ Item = "Nożyczki"},
                new RequiredItem(){ Item = "Igła i nitka"},
                new RequiredItem(){ Item = "Nóż"}
            };

            //Act
            helper.AddRequiredItemsToDraft(ref lines, expected);

            string[] splittedLines = lines.Split('*');

            //Assert
            for (int i = 0; i < expected.Count(); i++)
            {
                Assert.Equal(expected[i].Item, splittedLines[i]);
            }
        }

        [Fact]
        public void AddRequiredItemsToDraft_WithNoItems_ShouldReturnEmptyString()
        {
            //Arrange
            var helper = new SaveCardHelper();
            string lines = "";

            List<RequiredItem> expected = new List<RequiredItem>();

            //Act
            helper.AddRequiredItemsToDraft(ref lines, expected);

            //Assert
            Assert.True(string.IsNullOrEmpty(lines));
        }
        [Fact]
        public void CheckFileName_WithEmptyFileName_ShouldThrowException()
        {
            var helper = new SaveCardHelper();
            string fileName = "";

            Assert.Throws<NotGeneratedCardException>(() => helper.CheckFileName(fileName));
        }
    }
}
