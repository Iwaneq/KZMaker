using KZMaker.Core.Models;
using KZMaker.Core.Navigation;
using KZMaker.Core.Services;
using KZMaker.Core.ViewModels;
using KZMaker.Core.ViewModels.Factories;
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

        public override async void Initialize()
        {
            var services = Mvx.IoCProvider;

            //CreateViewModels
            services.RegisterSingleton<CreateViewModel<HomeViewModel>>(() => 
            {
                return new HomeViewModel(
                    services.Resolve<INavigator>());
            });
            services.RegisterSingleton<CreateViewModel<CreateCardViewModel>>(() =>
            {
                return new CreateCardViewModel(services.Resolve<ICreateCardService>());
            });

            services.RegisterSingleton<DelegateViewModelFactory>(
                new DelegateViewModelFactory(
                    services.Resolve<CreateViewModel<HomeViewModel>>(),
                    services.Resolve<CreateViewModel<CreateCardViewModel>>()));

            services.RegisterSingleton<INavigator>(
                new Navigator(
                    services.Resolve<DelegateViewModelFactory>()));

            services.RegisterType<ICreateCardService, CreateCardService>();

            RegisterAppStart<MainViewModel>();
        }
    }
}
