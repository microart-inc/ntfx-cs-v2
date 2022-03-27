using System;
using System.Collections.Generic;
using System.Text;
using MicroART.NTFX.Models;
using MicroART.NTFX.Internal;

namespace MicroART.NTFX.Internal.Classes
{
    class System_Class : IClass
    {
        public List<IApplication> Applications { get; set; } = new List<IApplication>()
        {
            new Applications.SystemInfo_App(),
            new Applications.SystemUpdate_App()
        };

        public List<IClass> Classes { get; set; } = new List<IClass>()
        {
            new System_Hardware_Class()
        };

        public string Name => "System";

        public string FullName => "System";

        public string Description => "Contains applications that allow interfacing with the host system";

        public Version Version { get; set; } = new Version("1.0.0");
    }
}
