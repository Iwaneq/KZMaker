using KZMaker.Core.Commands;
using KZMaker.Core.Navigation;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KZMaker.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private INavigator _navigator;

        public INavigator Navigator
        {
            get { return _navigator; }
            set 
            { 
                _navigator = value;
                RaisePropertyChanged(() => Navigator);
            }
        }

        public IMvxCommand<ViewModelType> NavigateCommand { get; set; }

        public MainViewModel(INavigator navigator)
        {
            Navigator = navigator;

            NavigateCommand = new NavigateCommand(Navigator);
        }


        public override Task Initialize()
        {
            NavigateCommand?.Execute(ViewModelType.Home);

            return base.Initialize();
        }
    }
}
