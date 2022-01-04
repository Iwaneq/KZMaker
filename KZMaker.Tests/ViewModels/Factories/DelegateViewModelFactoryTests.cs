using Autofac;
using Autofac.Extras.Moq;
using KZMaker.Core.Navigation;
using KZMaker.Core.ViewModels;
using KZMaker.Core.ViewModels.Factories;
using KZMaker.Tests.Fake_Items;
using Moq;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace KZMaker.Tests.ViewModels.Factories
{
    public class DelegateViewModelFactoryTests
    {
        private CreateViewModel<HomeViewModel> _createHomeViewModel;
        private CreateViewModel<CreateCardViewModel> _createCardViewModel;
        private CreateViewModel<SaveCardViewModel> _createSaveCardViewModel;
        private CreateViewModel<CardListViewModel> _createCardListViewModel;
        private CreateViewModel<SettingsViewModel> _createSettingsViewModel;

        public DelegateViewModelFactoryTests()
        {
            _createHomeViewModel = new CreateViewModel<HomeViewModel>(CreateFakeViewModel);
            _createCardViewModel = new CreateViewModel<CreateCardViewModel>(CreateFakeViewModel);
            _createSaveCardViewModel = new CreateViewModel<SaveCardViewModel>(CreateFakeViewModel);
            _createCardListViewModel = new CreateViewModel<CardListViewModel>(CreateFakeViewModel);
            _createSettingsViewModel = new CreateViewModel<SettingsViewModel>(CreateFakeViewModel);
        }

        [Theory]
        [InlineData(ViewModelType.Home)]
        [InlineData(ViewModelType.CreateCard)]
        [InlineData(ViewModelType.SaveCard)]
        [InlineData(ViewModelType.CardList)]
        [InlineData(ViewModelType.Settings)]
        public void CreateViewModel_WithValidViewModelType_ShouldWork(ViewModelType type)
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange
                var factory = new Mock<DelegateViewModelFactory>(_createHomeViewModel, _createCardViewModel, _createSaveCardViewModel, _createCardListViewModel, _createSettingsViewModel).Object;

                //Act
                var actual = factory.CreateViewModel(type);

                //Assert 
                Assert.NotNull(actual);
                Assert.IsType<FakeViewModel>(actual);
            }
        }
        MvxViewModel CreateFakeViewModel()
        {
            return new FakeViewModel();
        }
    }
}
