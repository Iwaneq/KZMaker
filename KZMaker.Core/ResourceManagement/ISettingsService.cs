using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KZMaker.Core.ResourceManagement
{
    public interface ISettingsService
    {
        void UpdateSettings(AppSettings appSettings, string savingPath, ThemeColor themeColor);
        void SaveSettings(AppSettings appSettings);
        AppSettings LoadSettings();
    }
}
