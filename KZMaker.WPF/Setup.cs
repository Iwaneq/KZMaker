using KZMaker.Core;
using KZMaker.Core.Commands;
using KZMaker.Core.ResourceManagement;
using KZMaker.Core.Services;
using KZMaker.Core.ViewModels;
using KZMaker.WPF.Commands;
using KZMaker.WPF.Services;
using Microsoft.Extensions.Logging;
using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.Platforms.Wpf.Binding;
using MvvmCross.Platforms.Wpf.Core;
using Serilog;
using Serilog.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KZMaker.WPF
{
    public class Setup : MvxWpfSetup<Core.App>
    {
        protected override void InitializeFirstChance(IMvxIoCProvider iocProvider)
        {
            var services = Mvx.IoCProvider;

            services.RegisterType<IPrintCardCommand, Commands.PrintCardCommand>();
            services.RegisterType<ILoadBrowsedCardCommand, LoadBrowsedCardCommand>();

            services.RegisterType<IMessageBoxService, MessageBoxService>();
            services.RegisterType<IPrintService, PrintService>();
            services.RegisterType<IResourcesService, ResourcesService>();
            services.RegisterSingleton<IUpdateService>(services.IoCConstruct<UpdateService>());

            if (AppSettings.Default.IsCheckingUpdatesAtStart)
            {
                Task.Run(() => services.Resolve<IUpdateService>().CheckForUpdate(true)).Wait(); 
            }

            services.RegisterType<IChangeCommandsService>(() => new ChangeCommandsService(
                services.GetSingleton<CreateCardViewModel>(),
                services.GetSingleton<SaveCardViewModel>(),
                services.IoCConstruct<SaveBrowsedCardCommand>(),
                services.IoCConstruct<SaveCardCommand>(),
                services.IoCConstruct<SaveBrowsedDraftCommand>(),
                services.IoCConstruct<SaveDraftCommand>()));

            base.InitializeFirstChance(iocProvider);
        }

        protected override ILoggerFactory CreateLogFactory()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Trace()
                .CreateLogger();

            return new SerilogLoggerFactory();
        }

        protected override ILoggerProvider CreateLogProvider()
        {
            return new SerilogLoggerProvider();
        }
    }
}
