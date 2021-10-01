using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KZMaker.WPF.Controls.Extensions
{
    public class HomeButtonExtensions
    {
        public static readonly DependencyProperty IconPathProperty = DependencyProperty.RegisterAttached("IconPath", typeof(object), typeof(HomeButtonExtensions));

        public static void SetIconPath(UIElement element, object value)
        {
            element.SetValue(IconPathProperty, value);
        }

        public static object GetIconPath(UIElement element)
        {
            return (object)element.GetValue(IconPathProperty);
        }


        public static readonly DependencyProperty ButtonDescriptionProperty = DependencyProperty.RegisterAttached("ButtonDescription", typeof(object), typeof(HomeButtonExtensions));

        public static void SetButtonDescription(UIElement element, object value)
        {
            element.SetValue(ButtonDescriptionProperty, value);
        }

        public static object GetButtonDescription(UIElement element)
        {
            return (object)element.GetValue(ButtonDescriptionProperty);
        }
    }
}
