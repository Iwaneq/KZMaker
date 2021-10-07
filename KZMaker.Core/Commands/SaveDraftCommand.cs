using KZMaker.Core.Services;
using KZMaker.Core.ViewModels;
using MvvmCross.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KZMaker.Core.Commands
{
    public class SaveDraftCommand : IMvxCommand
    {
        private readonly CreateCardViewModel _viewModel;
        private readonly ISaveCardService _saveCardService;

        public SaveDraftCommand(CreateCardViewModel createCardViewModel, ISaveCardService saveCardService)
        {
            _viewModel = createCardViewModel;
            _saveCardService = saveCardService;
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
            _saveCardService.SaveDraft(_viewModel.Zastep, _viewModel.Date, _viewModel.Place, _viewModel.Points, _viewModel.RequiredItems, _viewModel.FileName);
        }

        public void RaiseCanExecuteChanged()
        {
            throw new NotImplementedException();
        }
    }
}
