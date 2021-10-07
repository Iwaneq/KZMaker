using KZMaker.Core.Commands;
using KZMaker.Core.Models;
using KZMaker.Core.Navigation;
using KZMaker.Core.Services;
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


        public List<Point> Points => WritePointsViewModel.Points.ToList();

        public List<RequiredItem> RequiredItems => WriteRequiredItemsViewModel.RequiredItems.ToList();

        public IMvxCommand GenerateCardCommand { get; set; }
        public IMvxCommand SaveDraftCommand { get; set; }

        public CreateCardViewModel(ICreateCardService createCardService, SaveCardViewModel saveViewModel, INavigator navigator, ISaveCardService saveCardService)
        {
            WritePointsViewModel = new WritePointsViewModel();
            WriteRequiredItemsViewModel = new WriteRequiredItemsViewModel();

            GenerateCardCommand = new GenerateCardCommand(createCardService, this, saveViewModel, navigator);
            SaveDraftCommand = new SaveDraftCommand(this, saveCardService);

            Date = DateTime.Now;
        }

    }
}
