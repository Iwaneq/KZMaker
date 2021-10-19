using KZMaker.Core.Commands;
using KZMaker.Core.Navigation;
using KZMaker.Core.Services;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace KZMaker.Core.ViewModels
{
    public class HomeViewModel : MvxViewModel
    {
        public TopCardsViewModel TopCardsViewModel { get; set; }
        public IMvxCommand<ViewModelType> NavigateCommand { get; set; }
        public ILoadBrowsedCardCommand LoadCardCommand { get; set; }

        public HomeViewModel(INavigator navigator, ILoadCardsService loadCardsService, ILoadBrowsedCardCommand loadCardCommand)
        {
            NavigateCommand = new NavigateCommand(navigator);
            TopCardsViewModel = new TopCardsViewModel(loadCardsService);
            LoadCardCommand = loadCardCommand;
        }
    }
}
