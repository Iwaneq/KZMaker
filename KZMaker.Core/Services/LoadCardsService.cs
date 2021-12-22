using KZMaker.Core.Commands;
using KZMaker.Core.Models;
using KZMaker.Core.Services.CardProcessing.Interfaces;
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

        public LoadCardsService(ILoadCardsHelper loadCardsHelper)
        {
            _helper = loadCardsHelper;
        }

        public Card LoadCard(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException();
            }

            Card card = new Card();
            string fileText = File.ReadAllText(filePath);

            //Text file will look like this:
            //zastep^date^place^pointTime$pointTitle$zastepMember*pointTime$pointTitle$zastepMember^item*item

            string[] cols = fileText.Split('^');
            card.Zastep = cols[0];
            card.Date = DateTime.Parse(cols[1]);
            card.Place = cols[2];

            string[] points = cols[3].Split('*');
            _helper.AddPointsToCard(card, points);

            string[] items = cols[4].Split('*');
            _helper.AddRequiredItemsToCard(card, items);

            return card;
        }

        public CardFile LoadCardFile(string filePath)
        {
            throw new NotImplementedException();
        }

        public MvxObservableCollection<CardFile> LoadCardsFiltered(string folder, Func<List<CardFile>, List<CardFile>> filterFiles)
        {
            List<CardFile> output = LoadCards(folder).OrderByDescending(a => a.Date).ToList();

            output = filterFiles(output);
            return new MvxObservableCollection<CardFile>(output);
        }

        public MvxObservableCollection<CardFile> LoadCards(string folder)
        {
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            MvxObservableCollection<CardFile> output = new MvxObservableCollection<CardFile>();

            foreach(var file in Directory.GetFiles(folder))
            {
                if (file.EndsWith(".card"))
                {
                    //Convert file to CardFile
                    output.Add(new CardFile(Mvx.IoCProvider.GetSingleton<LoadCardCommand>())
                    {
                        Date = File.GetLastAccessTime(file),
                        FileName = Path.GetFileNameWithoutExtension(file),
                        Path = file
                    });
                }
            }

            return output;
        }
    }
}
