using KZMaker.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Wpf.Presenters.Attributes;
using MvvmCross.Platforms.Wpf.Views;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    [MvxViewFor(typeof(MainViewModel))]
    public partial class MainView : MvxWpfView
    {
        private readonly Window _mainWindow;

        public MainView()
        {
            _mainWindow = App.Current.MainWindow;

            InitializeComponent();
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(_mainWindow.WindowState == WindowState.Maximized)
            {
                _mainWindow.WindowState = WindowState.Normal;
                return;
            }

            _mainWindow.DragMove();
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void maximizeButton_Click(object sender, RoutedEventArgs e)
        {
            if(_mainWindow.WindowState == WindowState.Normal)
            {
                _mainWindow.WindowState = WindowState.Maximized;
            }
            else
            {
                _mainWindow.WindowState = WindowState.Normal;
            }
        }

        private void minimizeButton_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.WindowState = WindowState.Minimized;
        }
    }
}
