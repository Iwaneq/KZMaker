using KZMaker.WPF.Controls.Extensions;
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
    /// Logika interakcji dla klasy SmallCardFileView.xaml
    /// </summary>
    public partial class SmallCardFileView : CardFileViewBase
    {
        public SmallCardFileView()
        {
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            LoadFile();
        }
    }
}
