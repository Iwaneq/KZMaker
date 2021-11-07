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

        public SettingsService(IResourcesService resourcesService)
        {
            _resourcesService = resourcesService;
        }

        public void UpdateSettings(string savingPath, string themeColor)
        {
            //Update saving path
            AppSettings.Default.SavingPath = savingPath;

            //Update resources
            AppSettings.Default.Theme = themeColor;
            _resourcesService.CheckTheme();

            //Update file saving mode

            //Update zastep name
        }
    }
}
