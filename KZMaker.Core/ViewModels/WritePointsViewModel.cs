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
    public class WritePointsViewModel : MvxViewModel
    {
        private MvxObservableCollection<Point> _points = new MvxObservableCollection<Point>(){};

        public MvxObservableCollection<Point> Points
        {
            get { return _points; }
            set 
            {
                _points = value;
                RaisePropertyChanged(() => Points);
            }
        }

        private Point _selectedItem;

        public Point SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                RaisePropertyChanged(() => SelectedItem);
            }
        }


        public IMvxCommand AddNewItemCommand { get; set; }
        public IMvxCommand DeleteSelectedItemCommand { get; set; }

        public WritePointsViewModel()
        {
            AddNewItemCommand = new MvxCommand(AddNewItem);
            DeleteSelectedItemCommand = new MvxCommand(DeleteSelectedItem);
        }

        private void AddNewItem()
        {
            Points.Add(new Point());
        }
        private void DeleteSelectedItem()
        {
            Points.Remove(SelectedItem);
        }

    }
}
