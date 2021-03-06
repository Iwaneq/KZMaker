using KZMaker.Core.Commands;
using KZMaker.Core.Models;
using KZMaker.Core.Navigation;
using KZMaker.Core.Services;
using KZMaker.Core.Services.Interfaces;
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
        private readonly INotificationsService _notificationService;
        public WritePointsViewModel WritePointsViewModel { get; set; }
        public WriteRequiredItemsViewModel WriteRequiredItemsViewModel { get; set; }

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
            set { WritePointsViewModel.Points = value; }
        }

        public MvxObservableCollection<RequiredItem> RequiredItems 
        {
            get { return WriteRequiredItemsViewModel.RequiredItems; }
            set { WriteRequiredItemsViewModel.RequiredItems = value; }
        }

        public IMvxCommand GenerateCardCommand { get; set; }
        public ISaveDraftCommand SaveDraftCommand { get; set; }
        public IMvxCommand CleanViewCommand { get; set; }

        public CreateCardViewModel(ICreateCardService createCardService, 
            SaveCardViewModel saveViewModel, 
            INavigator navigator, 
            ISaveCardService saveCardService, 
            INotificationsService notificationsService)
        {
            _notificationService = notificationsService;

            WritePointsViewModel = new WritePointsViewModel();
            WriteRequiredItemsViewModel = new WriteRequiredItemsViewModel();

            GenerateCardCommand = new GenerateCardCommand(createCardService, this, saveViewModel, navigator, notificationsService);
            CleanViewCommand = new MvxCommand(CleanView);

            Date = DateTime.Now;
            Zastep = AppSettings.Default.DefaultZastep;
        }

        public void UpdateViewModel(Card card)
        {
            if (card == null) return;

            Zastep = card.Zastep;
            Date = card.Date;
            Place = card.Place;

            if(card.Points != null)
            {
                Points = new MvxObservableCollection<Point>(card.Points);
            }

            if (card.RequiredItems != null)
            {
                RequiredItems = new MvxObservableCollection<RequiredItem>(card.RequiredItems); 
            }
        }

        private void CleanView()
        {
            Date = DateTime.Now;
            Zastep = AppSettings.Default.DefaultZastep;

            Place = "";
            Points.Clear();
            RequiredItems.Clear();

            _notificationService.UpdateMessage("Wyczyszczono.", false);
        }

        public void ChangeCommand(ISaveDraftCommand command)
        {
            if (command == null) return;

            SaveDraftCommand = command;
        }
    }
}
