using KZMaker.Core.ViewModels;
using MvvmCross;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KZMaker.Core
{
    public class App : MvxApplication
    {
        public App()
        {

        }

        public override void Initialize()
        {
            RegisterAppStart<MainViewModel>();
        }
    }
}
