using KZMaker.Core.Models;
using MvvmCross.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KZMaker.WPF.Controls.Extensions
{
    public class CardFileViewBase : UserControl
    {
        public CardFile File { get; set; }
        public IMvxCommand<CardFile> LoadCardCommand { get; set; }

        public void LoadFile()
        {
            File = (CardFile)DataContext;
            LoadCardCommand = File.LoadCardCommand;

            LoadCardCommand?.Execute(File);
        }

    }
}
