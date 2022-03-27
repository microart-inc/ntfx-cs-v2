using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MicroART.NTFX
{
    public class NtfxInfo
    {
        private NtfxInfo() { }

        public readonly Version NTFXVersion = new Version("1.0.0");
        private Stopwatch _stopwatch = new Stopwatch();
        public TimeSpan GetSessionUptime()
        {
            return _stopwatch.Elapsed;
        }
        public readonly string[] Legacy_Capabilities = new string[]
        {
            "Invoke Host UAC",
            "Read & Write to host filesystem",
            "Read & Write to host registry",
            "Draw window areas",
            "Invoke Conhost",
            "Windows Pipe Communication",
            "DelV Low-Level Encryption"
        };

        public static NtfxInfo Init()
        {
            var ni = new NtfxInfo();
            ni._stopwatch.Start();
            return ni;
        }
    }
}
