using System;
using System.Collections.Generic;
using System.Text;

namespace MicroART.NTFX.Models
{
    interface IClass
    {
        List<IApplication> Applications { get; }
        List<IClass> Classes { get; }
        string Name { get; }
        string FullName { get; }
        string Description { get; }
        Version Version { get; }
    }
}
