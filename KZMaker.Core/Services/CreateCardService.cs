using KZMaker.Core.Models;
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
        private static Bitmap card;
        private static SolidBrush drawBrush = new SolidBrush(Color.Black);
        private static StringFormat drawFormat = new StringFormat();

        //Rectangles
        static RectangleF zastepRect = new RectangleF(220, 145, 405, 55);
        static RectangleF dateRect = new RectangleF(80, 275, 500, 50);
        static RectangleF placeRect = new RectangleF(580, 275, 1000, 50);
        static RectangleF requiredItemsRect = new RectangleF(80, 1045, 1000, 280);

        public CreateCardService()
        {
            card = new Bitmap(Path.Combine(Environment.CurrentDirectory, @"Resources\", "karta.png"));
        }

        public async Task<Bitmap> GenerateCard(string zastep, DateTime date, string place, List<Models.Point> points, List<string> requiredItems)
        {
            await Task.Run(() => DrawZastep(zastep));

            await Task.Run(() => DrawDate(date));

            await Task.Run(() => DrawPlace(place));

            await Task.Run(() => DrawPoints(points));

            await Task.Run(() => DrawRequiredItems(requiredItems));

            return card;
        }

        private static void DrawRequiredItems(List<string> requiredItems)
        {
            if(requiredItems.Count == 0)
            {
                return;
            }

            Font requiredItemsFont = new Font("Arial", 30, FontStyle.Bold);

            string lines = "";
            foreach(string item in requiredItems)
            {
                lines += $"{item}, ";
            }
            lines = lines.Substring(0, lines.Length - 2);

            Graphics.FromImage(card).DrawString(lines, requiredItemsFont, drawBrush, requiredItemsRect);
        }

        private static void DrawZastep(string zastep)
        {
            Font zastepFont = new Font("Arial", 38, FontStyle.Bold);

            if (zastep.Length > 10)
            {
                zastepFont = new Font("Arial", 25, FontStyle.Bold);
            }

            Graphics.FromImage(card).DrawString(zastep, zastepFont, drawBrush, zastepRect, drawFormat);
        }

        private static void DrawDate(DateTime date)
        {
            Font datumFont = new Font("Arial", 25, FontStyle.Bold);

            string month = "";
            switch (date.Month)
            {
                case 1:
                    month = "Stycznia";
                    break;
                case 2:
                    month = "Lutego";
                    break;
                case 3:
                    month = "Marca";
                    break;
                case 4:
                    month = "Kwietnia";
                    break;
                case 5:
                    month = "Maja";
                    break;
                case 6:
                    month = "Czerwca";
                    break;
                case 7:
                    month = "Lipca";
                    break;
                case 8:
                    month = "Sierpnia";
                    break;
                case 9:
                    month = "Września";
                    break;
                case 10:
                    month = "Października";
                    break;
                case 11:
                    month = "Listopada";
                    break;
                case 12:
                    month = "Grudnia";
                    break;
            }
            Graphics.FromImage(card).DrawString($"{date.Day} {month} {date.Year}", datumFont, drawBrush, dateRect, drawFormat);
        }

        private static void DrawPlace(string place)
        {
            Font placeFont = new Font("Arial", 30, FontStyle.Bold);

            Graphics.FromImage(card).DrawString(place, placeFont, drawBrush, placeRect);
        }

        private static void DrawPoints(List<Models.Point> points)
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
            DrawWho(pointsFont, whoRect, points);
        }

        private static void DrawWho(Font pointsFont, RectangleF whoRect, List<Models.Point> points)
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

        private static void DrawTime(Font pointsFont, RectangleF timeRect, List<Models.Point> points)
        {
            foreach (Models.Point p in points)
            {
                Graphics.FromImage(card).DrawString($"{p.DisplayTime}", pointsFont, drawBrush, timeRect);
                timeRect.Y += timeRect.Height;
            }
        }
    }
}
