﻿using KZMaker.Core.Models;
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
using KZMaker.Core.Commands;
using MvvmCross.Plugin;
using KZMaker.Core.ResourceManagement;

namespace KZMaker.Core
{
    public class App : MvxApplication
    {
        public App()
        {
            
        }

        public override void LoadPlugins(IMvxPluginManager pluginManager)
        {
            pluginManager.EnsurePluginLoaded<MvvmCross.Plugin.MethodBinding.Plugin>();

            base.LoadPlugins(pluginManager);
        }

        //public static void SaveAppSettings(AppSettings appSettings)
        //{
        //    string settingsString = JsonSerializer.Serialize<AppSettings>(appSettings);
        //    File.WriteAllText("appsettings.json", settingsString);
        //}

        public override void Initialize()
        {
            var services = Mvx.IoCProvider;

            //CreateViewModels
            services.RegisterSingleton<CreateViewModel<HomeViewModel>>(() => 
            {
                return new HomeViewModel(
                    services.Resolve<INavigator>(),
                    services.Resolve<ILoadCardsService>(),
                    services.Resolve<ILoadBrowsedCardCommand>());
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
            services.RegisterSingleton<CreateViewModel<SettingsViewModel>>(() =>
            {
                var vm = services.GetSingleton<SettingsViewModel>();
                vm.CleanMessages();
                return vm;
            });

            services.RegisterSingleton<DelegateViewModelFactory>(
                new DelegateViewModelFactory(
                    services.Resolve<CreateViewModel<HomeViewModel>>(),
                    services.Resolve<CreateViewModel<CreateCardViewModel>>(),
                    services.Resolve<CreateViewModel<SaveCardViewModel>>(),
                    services.Resolve<CreateViewModel<CardListViewModel>>(),
                    services.Resolve<CreateViewModel<SettingsViewModel>>()));

            services.RegisterSingleton<INavigator>(
                new Navigator(
                    services.Resolve<DelegateViewModelFactory>()));

            services.RegisterType<ICreateCardService, CreateCardService>();
            services.RegisterType<ISaveCardService, SaveCardService>();
            services.RegisterType<ILoadCardsService, LoadCardsService>();
            services.RegisterType<ISettingsService, SettingsService>();
            services.RegisterType<IChangeCommandsService, ChangeCommandsService>();

            services.RegisterType<SaveCardCommand>();
            services.RegisterType<SaveDraftCommand>();

            services.RegisterSingleton<LoadCardCommand>(() =>
            {
                return services.IoCConstruct<LoadCardCommand>();
            });

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
            services.RegisterSingleton<SettingsViewModel>(() =>
            {
                return services.IoCConstruct<SettingsViewModel>();
            });

            //Checking AppSettings
            services.Resolve<IResourcesService>().CheckTheme();
            services.Resolve<IChangeCommandsService>().CheckSavingMode();

            RegisterAppStart<MainViewModel>();
        }
    }
}
