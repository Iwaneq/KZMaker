using KZMaker.Core.Models.ColorSets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace KZMaker.Core.ResourceManagement
{
    public class SettingsService : ISettingsService
    {
        private readonly IResourcesService _resourcesService;
        private readonly BaseColorSet _blackColorSet = new BlackColorSet();
        private readonly BaseColorSet _blueColorSet = new BlueColorSet();

        public SettingsService(IResourcesService resourcesService)
        {
            _resourcesService = resourcesService;
        }

        public AppSettings LoadSettings()
        {
            string settingsString = File.ReadAllText("appsettings.json");
            return JsonSerializer.Deserialize<AppSettings>(settingsString);
        }

        public void SaveSettings(AppSettings appSettings)
        {
            string settingsString = JsonSerializer.Serialize<AppSettings>(appSettings);
            File.WriteAllText("appsettings.json", settingsString);
        }

        public void UpdateSettings(AppSettings appSettings, string savingPath, ThemeColor themeColor)
        {
            //Update saving path
            appSettings.SavingPath = savingPath;

            //Update resources
            appSettings.Resources = ChangeTheme(themeColor);

            //Update file saving mode

            //Update zastep name

            //Save Settings
            SaveSettings(appSettings);
        }

        private ResourcesModel ChangeTheme(ThemeColor themeColor)
        {
            switch (themeColor)
            {
                case ThemeColor.Black:
                    _resourcesService.SetTheme(_blackColorSet);
                    return _blackColorSet.Resources;
                case ThemeColor.Blue:
                    _resourcesService.SetTheme(_blueColorSet);
                    return _blueColorSet.Resources;
            }
            return null;
        }
    }
}
