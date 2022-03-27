using System;
using System.Collections.Generic;
using System.Text;
using MicroART.Pipe;
using MicroART.NTFX.Models;
using System.Threading.Tasks;

namespace MicroART.NTFX.Internal.Applications
{
    class SystemUpdate_App : IApplication
    {
        public string Name => "Update";

        public string FullName => "Sytem Update";

        public string Description => "Checks for and downloads updates of NTFX";

        public Version Version => new Version("1.0.0");

        public bool RequiresAdministrator => false;

        public void Execute(ref Models.AppContext _context)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            int cursor = Console.CursorTop;
            Write.Black(" [SYNC] ");
            Console.BackgroundColor = ConsoleColor.Black;
            Write.Yellow(" Checking for updates...", true);
            Task.Delay(300).Wait();
            int newcursor = Console.CursorTop;
            Console.CursorTop = cursor;
            Console.BackgroundColor = ConsoleColor.Green;
            Write.Black(" [DONE] ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.CursorTop = newcursor;
            Console.CursorLeft = 0;
            Write.Green("The latest version of NTFX is already installed", true);
        }
    }
}
