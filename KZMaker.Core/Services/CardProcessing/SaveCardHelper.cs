using KZMaker.Core.Exceptions;
using KZMaker.Core.Models;
using KZMaker.Core.Services.CardProcessing.Interfaces;
using KZMaker.Core.Utils.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KZMaker.Core.Services.CardProcessing
{
    public class SaveCardHelper : ISaveCardHelper
    {
        private readonly IDirectory _directorySystem;

        public SaveCardHelper(IDirectory directorySystem)
        {
            _directorySystem = directorySystem;
        }

        public void AddPointsToDraft(ref string lines, List<Point> points)
        {
            if (points.Count > 0)
            {
                foreach (Point point in points)
                {
                    lines += $"{point.DisplayTime}${point.Title}${point.ZastepMember}*";
                }
                lines = lines.Substring(0, lines.Length - 1);
            }
        }

        public void AddRequiredItemsToDraft(ref string lines, List<RequiredItem> requiredItems)
        {
            if (requiredItems.Count > 0)
            {
                foreach (RequiredItem item in requiredItems)
                {
                    lines += $"{item.Item}*";
                }
                lines = lines.Substring(0, lines.Length - 1);
            }
        }

        public void CheckFileName(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new NotGeneratedCardException("Karta nie została wygenerowana.");
            }
        }

        public void CheckIfDirectoryExists(string savingPath)
        {
            if (!_directorySystem.Exists(savingPath))
            {
                _directorySystem.CreateDirectory(savingPath);
            }
        }
    }
}
