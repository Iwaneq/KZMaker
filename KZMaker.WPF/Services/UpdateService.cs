using KZMaker.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Squirrel;

namespace KZMaker.WPF.Services
{
    public class UpdateService : IUpdateService
    {
        UpdateManager manager;
        private readonly IMessageBoxService _messageBoxService;
        public UpdateService(IMessageBoxService messageBoxService)
        {
            _messageBoxService = messageBoxService;
        }

        private async Task GetManager()
        {
            manager = await UpdateManager.GitHubUpdateManager(@"https://github.com/Iwaneq/KZMaker");
        }

        public async Task CheckForUpdate()
        {
            if (manager == null) await GetManager();

            var updateInfo = await manager.CheckForUpdate();

            if(updateInfo.ReleasesToApply.Count > 0)
            {
                var canContiune = _messageBoxService.Confirm($"Masz do pobrania {updateInfo.ReleasesToApply} aktualizacji. Czy chcesz kontynuować?", "Aktualizacja");

                if (canContiune)
                {
                    await manager.UpdateApp();
                }
                else
                {
                    return;
                }
            }
        }
    }
}
