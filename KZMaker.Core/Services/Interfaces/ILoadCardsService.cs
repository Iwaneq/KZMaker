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
        List<CardFile> LoadCards(string folder);
        Card LoadCard(string filePath);
    }
}
