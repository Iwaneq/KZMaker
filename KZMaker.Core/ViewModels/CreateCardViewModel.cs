using KZMaker.Core.Commands;
using KZMaker.Core.Models;
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

        private DateTime _date = DateTime.Now;

        public DateTime Date
        {
            get { return _date; }
            set 
            {
                _date = value;
                RaisePropertyChanged(() => Date);
            }
        }

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


        public List<Point> Points => WritePointsViewModel.Points;

        public List<RequiredItem> RequiredItems => WriteRequiredItemsViewModel.RequiredItems.ToList();

        public IMvxCommand GenerateCardCommand { get; set; }

        public CreateCardViewModel(ICreateCardService createCardService)
        {
            WritePointsViewModel = new WritePointsViewModel();
            WriteRequiredItemsViewModel = new WriteRequiredItemsViewModel();

            GenerateCardCommand = new GenerateCardCommand(createCardService, this);
        }

    }
}
