﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KZMaker.Core.Services
{
    public interface ICreateCardService
    {
        Task<Bitmap> GenerateCard(string zastep, DateTime date, string place, List<Point> points, List<string> requiredItems);
    }
}
