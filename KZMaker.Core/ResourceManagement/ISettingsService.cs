using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KZMaker.Core.ResourceManagement
{
    public interface ISettingsService
    {
        void UpdateSettings(string savingPath, string themeColor);
    }
}
