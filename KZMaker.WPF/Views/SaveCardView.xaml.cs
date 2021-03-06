using KZMaker.Core.ViewModels;
using KZMaker.WPF.Services;
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

namespace KZMaker.WPF.Views
{
    [MvxContentPresentation]
    [MvxViewFor(typeof(SaveCardViewModel))]
    public partial class SaveCardView : MvxWpfView
    {
        public SaveCardView()
        {
            InitializeComponent();
        }
    }
}
