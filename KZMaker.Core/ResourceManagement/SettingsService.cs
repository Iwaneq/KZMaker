﻿using KZMaker.Core.Models;
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

        public void UpdateSettings(Settings settings)
        {
            //Update saving path
            AppSettings.Default.SavingPath = settings.SavingPath;

            //Update resources
            AppSettings.Default.Theme = settings.ThemeColor;
            _resourcesService.CheckTheme();

            //Update file saving mode
            AppSettings.Default.IsSavingManually = settings.IsSavingManually;
            _changeCommandsService.ChangeSavingMode();

            //Update zastep name
            AppSettings.Default.DefaultZastep = settings.DefaultZastep;

            AppSettings.Default.Save();
        }
    }
}
