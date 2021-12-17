using KZMaker.Core.Commands;
using KZMaker.Core.Commands.Interfaces;
using KZMaker.Core.Exceptions;
using KZMaker.Core.Services;
using KZMaker.Core.Services.Interfaces;
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
    public class SaveBrowsedCardCommand : ISaveCardCommand
    {
        private SaveCardViewModel _saveCardViewModel;
        private readonly ISaveCardService _saveCardService;
        private readonly IMessageBoxService _messageBoxService;
        private readonly INotificationsService _notificationsService;

        public SaveBrowsedCardCommand(
            ISaveCardService saveCardService,
            IMessageBoxService messageBoxService, 
            INotificationsService notificationsService)
        {
            _saveCardService = saveCardService;
            _messageBoxService = messageBoxService;
            _notificationsService = notificationsService;
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
            _notificationsService.UpdateMessage($"Karta '{_saveCardViewModel.FileName}' została zapisana!", false);
        }
    }
}
