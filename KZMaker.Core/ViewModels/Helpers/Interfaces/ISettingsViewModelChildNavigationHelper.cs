using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KZMaker.Core.ViewModels.Helpers.Interfaces
{
    public interface ISettingsViewModelChildNavigationHelper
    {
        public MvxViewModel NextViewModel(MvxViewModel currentViewModel, List<MvxViewModel> childViewModels);
        public MvxViewModel PreviousViewModel(MvxViewModel currentViewModel, List<MvxViewModel> childViewModels);
        public string GetTitle(int currIndex);
    }
}
