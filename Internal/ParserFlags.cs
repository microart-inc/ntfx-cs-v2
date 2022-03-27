using System;
using System.Collections.Generic;
using System.Text;

namespace MicroART.NTFX.Internal
{
    [Flags]
    enum ParserFlags
    {
        Null = 1,
        RequestAdministrator = 2,
        RequestSuperuser = 4,
        ShowClassInfo = 8,
    }
}
