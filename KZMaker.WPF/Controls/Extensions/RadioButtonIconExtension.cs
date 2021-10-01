using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace KZMaker.WPF.Controls.Extensions
{
    public class RadioButtonIconExtension
    {
        public static readonly DependencyProperty IconPathProperty = DependencyProperty.RegisterAttached("IconPath", typeof(object), typeof(RadioButtonIconExtension));

        public static void SetIconPath(UIElement element, object value)
        {
            element.SetValue(IconPathProperty, value);
        }

        public static object GetIconPath(UIElement element)
        {
            return (object)element.GetValue(IconPathProperty);
        }
    }
}
