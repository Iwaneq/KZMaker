using KZMaker.Core.Models;
using KZMaker.Core.Services.CardProcessing.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KZMaker.Core.Services.CardProcessing
{
    public class CreateCardHelper : ICreateCardHelper
    {
        public void AddRequiredItemsToCard(ref string lines, List<RequiredItem> requiredItems)
        {
            if (requiredItems.Count == 0)
            {
                return;
            }

            foreach (var item in requiredItems)
            {
                lines += $"{item.Item}, ";
            }
            lines = lines.Substring(0, lines.Length - 2);
        }

        public string GetMonthString(int month)
        {
            switch (month)
            {
                case 1:
                    return "Stycznia";
                case 2:
                    return "Lutego";
                case 3:
                    return "Marca";
                case 4:
                    return "Kwietnia";
                case 5:
                    return "Maja";
                case 6:
                    return "Czerwca";
                case 7:
                    return "Lipca";
                case 8:
                    return "Sierpnia";
                case 9:
                    return "Września";
                case 10:
                    return "Października";
                case 11:
                    return "Listopada";
                case 12:
                    return "Grudnia";
                default:
                    throw new ArgumentOutOfRangeException("month", $"Cannot convert month name for month: {month} ");
            }
        }
    }
}
