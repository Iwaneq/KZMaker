using KZMaker.Core.Models;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KZMaker.Core.ViewModels
{
    public class WritePointsViewModel : MvxViewModel
    {
        private List<Point> _points = new List<Point>() 
        {
            new Point()
            {
                Time = DateTime.Now,
                Title = "Pionierka",
                ZastepMember ="Jacek"
            },
            new Point()
            {
                Time = DateTime.Now,
                Title = "Pionierka",
                ZastepMember ="Jacek"
            },
            new Point()
            {
                Time = DateTime.Now,
                Title = "Pionierka",
                ZastepMember ="Jacek"
            },
            new Point()
            {
                Time = DateTime.Now,
                Title = "Pionierka",
                ZastepMember ="Jacek"
            },
            new Point()
            {
                Time = DateTime.Now,
                Title = "Pionierka",
                ZastepMember ="Jacek"
            },
            new Point()
            {
                Time = DateTime.Now,
                Title = "Pionierka",
                ZastepMember ="Jacek"
            },
            new Point()
            {
                Time = DateTime.Now,
                Title = "Pionierka",
                ZastepMember ="Jacek"
            }
        };

        public List<Point> Points
        {
            get { return _points; }
            set 
            {
                _points = value;
                RaisePropertyChanged(() => Points);
            }
        }

    }
}
