using KZMaker.Core.Commands;
using KZMaker.Core.Exceptions;
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
    public class SaveBrowsedCardCommand : ISaveBrowsedCardCommand
    {
        private SaveCardViewModel _saveCardViewModel;
        private readonly ISaveCardService _saveCardService;
        private readonly IMessageBoxService _messageBoxService;

        public SaveBrowsedCardCommand(
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
            _saveCardViewModel.ProgressMessageViewModel.Message = "";
            //Get path

            string path = "";

            try
            {
                path = _messageBoxService.GetSavingPath();
            }
            catch (GetPathFailedException)
            {
                return;
            }

            //Save Card
            _saveCardService.SaveCard(_saveCardViewModel.Card, _saveCardViewModel.FileName, path);

            //Update ProgressMessageViewModel
            _saveCardViewModel.ProgressMessageViewModel.Message = $"Karta '{_saveCardViewModel.FileName}' została zapisana";
        }
    }
}
