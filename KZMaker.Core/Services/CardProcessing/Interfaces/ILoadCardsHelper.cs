using KZMaker.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KZMaker.Core.Services.CardProcessing.Interfaces
{
    public interface ILoadCardsHelper
    {
        void AddRequiredItemsToCard(Card card, string[] items);
        void AddPointsToCard(Card card, string[] points);
        Card ConvertStringToCard(string fileText);
    }
}
