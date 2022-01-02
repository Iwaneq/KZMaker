using KZMaker.Core.Models;
using KZMaker.Core.Services;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KZMaker.Core.ViewModels
{
    public class CardListViewModel : MvxViewModel
    {
        private readonly ILoadCardsService _loadCardsService;
        private string _defaultCardsFolder;

        private MvxObservableCollection<CardFile> cardFiles = new MvxObservableCollection<CardFile>();

        public MvxObservableCollection<CardFile> CardFiles
        {
            get { return cardFiles; }
            set 
            {
                cardFiles = value;
                RaisePropertyChanged(() => CardFiles);
            }
        }

        public CardListViewModel(ILoadCardsService loadCardsService)
        {
            _loadCardsService = loadCardsService;

            Initialize();
        }

        public override Task Initialize()
        {
            _defaultCardsFolder = AppSettings.Default.SavingPath;

            UpdateCardList();

            return base.Initialize();
        }

        public void UpdateCardList()
        {
            CardFiles = new MvxObservableCollection<CardFile>(_loadCardsService.LoadCards(_defaultCardsFolder));
        }

    }
}
