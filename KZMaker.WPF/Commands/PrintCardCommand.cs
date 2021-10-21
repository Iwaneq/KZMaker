using KZMaker.Core.Commands;
using KZMaker.Core.Services;
using MvvmCross.Commands;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KZMaker.WPF.Commands
{
    public class PrintCardCommand : IPrintCardCommand
    {
        private readonly IPrintService _printService;

        public PrintCardCommand(IPrintService printService)
        {
            _printService = printService;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute()
        {
            return true;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            Bitmap card = (Bitmap)parameter;

            Print(card);
        }

        private void Print(Bitmap card)
        {
            _printService.PrintBitmap(card);
        }

        public void RaiseCanExecuteChanged()
        {
            throw new NotImplementedException();
        }
    }
}
