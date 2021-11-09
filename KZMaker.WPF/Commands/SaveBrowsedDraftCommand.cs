using KZMaker.Core.Commands;
using KZMaker.Core.Exceptions;
using KZMaker.Core.Services;
using KZMaker.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KZMaker.WPF.Commands
{
    class SaveBrowsedDraftCommand : ISaveDraftCommand
    {
        private CreateCardViewModel _viewModel;
        private readonly IMessageBoxService _messageBoxService;
        private readonly ISaveCardService _saveCardService;

        public SaveBrowsedDraftCommand(ISaveCardService saveCardService, IMessageBoxService messageBoxService)
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
            SaveDraft();
        }

        public void Execute(object parameter)
        {
            _viewModel = (CreateCardViewModel)parameter;

            SaveDraft();
        }

        private void SaveDraft()
        {
            _viewModel.UpdateProgressMessage("");

            //Get FileName/Path
            string savingPath = "";

            try
            {
                savingPath = _messageBoxService.GetSavingPath();
            }
            catch (GetPathFailedException)
            {
                return;
            }

            //Save draft
            _saveCardService.SaveDraft(_viewModel.Zastep, _viewModel.Date, _viewModel.Place, _viewModel.Points.ToList(), _viewModel.RequiredItems.ToList(), _viewModel.FileName, savingPath);

            _viewModel.UpdateProgressMessage("Zapisano!");
        }

        public void RaiseCanExecuteChanged()
        {
            throw new NotImplementedException();
        }
    }
}
