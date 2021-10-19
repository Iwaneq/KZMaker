using KZMaker.Core.Commands;
using MvvmCross.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KZMaker.Core.Models
{
    public class CardFile
    {
        public DateTime Date { get; set; }
        public string FileName { get; set; }
        public string Path { get; set; }

        public IMvxCommand<CardFile> LoadCardCommand { get; set; }

        public CardFile(LoadCardCommand loadCardCommand)
        {
            LoadCardCommand = loadCardCommand;
        }
    }
}
