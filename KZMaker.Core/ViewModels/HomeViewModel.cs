using KZMaker.Core.Commands;
using KZMaker.Core.Navigation;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace KZMaker.Core.ViewModels
{
    public class HomeViewModel : MvxViewModel
    {
        public IMvxCommand<ViewModelType> NavigateCommand { get; set; }

        public HomeViewModel(INavigator navigator)
        {
            NavigateCommand = new NavigateCommand(navigator);
        }
    }
}
