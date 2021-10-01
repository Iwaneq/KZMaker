using KZMaker.Core.Models;
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

        private List<Point> _points;

        public List<Point> Points
        {
            get { return _points; }
            set 
            {
                _points = value;
                RaisePropertyChanged(() => Points);
            }
        }

        private List<string> _requiredItems;

        public List<string> RequiredItems
        {
            get { return _requiredItems; }
            set 
            { 
                _requiredItems = value;
                RaisePropertyChanged(() => RequiredItems);
            }
        }

        public IMvxCommand PrintCardCommand { get; set; }
        public IMvxCommand SaveCardCommand { get; set; }

    }
}
