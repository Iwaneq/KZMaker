using KZMaker.Core.Services;
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
        private SaveCardViewModel _saveCardViewModel;

        public SaveCardCommand(ISaveCardService saveCardService)
        {
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
                _saveCardViewModel.ProgressMessageViewModel.Message = $"Błąd: {ex.Message}";
                return;
            }
            _saveCardViewModel.ProgressMessageViewModel.Message = $"Zapisano {_saveCardViewModel.FileName}";
        }

        public void RaiseCanExecuteChanged()
        {
            throw new NotImplementedException();
        }
    }
}
