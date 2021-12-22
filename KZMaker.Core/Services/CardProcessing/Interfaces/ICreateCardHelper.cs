using KZMaker.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KZMaker.Core.Services.CardProcessing.Interfaces
{
    public interface ICreateCardHelper
    {
        void AddRequiredItemsToCard(ref string lines, List<RequiredItem> requiredItems);
        string GetMonthString(int month);
    }
}
