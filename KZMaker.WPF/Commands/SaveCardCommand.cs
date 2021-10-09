using KZMaker.Core.Commands;
using KZMaker.Core.Services;
using KZMaker.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KZMaker.WPF.Commands
{
    public class SaveCardCommand : ISaveCardCommand
    {
        private SaveCardViewModel _saveCardViewModel;
        private readonly ISaveCardService _saveCardService;
        private readonly IMessageBoxService _messageBoxService;

        public SaveCardCommand(
            ISaveCardService saveCardService, 
            IMessageBoxService messageBoxService)
        {
            _saveCardService = saveCardService;
            _messageBoxService = messageBoxService;
        }

        public event EventHandler CanExecuteChanged;

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
            throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            _saveCardViewModel = (SaveCardViewModel)parameter;

            SaveCard();
        }

        public void RaiseCanExecuteChanged()
        {
            throw new NotImplementedException();
        }

        public void SaveCard()
        {
            //Get path
            string path = _messageBoxService.GetSavingPath();

            //Save Card
            _saveCardService.SaveCard(_saveCardViewModel.Card, _saveCardViewModel.FileName, path);
        }

        public void UpdateCommand(Bitmap card, string fileName)
        {
            throw new NotImplementedException();
        }
    }
}
