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

namespace KZMaker.WPF.Controls
{
    /// <summary>
    /// Logika interakcji dla klasy NavButton.xaml
    /// </summary>
    public partial class NavButton : UserControl
    {
        public string ButtonText
        {
            get { return (string)GetValue(ButtonTextProperty); }
            set { SetValue(ButtonTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ButtonText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ButtonTextProperty =
            DependencyProperty.Register("ButtonText", typeof(string), typeof(NavButton), new PropertyMetadata(null));



        public PathGeometry IconPath
        {
            get { return (PathGeometry)GetValue(IconPathProperty); }
            set { SetValue(IconPathProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IconPath.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconPathProperty =
            DependencyProperty.Register("IconPath", typeof(PathGeometry), typeof(NavButton), new PropertyMetadata(null));



        public NavButton()
        {
            InitializeComponent();
        }
    }
}
