using KZMaker.Core.Navigation;
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
    public class GenerateCardCommand : IMvxCommand
    {
        private readonly ICreateCardService _createCardService;
        private readonly CreateCardViewModel _viewModel;
        private readonly SaveCardViewModel _saveViewModel;
        private readonly INavigator _navigator;
        public event EventHandler CanExecuteChanged;

        public GenerateCardCommand(ICreateCardService createCardService,
            CreateCardViewModel viewModel,
            SaveCardViewModel saveViewModel, 
            INavigator navigator)
        {
            _createCardService = createCardService;
            _viewModel = viewModel;
            _saveViewModel = saveViewModel;
            _navigator = navigator;
        }

        public bool CanExecute()
        {
            return true;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute()
        {
            await GenerateCard();
        }

        public async void Execute(object parameter)
        {
            await GenerateCard();
        }

        private async Task GenerateCard()
        {
            //Generate card
            var bitmap = await _createCardService.GenerateCard(_viewModel.Zastep,
                _viewModel.Date,
                _viewModel.Place,
                _viewModel.Points.ToList(),
                _viewModel.RequiredItems.ToList());

            //Send data to SaveCardViewModel
            _saveViewModel.UpdateCard(bitmap, _viewModel.FileName);

            _navigator.Navigate(ViewModelType.SaveCard);
        }

        public void RaiseCanExecuteChanged()
        {
            throw new NotImplementedException();
        }
    }
}
