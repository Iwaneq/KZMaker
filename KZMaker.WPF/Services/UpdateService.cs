using KZMaker.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Squirrel;
using System.Windows;

namespace KZMaker.WPF.Services
{
    public class UpdateService : IUpdateService
    {
        private readonly IMessageBoxService _messageBoxService;
        public UpdateService(IMessageBoxService messageBoxService)
        {
            _messageBoxService = messageBoxService;
        }

        public async Task CheckForUpdate(bool isAppLoading)
        {
            if (System.Diagnostics.Debugger.IsAttached) 
            {
                await Task.Delay(1500);
                _messageBoxService.Message("Nie masz żadnych aktualizacji do pobrania.", "Aktualizacja");
                return;
            } 
            using (var manager = await UpdateManager.GitHubUpdateManager(@"https://github.com/Iwaneq/KZMaker"))
            {
                try
                {
                    var updateInfo = await manager.CheckForUpdate();

                    if (updateInfo.ReleasesToApply.Count > 0)
                    {
                        var canContiune = _messageBoxService.Confirm($"Masz do pobrania {updateInfo.ReleasesToApply.Count} aktualizacji. Czy chcesz kontynuować?", "Aktualizacja");

                        if (canContiune)
                        {
                            await manager.UpdateApp();

                            UpdateManager.RestartApp();
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (isAppLoading) return;
                        _messageBoxService.Message("Nie masz żadnych aktualizacji do pobrania.", "Aktualizacja");
                    }
                }
                catch (Exception ex)
                {
                    _messageBoxService.Message($"Podczas procesu aktualizacji nastąpił błąd: {ex.Message}", "Aktualizacja");
                }
            }
        }

        public string GetCurrentVersion()
        {
            if (System.Diagnostics.Debugger.IsAttached)
            {
                return "dev";
            }
            using (var manager = new UpdateManager(""))
            {
                return manager.CurrentlyInstalledVersion().ToString();
            }
        }
    }
}
