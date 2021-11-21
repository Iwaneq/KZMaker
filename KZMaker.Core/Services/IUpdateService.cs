using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KZMaker.Core.Services
{
    public interface IUpdateService
    {
        Task CheckForUpdate();
        string GetCurrentVersion();
    }
}
