using Autofac.Extras.Moq;
using KZMaker.Core;
using KZMaker.Core.Models;
using KZMaker.Core.ResourceManagement;
using KZMaker.Core.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace KZMaker.Tests.ResourceManagement
{
    public class SettingsServiceTests
    {
        Settings validSettings = new Settings()
        {
            SavingPath = "Valid Saving Path",
            ThemeColor = "Dark",
            IsSavingManually = false,
            DefaultZastep = "Valid Zastep",
            IsCheckingUpdatesAtStart = false
        };

        Settings emptySavinPathSettings = new Settings()
        {
            SavingPath = "",
            ThemeColor = "Dark",
            IsSavingManually = false,
            DefaultZastep = "Valid Zastep",
            IsCheckingUpdatesAtStart = false
        };

        Settings emptyThemeSettings = new Settings()
        {
            SavingPath = "Valid Saving Path",
            ThemeColor = "",
            IsSavingManually = false,
            DefaultZastep = "Valid Zastep",
            IsCheckingUpdatesAtStart = false
        };

        [Fact]
        public void UpdateSettings_WithValidData_ShouldWork()
        {
            using(var mock = AutoMock.GetLoose())
            {
                var service = mock.Create<SettingsService>();

                service.UpdateSettings(validSettings);

                mock.Mock<IResourcesService>()
                    .Verify(x => x.CheckTheme(), Times.Once);
                mock.Mock<IChangeCommandsService>()
                    .Verify(x => x.ChangeSavingMode(), Times.Once);

                var appSettings = AppSettings.Default;

                Assert.Equal(validSettings.SavingPath, appSettings.SavingPath);
                Assert.Equal(validSettings.ThemeColor, appSettings.Theme);
                Assert.Equal(validSettings.IsSavingManually, appSettings.IsSavingManually);
                Assert.Equal(validSettings.DefaultZastep, appSettings.DefaultZastep);
                Assert.Equal(validSettings.IsCheckingUpdatesAtStart, appSettings.IsCheckingUpdatesAtStart);
            }
        }

        [Fact]
        public void UpdateSettings_WithEmptySavingPath_ShouldNotUpdateSavingPath()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var service = mock.Create<SettingsService>();

                service.UpdateSettings(emptySavinPathSettings);

                mock.Mock<IResourcesService>()
                    .Verify(x => x.CheckTheme(), Times.Once);
                mock.Mock<IChangeCommandsService>()
                    .Verify(x => x.ChangeSavingMode(), Times.Once);

                var appSettings = AppSettings.Default;

                Assert.NotEqual(emptySavinPathSettings.SavingPath, appSettings.SavingPath);
                Assert.NotEmpty(appSettings.SavingPath);

                Assert.Equal(emptySavinPathSettings.ThemeColor, appSettings.Theme);
                Assert.Equal(emptySavinPathSettings.IsSavingManually, appSettings.IsSavingManually);
                Assert.Equal(emptySavinPathSettings.DefaultZastep, appSettings.DefaultZastep);
                Assert.Equal(emptySavinPathSettings.IsCheckingUpdatesAtStart, appSettings.IsCheckingUpdatesAtStart);
            }
        }

        [Fact]
        public void UpdateSettings_WithEmptyTheme_ShouldNotUpdateSavingPath()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var service = mock.Create<SettingsService>();

                service.UpdateSettings(emptyThemeSettings);

                mock.Mock<IResourcesService>()
                    .Verify(x => x.CheckTheme(), Times.Never);
                mock.Mock<IChangeCommandsService>()
                    .Verify(x => x.ChangeSavingMode(), Times.Once);

                var appSettings = AppSettings.Default;

                Assert.Equal(emptyThemeSettings.SavingPath, appSettings.SavingPath);

                Assert.NotEqual(emptyThemeSettings.ThemeColor, appSettings.Theme);
                Assert.NotEmpty(appSettings.Theme);

                Assert.Equal(emptyThemeSettings.IsSavingManually, appSettings.IsSavingManually);
                Assert.Equal(emptyThemeSettings.DefaultZastep, appSettings.DefaultZastep);
                Assert.Equal(emptyThemeSettings.IsCheckingUpdatesAtStart, appSettings.IsCheckingUpdatesAtStart);
            }
        }
    }
}
