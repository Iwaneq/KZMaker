using KZMaker.Core.ViewModels.Helpers;
using KZMaker.Core.ViewModels.Settings;
using KZMaker.Tests.Fake_Items;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace KZMaker.Tests.ViewModels.Helpers
{
    public class SettingsViewModelChildNavigationHelperTests
    {
        List<MvxViewModel> _childViewModels = new List<MvxViewModel>()
        {
            new FakeViewModel(),
            new FakeViewModel(),
            new FakeViewModel(),
            new FakeViewModel()
        };

        [Fact]
        public void NextViewModel_WithFirstViewModelOnList_ShouldReturnNextViewModel()
        {
            var service = new SettingsViewModelChildNavigationHelper();

            var currentViewModel = _childViewModels[0];

            var expectedViewModel = _childViewModels[1];
            var actualViewModel = service.NextViewModel(currentViewModel, _childViewModels);

            Assert.NotNull(actualViewModel);
            Assert.NotEqual(currentViewModel, actualViewModel);
            Assert.Equal(expectedViewModel, actualViewModel);
        }

        [Fact]
        public void NextViewModel_WithLastViewModelOnList_ShouldReturnFirstViewModel()
        {
            var service = new SettingsViewModelChildNavigationHelper();

            var currentViewModel = _childViewModels.Last();

            var expectedViewModel = _childViewModels.First();
            var actualViewModel = service.NextViewModel(currentViewModel, _childViewModels);

            Assert.NotNull(actualViewModel);
            Assert.NotEqual(currentViewModel, actualViewModel);
            Assert.Equal(expectedViewModel, actualViewModel);
        }

        [Fact]
        public void NextViewModel_WithInvalidViewModel_ShouldThrowException()
        {
            var service = new SettingsViewModelChildNavigationHelper();

            Assert.Throws<ArgumentNullException>(() => service.NextViewModel(null, _childViewModels));
        }

        [Fact]
        public void NextViewModel_WithViewModelOutsideList_ShouldThrowException()
        {
            var service = new SettingsViewModelChildNavigationHelper();

            Assert.Throws<ArgumentOutOfRangeException>(() => service.NextViewModel(new FakeViewModel(), _childViewModels));
        }

        [Fact]
        public void NextViewModel_WithEmptyList_ShouldThrowException()
        {
            var service = new SettingsViewModelChildNavigationHelper();

            Assert.Throws<ArgumentNullException>(() => service.NextViewModel(new FakeViewModel(), new List<MvxViewModel>()));
        }

        [Fact]
        public void PreviousViewModel_WithLastViewModelOnList_ShouldReturnPreviousViewModel()
        {
            var service = new SettingsViewModelChildNavigationHelper();

            var currentViewModel = _childViewModels.Last();

            var expectedViewModel = _childViewModels[_childViewModels.Count - 2];
            var actualViewModel = service.PreviousViewModel(currentViewModel, _childViewModels);

            Assert.NotNull(actualViewModel);
            Assert.NotEqual(currentViewModel, actualViewModel);
            Assert.Equal(expectedViewModel, actualViewModel);
        }

        [Fact]
        public void PreviousViewModel_WithFirstViewModelOnList_ShouldReturnLastViewModel()
        {
            var service = new SettingsViewModelChildNavigationHelper();

            var currentViewModel = _childViewModels.First();

            var expectedViewModel = _childViewModels.Last();
            var actualViewModel = service.PreviousViewModel(currentViewModel, _childViewModels);

            Assert.NotNull(actualViewModel);
            Assert.NotEqual(currentViewModel, actualViewModel);
            Assert.Equal(expectedViewModel, actualViewModel);
        }

        [Fact]
        public void PreviousViewModel_WithInvalidViewModel_ShouldThrowException()
        {
            var service = new SettingsViewModelChildNavigationHelper();

            Assert.Throws<ArgumentNullException>(() => service.PreviousViewModel(null, _childViewModels));
        }

        [Fact]
        public void PreviousViewModel_WithViewModelOutsideList_ShouldThrowException()
        {
            var service = new SettingsViewModelChildNavigationHelper();

            Assert.Throws<ArgumentOutOfRangeException>(() => service.PreviousViewModel(new FakeViewModel(), _childViewModels));
        }

        [Fact]
        public void PreviousViewModel_WithEmptyList_ShouldThrowException()
        {
            var service = new SettingsViewModelChildNavigationHelper();

            Assert.Throws<ArgumentNullException>(() => service.PreviousViewModel(new FakeViewModel(), new List<MvxViewModel>()));
        }

        [Theory]
        [InlineData(0, "Ogólne")]
        [InlineData(1, "Zapis")]
        [InlineData(2, "Aktualizacje")]
        [InlineData(3, "Informacje")]
        public void GetTitle_WithValidIndex_ShouldWork(int index, string expected)
        {
            var service = new SettingsViewModelChildNavigationHelper();

            string actual = service.GetTitle(index);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetTitle_WithInvalidIndex_ShouldThrowException()
        {
            var service = new SettingsViewModelChildNavigationHelper();

            Assert.Throws<NotImplementedException>(() => service.GetTitle(99));
        }
    }
}
