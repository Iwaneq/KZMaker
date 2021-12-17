//using KZMaker.Core.Commands;
//using KZMaker.Core.ViewModels;
//using MvvmCross;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace KZMaker.Core.Services
//{
//    public class ChangeCommandsService : IChangeCommandsService
//    {
//        private readonly CreateCardViewModel _createCardViewModel;
//        private readonly SaveCardViewModel _saveCardViewModel;

//        public ChangeCommandsService(CreateCardViewModel createCardViewModel, SaveCardViewModel saveCardViewModel)
//        {
//            _createCardViewModel = createCardViewModel;
//            _saveCardViewModel = saveCardViewModel;
//        }

//        public void ChangeToAutomaticSave()
//        {
//            var services = Mvx.IoCProvider;

//            _createCardViewModel.SaveDraftCommand = services.Resolve<SaveDraftCommand>();
//            _saveCardViewModel.SaveCardCommand = services.Resolve<SaveCardCommand>();
//        }

//        public void ChangeToManualSave()
//        {
//            var services = Mvx.IoCProvider;

//            _createCardViewModel.SaveDraftCommand = services.Resolve<ISaveDraftCommand>();
//            _saveCardViewModel.SaveCardCommand = services.Resolve<ISaveBrowsedCardCommand>();
//        }

//        public void CheckSavingMode()
//        {
//            if (AppSettings.Default.IsSavingManually)
//            {
//                ChangeToManualSave();
//            }
//            else
//            {
//                ChangeToAutomaticSave();
//            }
//        }
//    }
//}