using Autofac.Extras.Moq;
using KZMaker.Core.Models;
using KZMaker.Core.Services;
using KZMaker.Core.Services.CardProcessing.Interfaces;
using KZMaker.Core.Utils.Interfaces;
using Moq;
using MvvmCross;
using MvvmCross.Base;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace KZMaker.Tests.Services
{
    public class LoadCardsServiceTests
    {
        [Theory]
        [InlineData("C:/data/KZMaker/file.card")]
        public void LoadCard_WithExistingFilePath_ShouldWork(string filePath)
        {
            using(var mock = AutoMock.GetLoose())
            {
                //Arrange
                mock.Mock<IFile>()
                    .Setup(x => x.Exists(filePath))
                    .Returns(true);

                mock.Mock<IFile>()
                    .Setup(x => x.ReadAllText(filePath))
                    .Returns(GetCardString());

                mock.Mock<ILoadCardsHelper>()
                    .Setup(x => x.ConvertStringToCard(GetCardString()))
                    .Returns(GetConvertedCard());

                var expected = GetConvertedCard();
                var service = mock.Create<LoadCardsService>();

                //Act
                var actual = service.LoadCard(filePath);

                //Assert

                mock.Mock<IFile>()
                    .Verify(x => x.Exists(filePath), Times.Exactly(1));
                mock.Mock<IFile>()
                    .Verify(x => x.ReadAllText(filePath), Times.Exactly(1));
                mock.Mock<ILoadCardsHelper>().Verify(x => x.ConvertStringToCard(GetCardString()), Times.Exactly(1));

                Assert.True(actual != null);

                Assert.Equal(expected.Zastep, actual.Zastep);
                Assert.Equal(expected.Date, actual.Date);
                Assert.Equal(expected.Place, actual.Place);
                Assert.Equal(expected.Points, actual.Points);
                Assert.Equal(expected.RequiredItems, actual.RequiredItems);
            }
        }

        [Fact]
        public void LoadCard_WithNonExistingFilePath_ShouldThrowException()
        {
            using(var mock = AutoMock.GetLoose())
            {
                string filePath = "C:/data/KZMaker/file.card";

                mock.Mock<IFile>()
                    .Setup(x => x.Exists(filePath))
                    .Returns(false);

                var service = mock.Create<LoadCardsService>();

                Assert.Throws<FileNotFoundException>(() => service.LoadCard(filePath));
            }
        }

        [Fact]
        public void LoadCards_WithValidFolder_ShouldWork()
        {
            using(var mock = AutoMock.GetLoose())
            {
                string folder = "C:/data/KZMaker";

                mock.Mock<IDirectory>()
                    .Setup(x => x.Exists(folder))
                    .Returns(true);

                mock.Mock<IDirectory>()
                    .Setup(x => x.GetFiles(folder))
                    .Returns(GetCardFiles());

                mock.Mock<IFile>()
                    .Setup(x => x.GetLastAccessTime(It.IsAny<string>()))
                    .Returns(DateTime.Parse("2021 - 10 - 10 00:00:00"));

                List<CardFile> expected = new List<CardFile>()
                {
                    new CardFile()
                    {
                        Date = DateTime.Parse("2021 - 10 - 10 00:00:00"),
                        FileName = "file1",
                        Path = "C:/data/KZMaker/file1.card"
                    },
                    new CardFile()
                    {
                        Date = DateTime.Parse("2021 - 10 - 10 00:00:00"),
                        FileName = "file2",
                        Path = "C:/data/KZMaker/file2.card"
                    },
                    new CardFile()
                    {
                        Date = DateTime.Parse("2021 - 10 - 10 00:00:00"),
                        FileName = "file3",
                        Path = "C:/data/KZMaker/file3.card"
                    },
                    new CardFile()
                    {
                        Date = DateTime.Parse("2021 - 10 - 10 00:00:00"),
                        FileName = "file4",
                        Path = "C:/data/KZMaker/file4.card"
                    }
                };
                    

                var service = mock.Create<LoadCardsService>();

                var actual = service.LoadCards(folder);

                Assert.True(actual.Count() > 0);

                for(int i =0; i < expected.Count; i++)
                {
                    Assert.Equal(expected[i].Date,actual[i].Date);
                    Assert.Equal(expected[i].FileName, actual[i].FileName);
                    Assert.Equal(expected[i].Path, actual[i].Path);
                }
            }
        }

        [Fact]
        public void LoadCards_WithNonExistingFolder_ShouldThrowException()
        {
            using(var mock = AutoMock.GetLoose())
            {
                string folder = "non existing folder....";

                mock.Mock<IDirectory>()
                    .Setup(x => x.Exists(folder))
                    .Returns(false);

                var service = mock.Create<LoadCardsService>();

                Assert.Throws<DirectoryNotFoundException>(() => service.LoadCards(folder));
            }
        }

        [Fact]
        public void LoadCards_WithFolderWithoutCardFiles_ShouldReturnEmptyList()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var folder = "Folder without card files";

                mock.Mock<IDirectory>()
                    .Setup(x => x.Exists(folder))
                    .Returns(true);

                mock.Mock<IDirectory>()
                    .Setup(x => x.GetFiles(folder))
                    .Returns(GetNonCardFiles());

                var service = mock.Create<LoadCardsService>();

                var actual = service.LoadCards(folder);

                Assert.Empty(actual);
            }
        }

        private string[] GetNonCardFiles()
        {
            return new[]
            {
                "C:/data/KZMaker/file1.png",
                "C:/data/KZMaker/file2.jpg",
                "C:/data/KZMaker/file3.txt",
                "C:/data/KZMaker/file4.html"
            };
        }

        private string[] GetCardFiles()
        {
            return new[]
            {
                "C:/data/KZMaker/file1.card",
                "C:/data/KZMaker/file2.card",
                "C:/data/KZMaker/file3.card",
                "C:/data/KZMaker/file4.card"
            };
        }

        private Card GetConvertedCard()
        {
            return new Card
            {
                Zastep = "Salamandra",
                Date = DateTime.Parse("2021 - 10 - 10 00:00:00"),
                Place = "Michałów",
                Points = new List<Point>(),
                RequiredItems = new List<RequiredItem>()
            };
        }

        private string GetCardString()
        {
            return "Salamandra^2021-10-10 00:00:00^Michałów^23:11$Igloo$Jacek*23:11$Pionierka$Jacek*23:11$Pionierka$Jacek*23:11$Pionierka$Jacek*23:11$Pionierka$Jacek*23:11$Pionierka$Jacek*23:11$Pionierka$Jacek^nożyczki*nożyczki*nożyczki";
        }
    }
}
