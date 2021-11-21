using KZMaker.Core.Models;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KZMaker.Core.Services
{
    public interface ILoadCardsService
    {
        MvxObservableCollection<CardFile> LoadCards(string folder);
        MvxObservableCollection<CardFile> LoadCardsFiltered(string folder, Func<List<CardFile>, List<CardFile>> filterFiles);
        CardFile LoadCardFile(string filePath);
        Card LoadCard(string filePath);
    }
}
