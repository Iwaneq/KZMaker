using KZMaker.Core;
using KZMaker.Core.ViewModels.Settings;
using MvvmCross.Platforms.Wpf.Presenters.Attributes;
using MvvmCross.Platforms.Wpf.Views;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KZMaker.WPF.Views.Settings
{
    [MvxContentPresentation]
    [MvxViewFor(typeof(UpdatesSettingsViewModel))]
    public partial class UpdatesSettingsView : MvxWpfView
    {
        public UpdatesSettingsView()
        {
            InitializeComponent();

            if (!AppSettings.Default.IsCheckingUpdatesAtStart)
            {
                manualCheckOption.IsChecked = true;
            }
            else
            {
                automaticCheckOption.IsChecked = true;
            }
        }
    }
}
