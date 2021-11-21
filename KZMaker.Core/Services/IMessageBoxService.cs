using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KZMaker.Core.Services
{
    public interface IMessageBoxService
    {
        string GetSavingPath(string startDirectory);
        string GetSavingPath();
        string GetFile(string ext, string startDirectory);
        string GetFile(string ext);

        bool Confirm(string message, string title);
        void Message(string message, string title);
    }
}
