using KZMaker.Core.Commands;
using KZMaker.Core.Commands.Interfaces;
using KZMaker.Core.Services;
using KZMaker.Core.ViewModels.Progress;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KZMaker.Core.ViewModels
{
    public class SaveCardViewModel : MvxViewModel
    {
        private Bitmap _card;

        public Bitmap Card
        {
            get { return _card; }
            set 
            {
                _card = value;
                RaisePropertyChanged(() => Card);
            }
        }

        private string _fileName;

        public string FileName
        {
            get { return _fileName; }
            set 
            {
                _fileName = value;
                RaisePropertyChanged(() => FileName);
            }
        }


        public ISaveCardCommand SaveCardCommand { get; set; }
        public IPrintCardCommand PrintCardCommand { get; set; }

        public SaveCardViewModel(IPrintCardCommand printCardCommand)
        {
            Card = new Bitmap(Path.Combine(Environment.CurrentDirectory, @"Resources\", "karta.png"));

            PrintCardCommand = printCardCommand;
        }

        public void UpdateCard(Bitmap card, string fileName)
        {
            if(card == null) return;

            Card = card;
            FileName = fileName;
        }

        public void ChangeCommand(ISaveCardCommand command)
        {
            if (command == null) return;

            SaveCardCommand = command;
        }
    }
}
