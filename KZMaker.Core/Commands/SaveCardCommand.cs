using KZMaker.Core.Services;
using KZMaker.Core.Services.Interfaces;
using KZMaker.Core.ViewModels;
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
        private readonly INotificationsService _notificationsService;
        private SaveCardViewModel _saveCardViewModel;

        public SaveCardCommand(ISaveCardService saveCardService, INotificationsService notificationsService)
        {
            _saveCardService = saveCardService;
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
            SaveCard();
        }

        public void Execute(object parameter)
        {
            _saveCardViewModel = (SaveCardViewModel)parameter;

            SaveCard();
        }

        private void SaveCard()
        {
            try
            {
                _saveCardService.SaveCard(_saveCardViewModel.Card, _saveCardViewModel.FileName, AppSettings.Default.SavingPath);
            }
            catch (Exception ex)
            {
                _notificationsService.UpdateMessage($"Błąd: {ex.Message}", true);
                return;
            }

            _notificationsService.UpdateMessage($"Zapisano kartę: {_saveCardViewModel.FileName}!", false);
        }

        public void RaiseCanExecuteChanged()
        {
            throw new NotImplementedException();
        }
    }
}
