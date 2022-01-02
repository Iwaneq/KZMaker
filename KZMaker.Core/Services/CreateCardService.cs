using KZMaker.Core.Models;
using KZMaker.Core.Services.CardProcessing.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;

namespace KZMaker.Core.Services
{
    public class CreateCardService : ICreateCardService
    {
        private readonly ICardGenerator _cardGenerator;

        public CreateCardService(ICardGenerator cardGenerator)
        {
            _cardGenerator = cardGenerator;
        }

        public async Task<Bitmap> CreateCard(string zastep, DateTime date, string place, List<Models.Point> points, List<RequiredItem> requiredItems)
        {
            _cardGenerator.CleanCard();

            if (!string.IsNullOrEmpty(zastep)) await Task.Run(() => _cardGenerator.DrawZastep(zastep));

            await Task.Run(() => _cardGenerator.DrawDate(date));

            if (!string.IsNullOrEmpty(place)) await Task.Run(() => _cardGenerator.DrawPlace(place));

            if (points.Count != 0) await Task.Run(() => _cardGenerator.DrawPoints(points));

            if (requiredItems.Count != 0) await Task.Run(() => _cardGenerator.DrawRequiredItems(requiredItems));

            return _cardGenerator.ReturnCard();
        }

        
    }
}
