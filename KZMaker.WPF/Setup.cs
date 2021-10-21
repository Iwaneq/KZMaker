using KZMaker.Core.Commands;
using KZMaker.Core.Services;
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
            Mvx.IoCProvider.RegisterType<IMessageBoxService, MessageBoxService>();
            Mvx.IoCProvider.RegisterType<IPrintService, PrintService>();
            Mvx.IoCProvider.RegisterType<ISaveCardCommand, Commands.SaveBrowsedCardCommand>();
            Mvx.IoCProvider.RegisterType<ISaveBrowsedDraftCommand, Commands.SaveBrowsedDraftCommand>();
            Mvx.IoCProvider.RegisterType<ILoadBrowsedCardCommand, Commands.LoadBrowsedCardCommand>();
            Mvx.IoCProvider.RegisterType<IPrintCardCommand, Commands.PrintCardCommand>();

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
