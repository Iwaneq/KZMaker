using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KZMaker.Core.Services
{
    public interface IChangeCommandsService
    {
        void ChangeToAutomaticSave();
        void ChangeToManualSave();
        void CheckSavingMode();
    }
}
