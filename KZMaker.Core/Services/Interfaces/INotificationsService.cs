using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KZMaker.Core.Services.Interfaces
{
    public interface INotificationsService
    {
        void UpdateMessage(string message, bool isError);
    }
}
