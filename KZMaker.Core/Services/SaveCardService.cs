using KZMaker.Core.Exceptions;
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
    public class SaveCardService : ISaveCardService
    {

        public void SaveCard(Bitmap card, string fileName, string savingPath)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new NotGeneratedCardException("Karta nie została wygenerowana.");
            }

            CheckIfDirectoryExists(savingPath);

            card.Save(Path.Combine(savingPath, $"{fileName}.png"));
        }

        public void SaveDraft(string zastep, DateTime date, string place, List<Models.Point> points, List<RequiredItem> requiredItems, string fileName, string savingPath)
        {
            CheckIfDirectoryExists(savingPath);

            //Text file will look like this:
            //zastep^date^place^pointTime$pointTitle$zastepMember*pointTime$pointTitle$zastepMember^item*item

            string lines = "";
            lines += zastep + "^";
            lines += date + "^";
            lines += place + "^";
            foreach(Models.Point point in points)
            {
                lines += $"{point.DisplayTime}${point.Title}${point.ZastepMember}*";
            }
            lines = lines.Substring(0, lines.Length - 1);

            lines += "^";

            foreach(RequiredItem item in requiredItems)
            {
                lines += $"{item.Item}*";
            }
            lines = lines.Substring(0, lines.Length - 1);

            File.WriteAllText(savingPath + $"\\{fileName}.card", lines);
        }

        private void CheckIfDirectoryExists(string savingPath)
        {
            if (!Directory.Exists(savingPath))
            {
                Directory.CreateDirectory(savingPath);
            }
        }
    }
}
