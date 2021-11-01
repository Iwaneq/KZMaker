using KZMaker.Core.ResourceManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KZMaker.Core.Models.ColorSets
{
    public abstract class BaseColorSet 
    {
        public string ThemeName { get; set; }
        public ResourcesModel Resources { get; set; }
    }
}
