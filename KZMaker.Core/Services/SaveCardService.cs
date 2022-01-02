using KZMaker.Core.Exceptions;
using KZMaker.Core.Models;
using KZMaker.Core.Services.CardProcessing.Interfaces;
using KZMaker.Core.Utils.Interfaces;
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
        private readonly ISaveCardHelper _saveHelper;
        private readonly IFile _fileSystem;

        public SaveCardService(ISaveCardHelper helper, IFile fileSystem)
        {
            _saveHelper = helper;
            _fileSystem = fileSystem;
        }

        public void SaveCard(Bitmap card, string fileName, string savingPath)
        {
            _saveHelper.CheckFileName(fileName);

            _saveHelper.CheckIfDirectoryExists(savingPath);

            card.Save(Path.Combine(savingPath, $"{fileName}.png"));
        }

        

        public void SaveDraft(string zastep, DateTime date, string place, List<Models.Point> points, List<RequiredItem> requiredItems, string fileName, string savingPath)
        {
            _saveHelper.CheckIfDirectoryExists(savingPath);

            //Text file will look like this:
            //zastep^date^place^pointTime$pointTitle$zastepMember*pointTime$pointTitle$zastepMember^item*item

            string lines = "";
            lines += zastep + "^";
            lines += date + "^";
            lines += place + "^";

            _saveHelper.AddPointsToDraft(ref lines, points);

            lines += "^";

            _saveHelper.AddRequiredItemsToDraft(ref lines, requiredItems);

            _fileSystem.WriteAllText(savingPath + $"\\{fileName}.card", lines);
        }

        
    }
}
