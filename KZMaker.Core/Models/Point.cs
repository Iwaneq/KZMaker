using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KZMaker.Core.Models
{
    public class Point
    {
        public DateTime Time { get; set; }
        public string DisplayTime
        {
            get
            {
                string minute = "";
                if (Time.Minute == 0)
                {
                    minute = "00";
                }
                else
                {
                    minute = Time.Minute.ToString();
                }
                return $"{Time.Hour}:{minute}";
            }
        }
        public string Title { get; set; }
        public string ZastepMember { get; set; }
    }
}
