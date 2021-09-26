using KZMaker.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KZMaker.Core.Services
{
    public interface ILoadCardsService
    {
        Task<List<CardFile>> LoadCards(string folder);
        Task<Card> LoadCard(string filePath);
    }
}
