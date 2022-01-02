using Autofac.Extras.Moq;
using KZMaker.Core.Models;
using KZMaker.Core.Services;
using KZMaker.Core.Services.CardProcessing.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace KZMaker.Tests.Services
{
    public class CreateCardServiceTests
    {
        [Fact]
        public void CreateCard_WithValidData_ShouldCallMethodsOnceAndWork()
        {
            using(var mock = AutoMock.GetLoose())
            {
                string zastep = "Zastep";

                DateTime date = DateTime.Now;

                string place = "Kaptur";

                List<Point> points = new List<Point>()
                {
                    new Point()
                    {
                        Time = DateTime.Now,
                        Title = "Pionierka",
                        ZastepMember = "Jacek"
                    }
                };

                List<RequiredItem> requiredItems = new List<RequiredItem>()
                {
                    new RequiredItem()
                    {
                        Item = "Nożyczki"
                    }
                };

                var service = mock.Create<CreateCardService>();

                var card = service.CreateCard(zastep, date, place, points, requiredItems);

                mock.Mock<ICardGenerator>()
                    .Verify(x => x.CleanCard(), Times.Once);

                mock.Mock<ICardGenerator>()
                    .Verify(x => x.DrawZastep(zastep), Times.Once);

                mock.Mock<ICardGenerator>()
                    .Verify(x => x.DrawDate(date), Times.Once);

                mock.Mock<ICardGenerator>()
                    .Verify(x => x.DrawPlace(place), Times.Once);

                mock.Mock<ICardGenerator>()
                    .Verify(x => x.DrawPoints(points), Times.Once);

                mock.Mock<ICardGenerator>()
                    .Verify(x => x.DrawRequiredItems(requiredItems), Times.Once);

                Assert.True(card != null);
            }
        }


        /// <summary>
        /// Everything should work. Methods with invalid (null or empty) parameters shouldn't be called, rest should work.
        /// </summary>
        [Fact]
        public void CreateCard_WithInvalidData_ShouldNotCallMethodsWithInvalidParameters()
        {
            using (var mock = AutoMock.GetLoose())
            {
                string zastep = "";

                DateTime date = DateTime.Now;

                string place = "";

                List<Point> points = new List<Point>();

                List<RequiredItem> requiredItems = new List<RequiredItem>();

                var service = mock.Create<CreateCardService>();

                var card = service.CreateCard(zastep, date, place, points, requiredItems);

                mock.Mock<ICardGenerator>()
                    .Verify(x => x.CleanCard(), Times.Exactly(1));

                mock.Mock<ICardGenerator>()
                    .Verify(x => x.DrawZastep(zastep), Times.Exactly(0));

                mock.Mock<ICardGenerator>()
                    .Verify(x => x.DrawDate(date), Times.Exactly(1));

                mock.Mock<ICardGenerator>()
                    .Verify(x => x.DrawPlace(place), Times.Exactly(0));

                mock.Mock<ICardGenerator>()
                    .Verify(x => x.DrawPoints(points), Times.Exactly(0));

                mock.Mock<ICardGenerator>()
                    .Verify(x => x.DrawRequiredItems(requiredItems), Times.Exactly(0));

                Assert.True(card != null);
            }
        }
    }
}
