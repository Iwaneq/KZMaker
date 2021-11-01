using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KZMaker.Core.Navigation
{
    public delegate TViewModel CreateViewModel<TViewModel>() where TViewModel : MvxViewModel;

    public enum ViewModelType
    {
        Home,
        CreateCard,
        SaveCard,
        CardList,
        Settings
    }

    public interface INavigator
    {
        public MvxViewModel CurrentViewModel { get; set; }
        public void Navigate(ViewModelType type);
    }
}
