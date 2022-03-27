using System;
using System.Collections.Generic;
using System.Text;
using MicroART.NTFX.Models;

namespace MicroART.NTFX
{
    class StorageProvider
    {
        public List<IClass> Classes = new List<IClass>
        {
            new Internal.Classes.System_Class(),
            new Internal.Classes.Ntfx_Class(),
        };
    }
}
