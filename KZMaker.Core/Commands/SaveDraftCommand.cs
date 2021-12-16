using KZMaker.Core.Services;
using KZMaker.Core.Services.Interfaces;
using KZMaker.Core.ViewModels;
using MvvmCross.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KZMaker.Core.Commands
{
    public class SaveDraftCommand : ISaveDraftCommand
    {
        private readonly CreateCardViewModel _viewModel;
        private readonly ISaveCardService _saveCardService;
        private readonly INotificationsService _notificationsService;

        public SaveDraftCommand(CreateCardViewModel createCardViewModel, ISaveCardService saveCardService, INotificationsService notificationsService)
        {
            _viewModel = createCardViewModel;
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
            SaveDraft();
        }

        public void Execute(object parameter)
        {
            SaveDraft();
        }

        private void SaveDraft()
        {
            try
            {
                _saveCardService.SaveDraft(_viewModel.Zastep, _viewModel.Date, _viewModel.Place, _viewModel.Points.ToList(), _viewModel.RequiredItems.ToList(), _viewModel.FileName, AppSettings.Default.SavingPath);
            }
            catch (Exception ex)
            {
                _notificationsService.UpdateMessage($"Błąd: {ex.Message}", true);
                return;
            }
            _notificationsService.UpdateMessage("Zapisano szkic!", false);
        }

        public void RaiseCanExecuteChanged()
        {
            throw new NotImplementedException();
        }
    }
}
