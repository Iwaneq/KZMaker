using KZMaker.Core.Services;
using Microsoft.Win32;
using Ookii.Dialogs.Wpf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KZMaker.WPF.Services
{
    public class MessageBoxService : IMessageBoxService
    {
        public string GetSavingPath(string startDirectory)
        {
            if (!Directory.Exists(startDirectory))
            {
                Directory.CreateDirectory(startDirectory);
            }

            VistaFolderBrowserDialog folderBrowser = new VistaFolderBrowserDialog();
            folderBrowser.Description = "Wybierz folder, w którym zapiszesz kartę";

            if (folderBrowser.ShowDialog() == true)
            {
                return folderBrowser.SelectedPath;
            }

            return "";
        }

        public string GetSavingPath()
        {
            VistaFolderBrowserDialog folderBrowser = new VistaFolderBrowserDialog();
            folderBrowser.Description = "Wybierz folder, w którym zapiszesz kartę";

            if (folderBrowser.ShowDialog() == true)
            {
                return folderBrowser.SelectedPath;
            }

            return "";
        }
    }
}
