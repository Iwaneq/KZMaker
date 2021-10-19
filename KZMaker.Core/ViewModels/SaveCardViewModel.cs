using KZMaker.Core.Commands;
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
        private readonly ISaveCardService _saveCardService;
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

        private MessageViewModel _progressMessageViewModel;

        public MessageViewModel ProgressMessageViewModel
        {
            get { return _progressMessageViewModel; }
            set 
            {
                _progressMessageViewModel = value;
                RaisePropertyChanged(() => ProgressMessageViewModel);
            }
        }



        public IMvxCommand SaveCardCommand { get; set; }

        public SaveCardViewModel(ISaveCardService saveCardService, ISaveCardCommand saveCardCommand)
        {
            Card = new Bitmap(Path.Combine(Environment.CurrentDirectory, @"Resources\", "karta.png"));

            _saveCardService = saveCardService;

            ProgressMessageViewModel = new MessageViewModel();

            SaveCardCommand = saveCardCommand;
        }

        public void UpdateCard(Bitmap card, string fileName)
        {
            Card = card;
            FileName = fileName;
            ProgressMessageViewModel.Message = "";
        }
    }
}
