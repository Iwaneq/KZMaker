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
    public class TopCardsViewModel : MvxViewModel
    {
        private readonly ILoadCardsService _loadCardsService;
        private string _defaultCardsFolder;

        private MvxObservableCollection<CardFile> _cardFiles;

        public MvxObservableCollection<CardFile> CardFiles
        {
            get { return _cardFiles; }
            set { _cardFiles = value; }
        }


        public TopCardsViewModel(ILoadCardsService loadCardsService)
        {
            _loadCardsService = loadCardsService;

            _defaultCardsFolder = AppSettings.Default.SavingPath;
            UpdateList();
        }

        public void UpdateList()
        {
            var list = _loadCardsService.LoadCards(_defaultCardsFolder).Take(5).ToList();
            CardFiles = new MvxObservableCollection<CardFile>(list);
        }
    }
}
