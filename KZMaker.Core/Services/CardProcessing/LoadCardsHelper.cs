using KZMaker.Core.Commands;
using KZMaker.Core.Exceptions;
using KZMaker.Core.Models;
using KZMaker.Core.Services.CardProcessing.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KZMaker.Core.Services.CardProcessing
{
    public class LoadCardsHelper : ILoadCardsHelper
    {
        public void AddRequiredItemsToCard(Card card, string[] items)
        {
            card.RequiredItems = new List<RequiredItem>();
            if (items.Length < 1 || string.IsNullOrEmpty(items[0])) return;
            
            foreach (string item in items)
            {
                card.RequiredItems.Add(new RequiredItem { Item = item });
            }
        }

        public void AddPointsToCard(Card card, string[] points)
        {
            card.Points = new List<Point>();
            if (points.Length < 1 || string.IsNullOrEmpty(points[0])) return;

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

        public Card ConvertStringToCard(string fileText)
        {
            Card card = new Card();

            //Text file will look like this:
            //zastep^date^place^pointTime$pointTitle$zastepMember*pointTime$pointTitle$zastepMember^item*item

            string[] cols = fileText.Split('^');

            if(cols.Length != 5)
            {
                throw new LoadFileFailedException("Couldn't load invalid file");
            }

            card.Zastep = cols[0];

            //Trying to parse String to DateTime
            DateTime date;
            if (DateTime.TryParse(cols[1], out date))
            {
                card.Date = date; 
            }
            else
            {
                throw new LoadFileFailedException("Date in file string is invalid");
            }

            card.Place = cols[2];

            string[] points = cols[3].Split('*');
            AddPointsToCard(card, points);

            string[] items = cols[4].Split('*');
            AddRequiredItemsToCard(card, items);

            return card;
        }
    }

}
