using System;
using System.Collections.Generic;
using System.Text;
using MicroART.NTFX.Models;
using MicroART.Pipe;

namespace MicroART.NTFX.Internal.Applications
{
    class NtfxPrompt_App : IApplication
    {
        public string Name => "Prompt";

        public string FullName => "Ntfx Prompt";

        public string Description => "Allows changing the NTFX terminal prompt";

        public Version Version { get; set; } = new Version("1.0.0");

        public bool RequiresAdministrator => false;

        public void Execute(ref Models.AppContext _context)
        {
            var t = _context.Arguments;
            if (!string.IsNullOrWhiteSpace(_context.Arguments))
            {
                var args = _context.Arguments;
                if (!args.Contains("--set "))
                {
                    throw new Exception("Invalid arguments");
                }
                args = args.Replace("--set", "").Trim();
                Program._context.Prompt = args;
                new Write("New Prompt: " + args, true);
            }
            else
            {
                new Write("Current Prompt: " + Program._context.GetPrompt(), true);
            }
        }
    }
}
