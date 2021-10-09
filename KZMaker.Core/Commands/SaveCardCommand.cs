using KZMaker.Core.Services;
using MvvmCross.Commands;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KZMaker.Core.Commands
{
    public class SaveCardCommand : IMvxCommand
    {
        private readonly ISaveCardService _saveCardService;
        private Bitmap _card;
        private string _fileName;

        public SaveCardCommand(ISaveCardService saveCardService,
            Bitmap card, 
            string fileName)
        {
            _saveCardService = saveCardService;
            _card = card;
            _fileName = fileName;
        }

        public event EventHandler CanExecuteChanged;
        public void UpdateFileName(string fileName)
        {
            _fileName = fileName;
        }

        public bool CanExecute()
        {
            return true;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute()
        {
            SaveCard();
        }

        public void Execute(object parameter)
        {
            SaveCard();
        }

        private void SaveCard()
        {
            _saveCardService.SaveCard(_card, _fileName, "");
        }

        public void RaiseCanExecuteChanged()
        {
            throw new NotImplementedException();
        }
    }
}
