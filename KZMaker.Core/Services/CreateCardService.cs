using KZMaker.Core.Models;
using KZMaker.Core.Services.CardProcessing.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KZMaker.Core.Services
{
    public class CreateCardService : ICreateCardService
    {
        private readonly ICreateCardHelper _helper;
        private static Bitmap card;
        private static SolidBrush drawBrush = new SolidBrush(Color.Black);
        private static StringFormat drawFormat = new StringFormat();

        //Rectangles
        static RectangleF zastepRect = new RectangleF(220, 145, 405, 55);
        static RectangleF dateRect = new RectangleF(80, 275, 500, 50);
        static RectangleF placeRect = new RectangleF(580, 275, 1000, 50);
        static RectangleF requiredItemsRect = new RectangleF(80, 1045, 1000, 280);

        public CreateCardService(ICreateCardHelper helper)
        {
            card = new Bitmap(Path.Combine(Environment.CurrentDirectory, @"Resources\", "karta.png"));
            _helper = helper;
        }

        public async Task<Bitmap> GenerateCard(string zastep, DateTime date, string place, List<Models.Point> points, List<RequiredItem> requiredItems)
        {
            card = new Bitmap(Path.Combine(Environment.CurrentDirectory, @"Resources\", "karta.png"));

            if (!string.IsNullOrEmpty(zastep)) await Task.Run(() => DrawZastep(zastep));

            await Task.Run(() => DrawDate(date));

            if (!string.IsNullOrEmpty(place)) await Task.Run(() => DrawPlace(place));

            if (points.Count != 0) await Task.Run(() => DrawPoints(points));

            if (requiredItems.Count != 0) await Task.Run(() => DrawRequiredItems(requiredItems));

            return card;
        }

        private void DrawRequiredItems(List<RequiredItem> requiredItems)
        {
            Font requiredItemsFont = new Font("Arial", 30, FontStyle.Bold);

            string lines = "";

            _helper.AddRequiredItemsToCard(ref lines, requiredItems);
            
            Graphics.FromImage(card).DrawString(lines, requiredItemsFont, drawBrush, requiredItemsRect);
        }

        

        private void DrawZastep(string zastep)
        {
            Font zastepFont = new Font("Arial", 38, FontStyle.Bold);

            if (zastep.Length > 10)
            {
                zastepFont = new Font("Arial", 25, FontStyle.Bold);
            }

            Graphics.FromImage(card).DrawString(zastep, zastepFont, drawBrush, zastepRect, drawFormat);
        }

        private void DrawDate(DateTime date)
        {
            Font datumFont = new Font("Arial", 25, FontStyle.Bold);

            string month = _helper.GetMonthString(date.Month);
            
            Graphics.FromImage(card).DrawString($"{date.Day} {month} {date.Year}", datumFont, drawBrush, dateRect, drawFormat);
        }

        private void DrawPlace(string place)
        {
            Font placeFont = new Font("Arial", 30, FontStyle.Bold);

            Graphics.FromImage(card).DrawString(place, placeFont, drawBrush, placeRect);
        }

        private void DrawPoints(List<Models.Point> points)
        {
            Font pointsFont = new Font("Arial", 20, FontStyle.Bold);

            float height = 585 / points.Count;

            RectangleF pointRect = new RectangleF(220, 400, 515, height);
            RectangleF timeRect = new RectangleF(80, 400, 135, height);
            RectangleF whoRect = new RectangleF(735, 400, 220, height);

            //Draw czas
            DrawTime(pointsFont, timeRect, points);

            //Draw coRobimy
            DrawPointTitle(pointsFont, pointRect, points);

            //Draw kto
            DrawZastepMember(pointsFont, whoRect, points);
        }

        private void DrawZastepMember(Font pointsFont, RectangleF whoRect, List<Models.Point> points)
        {
            foreach (Models.Point p in points)
            {
                Graphics.FromImage(card).DrawString(p.ZastepMember, pointsFont, drawBrush, whoRect);
                whoRect.Y += whoRect.Height;
            }
        }

        private static void DrawPointTitle(Font pointsFont, RectangleF pointRect, List<Models.Point> points)
        {
            foreach (Models.Point p in points)
            {
                Graphics.FromImage(card).DrawString(p.Title, pointsFont, drawBrush, pointRect);
                pointRect.Y += pointRect.Height;
            }
        }

        private void DrawTime(Font pointsFont, RectangleF timeRect, List<Models.Point> points)
        {
            foreach (Models.Point p in points)
            {
                Graphics.FromImage(card).DrawString($"{p.DisplayTime}", pointsFont, drawBrush, timeRect);
                timeRect.Y += timeRect.Height;
            }
        }
    }
}
