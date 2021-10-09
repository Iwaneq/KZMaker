using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Services.Services
{
    public interface IMessageBoxService
    {
        string GetSavingPath(string startDirectory);
        string GetPath();
    }
}
