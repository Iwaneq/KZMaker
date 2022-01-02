using Autofac;
using Autofac.Extras.Moq;
using KZMaker.Core.Models;
using KZMaker.Core.Services;
using KZMaker.Core.Services.CardProcessing;
using KZMaker.Core.Services.CardProcessing.Interfaces;
using KZMaker.Core.Utils;
using KZMaker.Core.Utils.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace KZMaker.Tests.Services
{
    public class SaveCardServiceTests
    {
        [Fact]
        public void SaveDraft_WithValidData_ShouldWork()
        {
            using(var mock = AutoMock.GetLoose())
            {
                string zastep = "Valid zastep";

                DateTime date = DateTime.Now;

                string place = "Valid place";

                List<Point> points = new List<Point>();

                List<RequiredItem> requiredItems = new List<RequiredItem>();

                string fileName = "Valid file path";

                string savingPath = "Valid saving path";

                var service = mock.Create<SaveCardService>();

                service.SaveDraft(zastep, date, place, points, requiredItems, fileName, savingPath);

                mock.Mock<IFile>()
                    .Verify(x => x.WriteAllText(savingPath + $"\\{fileName}.card", $"{zastep}^{date}^{place}^^"), Times.Once());
            }
        }

        [Fact]
        public void SaveDraft_WithNonExistingSavingPath_ShouldCreateDirectory()
        {
            using (var mock = AutoMock.GetLoose(builder =>
            builder.RegisterType<SaveCardService>().PropertiesAutowired()))
            {
                string zastep = "Valid zastep";

                DateTime date = DateTime.Now;

                string place = "Valid place";

                List<Point> points = new List<Point>();

                List<RequiredItem> requiredItems = new List<RequiredItem>();

                string fileName = "Valid file path";

                string savingPath = "Invalid saving path";

                mock.Mock<IDirectory>()
                    .Setup(x => x.Exists(savingPath))
                    .Returns(false);

                var service = new Mock<SaveCardService>(
                    new SaveCardHelper(mock.Mock<IDirectory>().Object), 
                    mock.Mock<IFile>().Object);

                service.Object.SaveDraft(zastep, date, place, points, requiredItems, fileName, savingPath);

                mock.Mock<IDirectory>()
                    .Verify(x => x.CreateDirectory(savingPath), Times.Once());
            }
        }

        [Fact]
        public void SaveDraft_OnlyWithDate_ShouldReturnCarrotCharsWithDate()
        {
            using (var mock = AutoMock.GetLoose())
            {
                string zastep = "";

                DateTime date = DateTime.Now;

                string place = "";

                List<Point> points = new List<Point>();

                List<RequiredItem> requiredItems = new List<RequiredItem>();

                string fileName = "Valid file path";

                string savingPath = "Valid saving path";

                var service = mock.Create<SaveCardService>();

                service.SaveDraft(zastep, date, place, points, requiredItems, fileName, savingPath);

                mock.Mock<IFile>()
                    .Verify(x => x.WriteAllText(savingPath + $"\\{fileName}.card", $"^{date}^^^"), Times.Once());
            }
        }
    }
}
