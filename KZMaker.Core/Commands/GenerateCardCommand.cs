using KZMaker.Core.Navigation;
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
    public class GenerateCardCommand : IMvxCommand
    {
        private readonly ICreateCardService _createCardService;
        private readonly CreateCardViewModel _viewModel;
        private readonly SaveCardViewModel _saveViewModel;
        private readonly INavigator _navigator;
        private readonly INotificationsService _notificationsService;

        public event EventHandler CanExecuteChanged;

        public GenerateCardCommand(ICreateCardService createCardService,
            CreateCardViewModel viewModel,
            SaveCardViewModel saveViewModel, 
            INavigator navigator,
            INotificationsService notificationsService)
        {
            _createCardService = createCardService;
            _viewModel = viewModel;
            _saveViewModel = saveViewModel;
            _navigator = navigator;
            _notificationsService = notificationsService;
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
            Bitmap bitmap;

            try
            {
                bitmap = await _createCardService.GenerateCard(_viewModel.Zastep,
                        _viewModel.Date,
                        _viewModel.Place,
                        _viewModel.Points.ToList(),
                        _viewModel.RequiredItems.ToList());
            }
            catch (Exception ex)
            {
                _notificationsService.UpdateMessage($"Błąd: {ex.Message}", true);
                return;
            }

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
