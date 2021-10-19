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

namespace KZMaker.Core.Commands
{
    public class LoadCardCommand : IMvxCommand<CardFile>
    {
        private readonly ILoadCardsService _loadCardsService;
        private readonly CreateCardViewModel _createCardViewModel;
        private readonly INavigator _navigator;

        public LoadCardCommand(ILoadCardsService loadCardsService, 
            CreateCardViewModel createCardViewModel, 
            INavigator navigator)
        {
            _loadCardsService = loadCardsService;
            _createCardViewModel = createCardViewModel;
            _navigator = navigator;
        }

        public event EventHandler CanExecuteChanged;

        private void LoadCard(CardFile file)
        {
            //Load card
            Card card = _loadCardsService.LoadCard(file.Path);

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
