using KZMaker.Core;
using KZMaker.Core.Commands;
using KZMaker.Core.Commands.Interfaces;
using KZMaker.Core.Services;
using KZMaker.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KZMaker.WPF.Services
{
    class ChangeCommandsService : IChangeCommandsService
    {
        private readonly CreateCardViewModel _createCardViewModel;
        private readonly SaveCardViewModel _saveCardViewModel;

        private readonly ISaveCardCommand _manualSaveCard;
        private readonly ISaveCardCommand _automaticSaveCard;

        private readonly ISaveDraftCommand _manualSaveDraft;
        private readonly ISaveDraftCommand _automaticSaveDraft;

        public ChangeCommandsService(CreateCardViewModel createCardViewModel, 
            SaveCardViewModel saveCardViewModel, 
            ISaveCardCommand manualSaveCard, 
            ISaveCardCommand automaticSaveCard, 
            ISaveDraftCommand manualSaveDraft, 
            ISaveDraftCommand automaticSaveDraft)
        {
            _createCardViewModel = createCardViewModel;
            _saveCardViewModel = saveCardViewModel;

            _manualSaveCard = manualSaveCard;
            _automaticSaveCard = automaticSaveCard;

            _manualSaveDraft = manualSaveDraft;
            _automaticSaveDraft = automaticSaveDraft;
        }

        public void ChangeToAutomaticSave()
        {
            _createCardViewModel.ChangeCommand(_automaticSaveDraft);
            _saveCardViewModel.ChangeCommand(_automaticSaveCard);
        }

        public void ChangeToManualSave()
        {
            _createCardViewModel.ChangeCommand(_manualSaveDraft);
            _saveCardViewModel.ChangeCommand(_manualSaveCard);
        }

        public void ChangeSavingMode()
        {
            if (AppSettings.Default.IsSavingManually)
            {
                ChangeToManualSave();
            }
            else
            {
                ChangeToAutomaticSave();
            }
        }
    }
}
