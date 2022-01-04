using KZMaker.Core.ViewModels.Helpers.Interfaces;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KZMaker.Core.ViewModels.Helpers
{
    public class SettingsViewModelChildNavigationHelper : ISettingsViewModelChildNavigationHelper
    {
        public MvxViewModel NextViewModel(MvxViewModel currentViewModel, List<MvxViewModel> childViewModels)
        {
            if(currentViewModel == null)
            {
                throw new ArgumentNullException(nameof(currentViewModel));
            }
            else if(childViewModels == null || childViewModels.Count == 0)
            {
                throw new ArgumentNullException(nameof(childViewModels));
            }

            int viewModelsCount = childViewModels.Count();
            int currIndex = childViewModels.FindIndex(x => x == currentViewModel);

            if(currIndex == -1)
            {
                throw new ArgumentOutOfRangeException(nameof(currentViewModel), $"Couldn't find {currentViewModel} in implemented Child ViewModels list");
            }

            //If CurrentViewModel is last in list
            if (currentViewModel == childViewModels[viewModelsCount - 1])
            {
                int newIndex = 0;

                return childViewModels[newIndex];
            }
            else
            {
                int newIndex = currIndex + 1;

                return childViewModels[newIndex];
            }
        }

        public MvxViewModel PreviousViewModel(MvxViewModel currentViewModel, List<MvxViewModel> childViewModels)
        {
            if (currentViewModel == null)
            {
                throw new ArgumentNullException(nameof(currentViewModel));
            }
            else if (childViewModels == null || childViewModels.Count == 0)
            {
                throw new ArgumentNullException(nameof(childViewModels));
            }

            int viewModelsCount = childViewModels.Count();
            int currIndex = childViewModels.FindIndex(x => x == currentViewModel);

            if (currIndex == -1)
            {
                throw new ArgumentOutOfRangeException(nameof(currentViewModel), $"Couldn't find {currentViewModel} in implemented Child ViewModels list");
            }

            //If CurrentViewModel is first in list
            if (currentViewModel == childViewModels[0])
            {
                int newIndex = viewModelsCount - 1;

                return childViewModels[newIndex];
            }
            else
            {
                int newIndex = currIndex - 1;

                return childViewModels[newIndex];
            }
        }

        public string GetTitle(int currIndex)
        {
            switch (currIndex)
            {
                case 0:
                    return "Ogólne";
                case 1:
                    return "Zapis";
                case 2:
                    return "Aktualizacje";
                case 3:
                    return "Informacje";
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
