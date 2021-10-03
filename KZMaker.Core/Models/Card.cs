using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KZMaker.Core.Models
{
    public class Card
    {
        public string Zastep { get; set; }
        public DateTime Date { get; set; }
        public List<Point> Points { get; set; }
        public List<RequiredItem> RequiredItems { get; set; }
    }
}
