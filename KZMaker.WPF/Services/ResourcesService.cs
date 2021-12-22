using KZMaker.Core;
using KZMaker.Core.ResourceManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace KZMaker.WPF.Services
{
    public class ResourcesService : IResourcesService
    {
        public ResourceDictionary ThemeDictionary {
            get
            {
                return App.Current.Resources.MergedDictionaries[0];
            }
        }
        public void ChangeTheme(Uri themeUri)
        {
            ThemeDictionary.MergedDictionaries.Clear();
            ThemeDictionary.MergedDictionaries.Add(new ResourceDictionary() { Source = themeUri });
        }

        public void CheckTheme()
        {
            switch (AppSettings.Default.Theme)
            {
                case "Dark":
                    ChangeTheme(new Uri("Resources/Themes/DarkTheme.xaml", UriKind.Relative));
                    break;
                case "Blue":
                    ChangeTheme(new Uri("Resources/Themes/BlueTheme.xaml", UriKind.Relative));
                    break;
                case "Light":
                    ChangeTheme(new Uri("Resources/Themes/LightTheme.xaml", UriKind.Relative));
                    break;
                case "Purple":
                    ChangeTheme(new Uri("Resources/Themes/PurpleTheme.xaml", UriKind.Relative));
                    break;
                case "Green":
                    ChangeTheme(new Uri("Resources/Themes/GreenTheme.xaml", UriKind.Relative));
                    break;
                default:
                    throw new NotImplementedException($"Application cannot set/find theme: {AppSettings.Default.Theme}");
            }
        }
    }
}
