using KZMaker.Core.Models;
using KZMaker.Core.Navigation;
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
    public class LoadCardCommand : ILoadCardCommand
    {
        private readonly ILoadCardsService _loadCardsService;
        private readonly CreateCardViewModel _createCardViewModel;
        private readonly INavigator _navigator;
        private readonly INotificationsService _notificationsService;

        public LoadCardCommand(ILoadCardsService loadCardsService,
            CreateCardViewModel createCardViewModel,
            INavigator navigator,
            INotificationsService notificationsService)
        {
            _loadCardsService = loadCardsService;
            _createCardViewModel = createCardViewModel;
            _navigator = navigator;
            _notificationsService = notificationsService;
        }

        public event EventHandler CanExecuteChanged;

        private void LoadCard(CardFile file)
        {
            //Load card
            Card card;

            try
            {
                card = _loadCardsService.LoadCard(file.Path);
            }
            catch (Exception ex)
            {
                _notificationsService.UpdateMessage($"Błąd: {ex.Message}", true);
                return;
            }

            //Open card in CreateCardViewModel
            _createCardViewModel.UpdateViewModel(card);
            _navigator.Navigate(ViewModelType.CreateCard);
        }

        public void RaiseCanExecuteChanged()
        {
            throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(CardFile parameter)
        {
            LoadCard(parameter);
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public bool CanExecute(CardFile parameter)
        {
            return true;
        }
    }
}
