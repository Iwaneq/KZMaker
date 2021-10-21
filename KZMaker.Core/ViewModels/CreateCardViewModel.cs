using KZMaker.Core.Commands;
using KZMaker.Core.Models;
using KZMaker.Core.Navigation;
using KZMaker.Core.Services;
using KZMaker.Core.ViewModels.Progress;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KZMaker.Core.ViewModels
{
    public class CreateCardViewModel : MvxViewModel
    {
        public WritePointsViewModel WritePointsViewModel { get; set; }
        public WriteRequiredItemsViewModel WriteRequiredItemsViewModel { get; set; }
        public MessageViewModel ProgressMessageViewModel { get; set; }

        private string _zastep;

        public string Zastep
        {
            get { return _zastep; }
            set 
            {
                _zastep = value;
                RaisePropertyChanged(() => Zastep);
            }
        }

        private DateTime _date;

        public DateTime Date
        {
            get { return _date; }
            set 
            {
                _date = value;
                RaisePropertyChanged(() => Date);
                RaisePropertyChanged(() => FileName);
            }
        }

        public string FileName => $"{Date.Day}{Date.ToString("MMMM")}{Date.Year}";

        private string _place;

        public string Place
        {
            get { return _place; }
            set 
            {
                _place = value;
                RaisePropertyChanged(() => Place);
            }
        }


        public MvxObservableCollection<Point> Points 
        {
            get { return WritePointsViewModel.Points; }
            set
            {
                
            }
        }

        public MvxObservableCollection<RequiredItem> RequiredItems => WriteRequiredItemsViewModel.RequiredItems;

        public IMvxCommand GenerateCardCommand { get; set; }
        public ISaveBrowsedDraftCommand SaveDraftCommand { get; set; }

        public CreateCardViewModel(ICreateCardService createCardService, SaveCardViewModel saveViewModel, INavigator navigator, ISaveCardService saveCardService, ISaveBrowsedDraftCommand saveDraftCommand)
        {
            WritePointsViewModel = new WritePointsViewModel();
            WriteRequiredItemsViewModel = new WriteRequiredItemsViewModel();
            ProgressMessageViewModel = new MessageViewModel();

            GenerateCardCommand = new GenerateCardCommand(createCardService, this, saveViewModel, navigator);

            SaveDraftCommand = saveDraftCommand;

            Date = DateTime.Now;
        }

        public void UpdateProgressMessage(string message)
        {
            ProgressMessageViewModel.Message = message;
        }

        public void UpdateViewModel(Card card)
        {
            Zastep = card.Zastep;
            Date = card.Date;
            Place = card.Place;
            Points.ReplaceWith(card.Points);
            RequiredItems.ReplaceWith(card.RequiredItems);
        }
    }
}
