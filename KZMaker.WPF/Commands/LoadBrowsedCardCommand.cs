using KZMaker.Core.Commands;
using KZMaker.Core.Exceptions;
using KZMaker.Core.Models;
using KZMaker.Core.Navigation;
using KZMaker.Core.Services;
using KZMaker.Core.ViewModels;
using MvvmCross.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KZMaker.WPF.Commands
{
    public class LoadBrowsedCardCommand : ILoadBrowsedCardCommand
    {
        private readonly IMessageBoxService _messageBoxService;
        private readonly ILoadCardsService _loadCardsService;
        private readonly CreateCardViewModel _createCardViewModel;
        private readonly INavigator _navigator;

        public LoadBrowsedCardCommand(IMessageBoxService messageBoxService,
            ILoadCardsService loadCardsService,
            CreateCardViewModel createCardViewModel, 
            INavigator navigator)
        {
            _messageBoxService = messageBoxService;
            _loadCardsService = loadCardsService;
            _createCardViewModel = createCardViewModel;
            _navigator = navigator;
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
            LoadCard();
        }

        public void Execute(object parameter)
        {
            LoadCard();
        }

        private void LoadCard()
        {
            //Get Path
            string file = "";
            try
            {
                file = _messageBoxService.GetFile(".card");
            }
            catch (GetPathFailedException)
            {
                return;
            }

            //Load Card
            Card card = _loadCardsService.LoadCard(file);
            _createCardViewModel.UpdateViewModel(card);

            //Navigate to CreateCardViewModel
            _navigator.Navigate(ViewModelType.CreateCard);
        }

        public void RaiseCanExecuteChanged()
        {
            throw new NotImplementedException();
        }
    }
}
