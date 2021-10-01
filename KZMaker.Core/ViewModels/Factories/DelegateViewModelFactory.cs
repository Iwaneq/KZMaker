using KZMaker.Core.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KZMaker.Core.ViewModels.Factories
{
    public class DelegateViewModelFactory
    {
        private readonly CreateViewModel<HomeViewModel> _createHomeViewModel;
        private readonly CreateViewModel<CreateCardViewModel> _createCardViewModel;

        public DelegateViewModelFactory(CreateViewModel<HomeViewModel> createHomeViewModel, 
            CreateViewModel<CreateCardViewModel> createCardViewModel)
        {
            _createHomeViewModel = createHomeViewModel;
            _createCardViewModel = createCardViewModel;
        }

        public MvxViewModel CreateViewModel(ViewModelType type)
        {
            switch (type)
            {
                case ViewModelType.Home:
                    return _createHomeViewModel();
                case ViewModelType.CreateCard:
                    return _createCardViewModel();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
