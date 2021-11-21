using KZMaker.Core.Exceptions;
using KZMaker.Core.Services;
using Microsoft.Win32;
using Ookii.Dialogs.Wpf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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

            throw new GetPathFailedException("Saving Path");
        }

        public string GetSavingPath()
        {
            VistaFolderBrowserDialog folderBrowser = new VistaFolderBrowserDialog();
            folderBrowser.Description = "Wybierz folder, w którym zapiszesz kartę";

            if (folderBrowser.ShowDialog() == true)
            {
                return folderBrowser.SelectedPath;
            }

            throw new GetPathFailedException("Saving Path");
        }

        public string GetFile(string ext, string startDirectory)
        {
            VistaOpenFileDialog fileDialog = SetupBasicFileDialog(ext);
            fileDialog.InitialDirectory = startDirectory;

            if(fileDialog.ShowDialog() == true)
            {
                return fileDialog.FileName;
            }

            throw new GetPathFailedException("Load Path");
        }

        public VistaOpenFileDialog SetupBasicFileDialog(string ext)
        {
            VistaOpenFileDialog fileDialog = new VistaOpenFileDialog();
            fileDialog.DefaultExt = ext;
            fileDialog.Multiselect = false;
            fileDialog.Title = "Wybierz plik";

            return fileDialog;
        }

        public string GetFile(string ext)
        {
            VistaOpenFileDialog fileDialog = SetupBasicFileDialog(ext);

            if (fileDialog.ShowDialog() == true)
            {
                return fileDialog.FileName;
            }

            throw new GetPathFailedException("Load Path");
        }

        public bool Confirm(string message, string title)
        {
            var result = MessageBox.Show(message, title, MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(result == MessageBoxResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Message(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.None);
        }
    }
}
