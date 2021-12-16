using KZMaker.Core.State;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KZMaker.Core.ViewModels.Progress
{
    public class NotificationViewModel : MvxViewModel
    {
        private NotificationsStore _notificationsStore;

        public bool IsError
        {
            get { return _notificationsStore.IsMessageError; }
            set { }
        }

        public string Message
        {
            get { return _notificationsStore.Message; }
            set { }
        }



        private bool _isVisible;
        public bool IsVisible
        {
            get { return _isVisible; }
            set 
            { 
                _isVisible = value;
                RaisePropertyChanged(() => IsVisible);
            }
        }


        public IMvxCommand HideNotificationCommand { get; set; }

        public NotificationViewModel(NotificationsStore store)
        {
           IsVisible = false;

            _notificationsStore = store;
            _notificationsStore.StateChanged += _notificationsStore_StateChanged;

            HideNotificationCommand = new MvxCommand(HideNotification);
        }

        ~NotificationViewModel()
        {
            _notificationsStore.StateChanged -= _notificationsStore_StateChanged;
        }

        private void _notificationsStore_StateChanged()
        {
            IsVisible = false;

            RaisePropertyChanged(() => IsError);
            RaisePropertyChanged(() => Message);

            IsVisible = true;
        }

        private void HideNotification()
        {
            IsVisible = false;
        }
    }
}
