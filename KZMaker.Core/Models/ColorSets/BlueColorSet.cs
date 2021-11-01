using KZMaker.Core.ResourceManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KZMaker.Core.Models.ColorSets
{
    public class BlueColorSet : BaseColorSet
    {
        public BlueColorSet()
        {
            ThemeName = "BlueTheme";
            Resources = new ResourcesModel()
            {
                PrimaryColor1 = "#0057db",
                PrimaryColor2 = "#0C6CFE",
                SecondaryColor1 = "#004CBD",
                SecondaryColor2 = "#0056d6",
                ActiveColor1 = "#BF0808",
                SuccessColor1 = "#ffffff",
                FontColor = "#ffffff"
            };
        }
    }
}
