using KZMaker.Core.Models;
using KZMaker.Core.Navigation;
using KZMaker.Core.Services;
using System.Text.Json;
using System.Text.Json.Serialization;
using KZMaker.Core.ViewModels;
using KZMaker.Core.ViewModels.Factories;
using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace KZMaker.Core
{
    public class App : MvxApplication
    {
        public AppSettings AppSettings;
        public App()
        {

        }

        public static AppSettings GetSettings()
        {
            string settingsString = File.ReadAllText("appsettings.json");
            return JsonSerializer.Deserialize<AppSettings>(settingsString);
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
                return services.GetSingleton<CreateCardViewModel>();
            });
            services.RegisterSingleton<CreateViewModel<SaveCardViewModel>>(() =>
            {
                return services.GetSingleton<SaveCardViewModel>();
            });
            services.RegisterSingleton<CreateViewModel<CardListViewModel>>(() =>
            {
                return services.GetSingleton<CardListViewModel>();
            });

            services.RegisterSingleton<DelegateViewModelFactory>(
                new DelegateViewModelFactory(
                    services.Resolve<CreateViewModel<HomeViewModel>>(),
                    services.Resolve<CreateViewModel<CreateCardViewModel>>(),
                    services.Resolve<CreateViewModel<SaveCardViewModel>>(),
                    services.Resolve<CreateViewModel<CardListViewModel>>()));

            services.RegisterSingleton<INavigator>(
                new Navigator(
                    services.Resolve<DelegateViewModelFactory>()));

            services.RegisterType<ICreateCardService, CreateCardService>();
            services.RegisterType<ISaveCardService, SaveCardService>();

            services.RegisterSingleton<CreateCardViewModel>(() =>
            {
                return services.IoCConstruct<CreateCardViewModel>();
            });
            services.RegisterSingleton<SaveCardViewModel>(() =>
            {
                return services.IoCConstruct<SaveCardViewModel>();
            });
            services.RegisterSingleton<CardListViewModel>(() =>
            {
                return services.IoCConstruct<CardListViewModel>();
            });

            RegisterAppStart<MainViewModel>();
        }
    }
}
