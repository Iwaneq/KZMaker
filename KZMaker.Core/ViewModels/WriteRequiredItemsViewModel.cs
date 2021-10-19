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
    public class WriteRequiredItemsViewModel : MvxViewModel
    {
        private MvxObservableCollection<RequiredItem> _requiredItems = new MvxObservableCollection<RequiredItem>(){};

        public MvxObservableCollection<RequiredItem> RequiredItems
        {
            get { return _requiredItems; }
            set 
            {
                _requiredItems = value;
                RaisePropertyChanged(() => RequiredItems);
            }
        }

        private RequiredItem _selectedItem;

        public RequiredItem SelectedItem
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

        public WriteRequiredItemsViewModel()
        {
            AddNewItemCommand = new MvxCommand(AddNewItem);
            DeleteSelectedItemCommand = new MvxCommand(DeleteSelectedItem);
        }

        private void AddNewItem()
        {
            RequiredItems.Add(new RequiredItem() { Item = "" });
        }
        private void DeleteSelectedItem()
        {
            RequiredItems.Remove(SelectedItem);
        }
    }
}
