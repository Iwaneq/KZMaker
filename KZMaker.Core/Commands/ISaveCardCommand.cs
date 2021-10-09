using MvvmCross.Commands;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KZMaker.Core.Commands
{
    public interface ISaveCardCommand : IMvxCommand
    {
        void SaveCard();
        void UpdateCommand(Bitmap card, string fileName);
    }
}
