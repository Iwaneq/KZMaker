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
        private readonly CreateViewModel<SaveCardViewModel> _createSaveCardViewModel;
        private readonly CreateViewModel<CardListViewModel> _createCardListViewModel;

        public DelegateViewModelFactory(CreateViewModel<HomeViewModel> createHomeViewModel,
            CreateViewModel<CreateCardViewModel> createCardViewModel,
            CreateViewModel<SaveCardViewModel> createSaveCardViewModel, 
            CreateViewModel<CardListViewModel> createCardListViewModel)
        {
            _createHomeViewModel = createHomeViewModel;
            _createCardViewModel = createCardViewModel;
            _createSaveCardViewModel = createSaveCardViewModel;
            _createCardListViewModel = createCardListViewModel;
        }

        public MvxViewModel CreateViewModel(ViewModelType type)
        {
            switch (type)
            {
                case ViewModelType.Home:
                    return _createHomeViewModel();
                case ViewModelType.CreateCard:
                    return _createCardViewModel();
                case ViewModelType.SaveCard:
                    return _createSaveCardViewModel();
                case ViewModelType.CardList:
                    return _createCardListViewModel();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
