using KZMaker.Core.Models;
using KZMaker.Core.Services.CardProcessing.Interfaces;
using System;
using System.Collections.Generic;
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
    }

}
