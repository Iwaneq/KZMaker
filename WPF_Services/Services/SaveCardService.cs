using KZMaker.Core;
using KZMaker.Core.Models;
using KZMaker.Core.Services;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Services.Services
{
    public class SaveCardService 
    {
        private string _savingPath;

        public SaveCardService()
        {
            _savingPath = App.GetSettings().SavingPath;
        }

        public void SaveCard(Bitmap card)
        {
            if (!Directory.Exists(_savingPath))
            {
                Directory.CreateDirectory(_savingPath);
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "png files (*.png)|*.png|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.FileName = _savingPath;
            saveFileDialog.RestoreDirectory = true;

            if(saveFileDialog.ShowDialog() == true)
            {
                card.Save(saveFileDialog.FileName);
            }
        }

        public Task SaveDraftAsync(string zastep, DateTime date, string place, List<KZMaker.Core.Models.Point> points, List<RequiredItem> requiredItems)
        {
            throw new NotImplementedException();
        }
    }
}
