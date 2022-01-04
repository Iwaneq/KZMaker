using KZMaker.Core.Commands;
using KZMaker.Core.Models;
using KZMaker.Core.Services.CardProcessing.Interfaces;
using KZMaker.Core.Services.Interfaces;
using KZMaker.Core.Utils.Interfaces;
using MvvmCross;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KZMaker.Core.Services
{
    public class LoadCardsService : ILoadCardsService
    {
        private readonly ILoadCardsHelper _helper;
        private readonly IFile _fileSystem;
        private readonly IDirectory _directorySystem;
        private readonly INotificationsService _notificationsService;

        public LoadCardsService(ILoadCardsHelper loadCardsHelper, IFile fileSystem, IDirectory directorySystem, INotificationsService service)
        {
            _helper = loadCardsHelper;
            _fileSystem = fileSystem;
            _directorySystem = directorySystem;
            _notificationsService = service;
        }

        public Card LoadCard(string filePath)
        {
            if (!_fileSystem.Exists(filePath))
            {
                throw new FileNotFoundException();
            }

            string fileText = _fileSystem.ReadAllText(filePath);

            Card card;

            try
            {
                card = _helper.ConvertStringToCard(fileText);
            }
            catch (Exception ex)
            {
                _notificationsService.UpdateMessage($"Błąd: {ex.Message}", true);
                return null;
            }

            return card;
        }

        public List<CardFile> LoadCards(string folder)
        {
            if (!_directorySystem.Exists(folder))
            {
                throw new DirectoryNotFoundException();
            }

            List<CardFile> output = new List<CardFile>();

            var files = _directorySystem.GetFiles(folder);

            foreach (var file in files)
            {
                if (file.EndsWith(".card"))
                {
                    //Convert file to CardFile
                    output.Add(new CardFile()
                    {
                        Date = _fileSystem.GetLastAccessTime(file),
                        FileName = Path.GetFileNameWithoutExtension(file),
                        Path = file
                    });
                }
            }

            return output;
        }
    }
}
