using KZMaker.Core.Commands;
using KZMaker.Core.Navigation;
using KZMaker.Core.State;
using KZMaker.Core.ViewModels.Progress;
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

        private NotificationViewModel _notificationVM;

        public NotificationViewModel NotificationViewModel
        {
            get { return _notificationVM; }
            set 
            {
                _notificationVM = value;
                RaisePropertyChanged(() => NotificationViewModel);
            }
        }


        public IMvxCommand<ViewModelType> NavigateCommand { get; set; }

        public MainViewModel(INavigator navigator, NotificationsStore notificationsStore)
        {
            Navigator = navigator;
            NotificationViewModel = new NotificationViewModel(notificationsStore);

            NavigateCommand = new NavigateCommand(Navigator);
        }


        public override Task Initialize()
        {
            NavigateCommand?.Execute(ViewModelType.Home);

            return base.Initialize();
        }
    }
}
