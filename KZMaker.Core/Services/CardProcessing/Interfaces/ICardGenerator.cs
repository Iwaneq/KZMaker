using KZMaker.Core.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KZMaker.Core.Services.CardProcessing.Interfaces
{
    public interface ICardGenerator
    {
        Bitmap ReturnCard();
        void CleanCard();
        void DrawRequiredItems(List<RequiredItem> requiredItems);
        void DrawZastep(string zastep);
        void DrawDate(DateTime date);
        void DrawPlace(string place);
        void DrawPoints(List<Models.Point> points);
        void DrawZastepMember(Font pointsFont, RectangleF whoRect, List<Models.Point> points);
        void DrawPointTitle(Font pointsFont, RectangleF pointRect, List<Models.Point> points);
        void DrawTime(Font pointsFont, RectangleF timeRect, List<Models.Point> points);
    }
}
