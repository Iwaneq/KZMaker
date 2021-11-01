using KZMaker.Core.ResourceManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KZMaker.Core.Models.ColorSets
{
    public class BlackColorSet : BaseColorSet
    {
        public BlackColorSet()
        {
            ThemeName = "BlackTheme";
            Resources = new ResourcesModel()
            {
                PrimaryColor1 = "#212121",
                PrimaryColor2 = "#2E2E2E",
                SecondaryColor1 = "#1C1C1C",
                SecondaryColor2 = "#212020",
                ActiveColor1 = "#0099F0",
                SuccessColor1 = "Green",
                FontColor = "White"
            };
        }
    }
}
