using KZMaker.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KZMaker.Core.Services.CardProcessing.Interfaces
{
    public interface ISaveCardHelper
    {
        void CheckFileName(string fileName);
        void CheckIfDirectoryExists(string savingPath);
        void AddPointsToDraft(ref string lines, List<Point> points);
        void AddRequiredItemsToDraft(ref string lines, List<RequiredItem> requiredItems);
    }
}
