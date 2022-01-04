using Autofac.Extras.Moq;
using KZMaker.Core.Models;
using KZMaker.Core.ViewModels;
using KZMaker.Tests.Fake_Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace KZMaker.Tests.ViewModels
{
    public class CreateCardViewModelTests
    {
        [Fact]
        public void UpdateViewModel_WithPopulatedCard_ShouldPopulateProperties()
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange
                Card card = GetCard();

                var viewModel = mock.Create<CreateCardViewModel>();

                //Act
                viewModel.UpdateViewModel(card);

                //Assert
                Assert.Equal(card.Zastep, viewModel.Zastep);
                Assert.Equal(card.Date, viewModel.Date);
                Assert.Equal(card.Place, viewModel.Place);

                Assert.True(viewModel.Points.Count() != 0);
                Assert.True(viewModel.RequiredItems.Count() != 0);

                Assert.True(viewModel.Points != null);
                Assert.True(viewModel.RequiredItems != null);

                Assert.Equal(card.Points, viewModel.Points);
                Assert.Equal(card.RequiredItems, viewModel.RequiredItems);
            }
        }

        [Fact]
        public void UpdateViewModel_WithNonPopulatedCard_ShouldNotPopulateProperties()
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange
                Card card = GetEmptyCard();

                var viewModel = mock.Create<CreateCardViewModel>();

                //Act
                viewModel.UpdateViewModel(card);

                //Assert
                Assert.True(string.IsNullOrEmpty(viewModel.Zastep));
                Assert.Equal(card.Date, viewModel.Date);
                Assert.True(string.IsNullOrEmpty(viewModel.Place));

                Assert.True(viewModel.Points.Count() == 0);
                Assert.True(viewModel.RequiredItems.Count() == 0);

                Assert.True(viewModel.Points != null);
                Assert.True(viewModel.RequiredItems != null);
            }
        }

        [Fact]
        public void UpdateViewModel_WithoutLists_ShouldNotSetPropertiesToNull()
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange
                Card card = GetCardWithoutLists();

                var viewModel = mock.Create<CreateCardViewModel>();

                //Act
                viewModel.UpdateViewModel(card);

                //Assert
                Assert.True(string.IsNullOrEmpty(viewModel.Zastep));
                Assert.Equal(card.Date, viewModel.Date);
                Assert.True(string.IsNullOrEmpty(viewModel.Place));

                Assert.True(viewModel.Points.Count() == 0);
                Assert.True(viewModel.RequiredItems.Count() == 0);

                Assert.True(viewModel.Points != null);
                Assert.True(viewModel.RequiredItems != null);
            }
        }

        [Fact]
        public void ChangeCommand_WithValidCommand_ShouldWork()
        {
            using(var mock = AutoMock.GetLoose())
            {
                var viewModel = mock.Create<CreateCardViewModel>();

                viewModel.ChangeCommand(new FakeSaveDraftCommand());

                Assert.IsType<FakeSaveDraftCommand>(viewModel.SaveDraftCommand);
            }
        }

        [Fact]
        public void ChangeCommand_WithInvalidCommand_ShouldNotChangeCommand()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var viewModel = mock.Create<CreateCardViewModel>();

                viewModel.SaveDraftCommand = new FakeSaveDraftCommand();

                viewModel.ChangeCommand(null);

                Assert.NotNull(viewModel.SaveDraftCommand);
            }
        }

        private Card GetCardWithoutLists()
        {
            return new Card
            {
                Zastep = "",
                Date = DateTime.Now,
                Place = "",
                Points = null,
                RequiredItems = null
            };
        }

        private Card GetEmptyCard()
        {
            return new Card
            {
                Zastep = "",
                Date = DateTime.Now,
                Place = "",
                Points = new List<Point>(),
                RequiredItems = new List<RequiredItem>()
            };
        }

        private Card GetCard()
        {
            return new Card
            {
                Zastep = "Salamandra",
                Date = DateTime.Parse("2021 - 10 - 10 00:00:00"),
                Place = "Michałów",
                Points = GetPoints(),
                RequiredItems = GetRequiredItems()
            };
        }
        private List<Point> GetPoints()
        {
            return new List<Point>()
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
        }
        private List<RequiredItem> GetRequiredItems()
        {
            return new List<RequiredItem>()
            {
                new RequiredItem(){ Item = "Nożyczki"},
                new RequiredItem(){ Item = "Igła i nitka"},
                new RequiredItem(){ Item = "Nóż"}
            };
        }
    }
}
