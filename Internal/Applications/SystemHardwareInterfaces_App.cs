using System;
using System.Collections.Generic;
using System.Text;
using MicroART.NTFX.Models;
using MicroART.NTFX.ConsoleUI;

namespace MicroART.NTFX.Internal.Applications
{
    class SystemHardwareInterfaces_App : IApplication
    {
        public string Name => "Interfaces";

        public string FullName => "System Hardware Interfaces";

        public string Description => "Lists all interfaces on the current system";

        public Version Version { get; set; } = new Version("1.0.0");

        public bool RequiresAdministrator => false;

        public void Execute(ref Models.AppContext _context)
        {
            CliTable table = new CliTable();
            table.EqualCellSpacing = true;
            table.EqualCellPadding = 2;
            table.Header = new List<string>()
            {
                "Interface",
                "Connection Type",
                "Protocol",
                "Status"
            };
            table.Rows = new List<List<string>>()
            {
                new List<string>()
                {
                    "WiFi",
                    "Wireless",
                    "802.11ax",
                    "Connected"
                },
                new List<string>()
                {
                    "nuDriver",
                    "Built-in",
                    "NTFX-IO",
                    "Disconnected"
                }
                ,
                new List<string>()
                {
                    "Phoenix Connector",
                    "Built-in",
                    "NTFX-IO",
                    "Connected"
                }
                ,
                new List<string>()
                {
                    "Windows Pipe",
                    "wpc/7095",
                    "WPC",
                    "Connected"
                }
            };
            table.Write();
        }
    }
}
