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


        public static readonly DependencyProperty BigFontProperty = DependencyProperty.RegisterAttached("BigFont", typeof(int), typeof(HomeButtonExtensions));
        public static void SetBigFont(UIElement element, int value)
        {
            element.SetValue(BigFontProperty, value);
        }
        public static int GetBigFont(UIElement element)
        {
            return (int)element.GetValue(BigFontProperty);
        }


        public static readonly DependencyProperty SmallFontProperty = DependencyProperty.RegisterAttached("SmallFont", typeof(object), typeof(HomeButtonExtensions));
        public static void SetSmallFont(UIElement element, object value)
        {
            element.SetValue(SmallFontProperty, value);
        }
        public static object GetSmallFont(UIElement element)
        {
            return (object)element.GetValue(SmallFontProperty);
        }


        public static readonly DependencyProperty SpacingProperty = DependencyProperty.RegisterAttached("Spacing", typeof(Thickness), typeof(HomeButtonExtensions));
        public static void SetSpacing(UIElement element, Thickness value)
        {
            element.SetValue(SpacingProperty, value);
        }
        public static Thickness GetSpacing(UIElement element)
        {
            return (Thickness)element.GetValue(SpacingProperty);
        }
    }
}
