using KZMaker.Core.Models.ColorSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KZMaker.Core.ResourceManagement
{
    public enum ThemeColor
    {
        Black,
        White,
        Blue,
        Green,
        Purple
    }

    public interface IResourcesService
    {
        void ChangeTheme(BaseColorSet colorSet);
        void SetTheme(BaseColorSet colorSet);
    }
}
