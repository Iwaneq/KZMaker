using KZMaker.Core.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KZMaker.Core.Services
{
    public interface ICreateCardService
    {
        Task<Bitmap> CreateCard(string zastep, DateTime date, string place, List<Models.Point> points, List<RequiredItem> requiredItems);
    }
}
