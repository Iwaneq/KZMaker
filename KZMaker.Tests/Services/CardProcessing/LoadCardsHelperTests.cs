using Autofac.Extras.Moq;
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
    public class LoadCardsHelperTests
    {
        [Fact]
        public void AddPointsToCard_WithValidData_ShouldWork ()
        {
            //Arrange
            var helper = new LoadCardsHelper();
            Card card = new Card();

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

            string[] points = new string[]
            {
                $"{expected[0].DisplayTime}${expected[0].Title}${expected[0].ZastepMember}",
                $"{expected[1].DisplayTime}${expected[1].Title}${expected[1].ZastepMember}"
            };

            //Act
            helper.AddPointsToCard(card, points);

            //Assert
            for(int i =0; i<expected.Count(); i++)
            {
                Assert.Equal(expected[i].DisplayTime, card.Points[i].DisplayTime);
                Assert.Equal(expected[i].Title, card.Points[i].Title);
                Assert.Equal(expected[i].ZastepMember, card.Points[i].ZastepMember);
            }
        }

        [Fact]
        public void AddPointsToCard_WithNoPoints_ShouldReturnEmptyList()
        {
            //Arrange
            var helper = new LoadCardsHelper();
            Card card = new Card();

            string[] points = new string[] 
            { 
                ""
            };

            //Act
            helper.AddPointsToCard(card, points);

            //Assert
            Assert.True(card.Points.Count == 0);
        }

        [Fact]
        public void AddRequiredItemsToCard_WithValidData_ShouldWork()
        {
            //Arrange
            var helper = new LoadCardsHelper();
            Card card = new Card();

            List<RequiredItem> expected = new List<RequiredItem>()
            {
                new RequiredItem(){ Item = "Nożyczki"},
                new RequiredItem(){ Item = "Igła i nitka"},
                new RequiredItem(){ Item = "Nóż"}
            };

            string[] items = new string[]
            {
                expected[0].Item,
                expected[1].Item,
                expected[2].Item
                
            };

            //Act
            helper.AddRequiredItemsToCard(card, items);

            //Assert
            for(int i = 0; i<expected.Count(); i++)
            {
                Assert.Equal(expected[i].Item, card.RequiredItems[i].Item);
            }
        }

        [Fact]
        public void AddRequiredItemsToCard_WithNoItems_ShouldReturnEmptyList()
        {
            var helper = new LoadCardsHelper();
            Card card = new Card();

            string[] items = new string[]
            {
                ""
            };

            //Act
            helper.AddRequiredItemsToCard(card, items);

            //Assert
            Assert.True(card.RequiredItems.Count == 0);
        }
    }
}
