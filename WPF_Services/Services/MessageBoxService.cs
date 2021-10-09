using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Services.Services
{
    public class MessageBoxService : IMessageBoxService
    {
        public string GetSavingPath(string startDirectory)
        {
            if (!Directory.Exists(startDirectory))
            {
                Directory.CreateDirectory(startDirectory);
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "png files (*.png)|*.png|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.FileName = startDirectory;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == true)
            {
                return saveFileDialog.FileName;
            }

            return "";
        }

        public string GetPath()
        {
            throw new NotImplementedException();
        }
    }
}
