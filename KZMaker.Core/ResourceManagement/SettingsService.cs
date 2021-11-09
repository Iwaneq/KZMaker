using KZMaker.Core.Services;
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
        private readonly IChangeCommandsService _changeCommandsService;

        public SettingsService(IResourcesService resourcesService,
            IChangeCommandsService changeCommandsService)
        {
            _resourcesService = resourcesService;
            _changeCommandsService = changeCommandsService;
        }

        public void UpdateSettings(string savingPath, string themeColor, bool isSavingManually, string defaultZastep)
        {
            //Update saving path
            AppSettings.Default.SavingPath = savingPath;

            //Update resources
            AppSettings.Default.Theme = themeColor;
            _resourcesService.CheckTheme();

            //Update file saving mode
            AppSettings.Default.IsSavingManually = isSavingManually;
            _changeCommandsService.CheckSavingMode();

            //Update zastep name
            AppSettings.Default.DefaultZastep = defaultZastep;

            AppSettings.Default.Save();
        }
    }
}
