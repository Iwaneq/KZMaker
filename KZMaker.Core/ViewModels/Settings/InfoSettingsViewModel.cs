using KZMaker.Core.Services;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KZMaker.Core.ViewModels.Settings
{
    public class InfoSettingsViewModel : MvxViewModel
    {
        private readonly IUpdateService _updateService;


        private string _version;
        public string Version
        {
            get { return _version; }
            set 
            { 
                _version = value;
                RaisePropertyChanged(() => Version);
            }
        }


        public IMvxCommand OpenRepoCommand { get; set; }
        public IMvxCommand OpenFacebookCommand { get; set; }
        public IMvxCommand OpenWebsiteCommand { get; set; }
        public IMvxCommand OpenFormCommand { get; set; }
        public IMvxCommand OpenBugFormCommand { get; set; }


        public InfoSettingsViewModel(IUpdateService updateService)
        {
            OpenRepoCommand = new MvxCommand(() => GoToSite("https://github.com/Iwaneq/KZMaker"));
            OpenWebsiteCommand = new MvxCommand(() => GoToSite("https://kzmaker.netlify.app"));
            OpenFormCommand = new MvxCommand(() => GoToSite("https://forms.gle/Dbs1iRXAqrr7KSXr5"));
            OpenBugFormCommand = new MvxCommand(() => GoToSite("https://forms.gle/ZpeY4tJY2Zn1516Z9"));


            _updateService = updateService;

            UpdateVersionText();
        }


        public void UpdateVersionText()
        {
            Version = $"Wersja aplikacji: {_updateService.GetCurrentVersion()}";
        }

        private void GoToSite(string url)
        {
            var ps = new ProcessStartInfo(url)
            {
                UseShellExecute = true,
                Verb = "open"
            };

            Process.Start(ps);
        }
    }
}
