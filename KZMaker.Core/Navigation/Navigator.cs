using KZMaker.Core.ViewModels.Factories;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KZMaker.Core.Navigation
{
    public class Navigator : MvxNotifyPropertyChanged, INavigator
    {
        private MvxViewModel _currentViewModel;

        public MvxViewModel CurrentViewModel
        {
            get { return _currentViewModel; }
            set 
            {
                _currentViewModel = value;
                RaisePropertyChanged(() => CurrentViewModel);
            }
        }

        private readonly DelegateViewModelFactory _viewModelFactory;

        public Navigator(DelegateViewModelFactory viewModelFactory)
        {
            _viewModelFactory = viewModelFactory;
        }


        public void Navigate(ViewModelType type)
        {
            CurrentViewModel = _viewModelFactory.CreateViewModel(type);
        }
    }
}
