using System;
using System.Collections.Generic;
using System.Text;
using MicroART.NTFX.Models;

namespace MicroART.NTFX.Internal.Classes
{
    class Ntfx_Class : IClass
    {
        public List<IApplication> Applications => new List<IApplication>()
        {
            new Applications.NtfxPrompt_App()
        };

        public List<IClass> Classes => null;

        public string Name => "Ntfx";

        public string FullName => "Ntfx";

        public string Description => "Provides applications that allow modifying the NTFX session or subsystem";

        public Version Version { get; set; } = new Version("2.3.10");
    }
}
