using KZMaker.Core.Commands;
using KZMaker.Core.Services;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KZMaker.Core.ViewModels.Settings
{
    public class UpdatesSettingsViewModel : MvxViewModel
    {
        private bool _isCheckingUpdatesAtStart = AppSettings.Default.IsCheckingUpdatesAtStart;
        public bool IsCheckingUpdatesAtStart
        {
            get { return _isCheckingUpdatesAtStart; }
            set 
            {
                _isCheckingUpdatesAtStart = value;
                RaisePropertyChanged(() => IsCheckingUpdatesAtStart);
            }
        }


        public IMvxCommand CheckForUpdateCommand { get; set; }


        public UpdatesSettingsViewModel(IUpdateService updateService)
        {
            CheckForUpdateCommand = new CheckForUpdateCommand(updateService);
        }
    }
}
