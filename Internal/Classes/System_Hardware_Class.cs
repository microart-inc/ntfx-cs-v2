using System;
using System.Collections.Generic;
using System.Text;
using MicroART.NTFX.Models;

namespace MicroART.NTFX.Internal.Classes
{
    class System_Hardware_Class : IClass
    {
        public List<IApplication> Applications => new List<IApplication>()
        {
            new Applications.SystemHardwareInterfaces_App()
        };

        public List<IClass> Classes => null;

        public string Name => "Hardware";

        public string FullName => "System Hardware";

        public string Description => "Provides applications to interact with physical devices";

        public Version Version { get; set; } = new Version("1.0.0");
    }
}
