using KZMaker.Core.Models.ColorSets;
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
        public void ChangeTheme(BaseColorSet colorSet)
        {
            SetTheme(colorSet);
            //SetTheme("#ECECEC", "White", "#C6C5C5", "#ECECEC", "#BF0808", "Green", "Black");
        }

        public void SetTheme(BaseColorSet colorSet)
        {
            var colors = colorSet.Resources;
            var resources = Application.Current.Resources;

            resources["PrimaryColor1"] = ColorConverter.ConvertFromString(colors.PrimaryColor1);
            resources["PrimaryColor2"] = ColorConverter.ConvertFromString(colors.PrimaryColor2);
            resources["SecondaryColor1"] = ColorConverter.ConvertFromString(colors.SecondaryColor1);
            resources["SecondaryColor2"] = ColorConverter.ConvertFromString(colors.SecondaryColor2);
            resources["ActiveColor1"] = ColorConverter.ConvertFromString(colors.ActiveColor1);
            resources["SuccessColor1"] = ColorConverter.ConvertFromString(colors.SuccessColor1);
            resources["FontColor1"] = ColorConverter.ConvertFromString(colors.FontColor);
        }
    }
}
