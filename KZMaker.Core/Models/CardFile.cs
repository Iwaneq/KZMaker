using KZMaker.Core.Commands;
using MvvmCross;
using MvvmCross.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KZMaker.Core.Models
{
    public class CardFile
    {
        public DateTime Date { get; set; }
        public string FileName { get; set; }
        public string Path { get; set; }

        public IMvxCommand<CardFile> LoadCardCommand { get; set; }

        public CardFile()
        {
            //Tests couldn't pass because in Test Environment Mvx.IoCProvider is null
            //So, I decided to move Getting Singleton to CardFile's constructor
            //And put here this flag, to make sure that tests will pass.
            if (Mvx.IoCProvider == null) return;

            LoadCardCommand = Mvx.IoCProvider.GetSingleton<LoadCardCommand>();
        }
    }
}
