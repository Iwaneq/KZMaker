using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KZMaker.Core.ViewModels.Progress
{
    public class MessageViewModel : MvxViewModel
    {
        private string _message;

        public string Message
        {
            get { return _message; }
            set 
            {
                _message = value;
                RaisePropertyChanged(() => Message);
            }
        }

    }
}
