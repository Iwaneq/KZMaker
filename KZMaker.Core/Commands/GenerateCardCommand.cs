using KZMaker.Core.Services;
using KZMaker.Core.ViewModels;
using MvvmCross.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KZMaker.Core.Commands
{
    public class GenerateCardCommand : IMvxCommand
    {
        private readonly ICreateCardService _createCardService;
        private readonly CreateCardViewModel _viewModel;
        public event EventHandler CanExecuteChanged;

        public GenerateCardCommand(ICreateCardService createCardService, CreateCardViewModel viewModel)
        {
            _createCardService = createCardService;
            _viewModel = viewModel;
        }

        public bool CanExecute()
        {
            return true;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute()
        {
            //Generate card
            var bitmap = await _createCardService.GenerateCard(_viewModel.Zastep,
                _viewModel.Date,
                _viewModel.Place,
                _viewModel.Points,
                _viewModel.RequiredItems);

            //Send data to SaveCardViewModel
            bitmap.Save("C:\\data\\GraphicsTest\\test.png");
        }

        public async void Execute(object parameter)
        {
            //Generate card
            var bitmap = await _createCardService.GenerateCard(_viewModel.Zastep,
                _viewModel.Date,
                _viewModel.Place,
                _viewModel.Points,
                _viewModel.RequiredItems);

            //Send data to SaveCardViewModel
            bitmap.Save("C:\\data\\GraphicsTest\\test.png");
        }

        public void RaiseCanExecuteChanged()
        {
            throw new NotImplementedException();
        }
    }
}
