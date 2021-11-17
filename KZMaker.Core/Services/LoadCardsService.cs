using KZMaker.Core.Commands;
using KZMaker.Core.Models;
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
        public Card LoadCard(string filePath)
        {
            Card card = new Card();
            string fileText = File.ReadAllText(filePath);

            //Text file will look like this:
            //zastep^date^place^pointTime$pointTitle$zastepMember*pointTime$pointTitle$zastepMember^item*item

            string[] cols = fileText.Split('^');
            card.Zastep = cols[0];
            card.Date = DateTime.Parse(cols[1]);
            card.Place = cols[2];

            string[] points = cols[3].Split('*');
            card.Points = new List<Point>();
            if (points.Length > 0 && !string.IsNullOrEmpty(points[0]))
            {
                foreach (string point in points)
                {
                    string[] p = point.Split('$');
                    card.Points.Add(new Point
                    {
                        DisplayTime = p[0],
                        Title = p[1],
                        ZastepMember = p[2]
                    });
                } 
            }

            string[] items = cols[4].Split('*');
            card.RequiredItems = new List<RequiredItem>();
            if (items.Length > 0 && !string.IsNullOrEmpty(items[0]))
            {
                foreach (string item in items)
                {
                    card.RequiredItems.Add(new RequiredItem { Item = item });
                } 
            }

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
