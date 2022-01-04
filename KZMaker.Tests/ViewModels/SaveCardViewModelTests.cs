using Autofac.Extras.Moq;
using KZMaker.Core.ViewModels;
using KZMaker.Tests.Fake_Items;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace KZMaker.Tests.ViewModels
{
    public class SaveCardViewModelTests
    {
        [Fact]
        public void UpdateCard_WithValidData_ShouldWork()
        {
            using(var mock = AutoMock.GetLoose())
            {
                var viewModel = mock.Create<SaveCardViewModel>();

                Bitmap card = new Bitmap(1, 1);
                string fileName = "ValidFileName";

                viewModel.UpdateCard(card, fileName);

                Assert.NotNull(viewModel.Card);
                Assert.Equal(card, viewModel.Card);
                Assert.Equal(fileName, viewModel.FileName);
            }
        }

        [Fact]
        public void UpdateCard_WithInvalidCard_ShouldNotUpdateProperties()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var viewModel = mock.Create<SaveCardViewModel>();

                //Setting default Card and FileName
                Bitmap defaultCard = new Bitmap(1, 1);
                string defaultFileName = "ValidFileName";

                viewModel.Card = defaultCard;
                viewModel.FileName = defaultFileName;

                Bitmap nullCard = null;
                string nullFileName = "";

                viewModel.UpdateCard(nullCard, nullFileName);

                Assert.NotNull(viewModel.Card);

                //Checking if Card is still default Card (of size 1x1) and if FileName hasn't changed
                Assert.Equal(defaultCard, viewModel.Card);
                Assert.Equal(defaultFileName, viewModel.FileName);
            }
        }

        [Fact]
        public void ChangeCommand_WithValidCommand_ShouldChangeCommand()
        {
            using(var mock = AutoMock.GetLoose())
            {
                var viewModel = mock.Create<SaveCardViewModel>();
                var fakeCommand = new FakeSaveCardCommand();

                viewModel.ChangeCommand(fakeCommand);

                Assert.NotNull(viewModel.SaveCardCommand);
                Assert.Equal(fakeCommand, viewModel.SaveCardCommand);
            }
        }

        [Fact]
        public void ChangeCommand_WithInvalidCommand_ShouldNotChangeCommand()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var viewModel = mock.Create<SaveCardViewModel>();
                var fakeCommand = new FakeSaveCardCommand();

                viewModel.SaveCardCommand = fakeCommand;

                viewModel.ChangeCommand(null);

                Assert.NotNull(viewModel.SaveCardCommand);
                Assert.Equal(fakeCommand, viewModel.SaveCardCommand);
            }
        }
    }
}
