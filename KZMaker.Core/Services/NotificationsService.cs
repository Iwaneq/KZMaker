using KZMaker.Core.Services.Interfaces;
using KZMaker.Core.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KZMaker.Core.Services
{
    public class NotificationsService : INotificationsService
    {
        private NotificationsStore _notificationsStore;

        public NotificationsService(NotificationsStore store)
        {
            _notificationsStore = store;
        }

        public void UpdateMessage(string message, bool isError)
        {
            _notificationsStore.Message = message;
            _notificationsStore.IsMessageError = isError;
        }
    }
}
