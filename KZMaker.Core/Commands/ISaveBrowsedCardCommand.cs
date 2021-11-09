using MvvmCross.Commands;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KZMaker.Core.Commands
{
    public interface ISaveBrowsedCardCommand : IMvxCommand
    {
        void SaveCard();
    }
}
