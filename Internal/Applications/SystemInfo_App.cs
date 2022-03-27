using System;
using System.Collections.Generic;
using System.Text;
using MicroART.NTFX.Internal;
using MicroART.NTFX.Models;
using MicroART.Pipe;

namespace MicroART.NTFX.Internal.Applications
{
    class SystemInfo_App : IApplication
    {
        public string Name => "Info";

        public string FullName => "System Info";

        public string Description => "Returns information about the host system";

        public Version Version { get; set; } = new Version("1.0.0");

        public bool RequiresAdministrator => false;

        public void Execute(ref Models.AppContext _context)
        {
            Write.Blue("NTFX Information =========================", true);
            Write.White($"{CalcSpacing("Version:")}{_context.NtfxInfo.NTFXVersion}", true);
            Write.White($"{CalcSpacing("Build:")}01-30-2021", true);
            Write.White($"{CalcSpacing("Current Branch:")}NTFX Dev", true);
            Write.White($"Capabilities:", true);
            foreach (var s in _context.NtfxInfo.Legacy_Capabilities)
                Write.White($"\t|{s}", true);
            Write.Blue("Session Information ======================", true);
            Write.White($"{CalcSpacing("Uptime:")}{_context.NtfxInfo.GetSessionUptime().ToString("dd\\:hh\\:mm\\:ss")}", true);
            string elevation = "User";
            if (_context.IsAdministrator) elevation = "Administrator";
            if (_context.IsSuperuser) elevation = "SuperUser";
            Write.White($"{CalcSpacing("Current Elevation:")}{elevation}", true);
        }
        public string CalcSpacing(string s, int padding = 20)
        {
            int otherpad = padding - s.Length;
            string paddingstr = " ";
            if (otherpad > 0)
            {
                paddingstr = new string(' ', otherpad);
            }
            return s + paddingstr;
        }
    }
}
