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
        private readonly CreateViewModel<SettingsViewModel> _createSettingsViewModel;

        public DelegateViewModelFactory(CreateViewModel<HomeViewModel> createHomeViewModel,
            CreateViewModel<CreateCardViewModel> createCardViewModel,
            CreateViewModel<SaveCardViewModel> createSaveCardViewModel,
            CreateViewModel<CardListViewModel> createCardListViewModel, 
            CreateViewModel<SettingsViewModel> createSettingsViewModel)
        {
            _createHomeViewModel = createHomeViewModel;
            _createCardViewModel = createCardViewModel;
            _createSaveCardViewModel = createSaveCardViewModel;
            _createCardListViewModel = createCardListViewModel;
            _createSettingsViewModel = createSettingsViewModel;
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
                case ViewModelType.Settings:
                    return _createSettingsViewModel();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
