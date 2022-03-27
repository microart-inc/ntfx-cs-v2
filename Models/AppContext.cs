using MicroART.NTFX.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroART.NTFX.Models
{
    public class AppContext
    {
        public bool IsAdministrator { get; private set; }
        public bool IsSuperuser { get; private set; }
        public string Arguments;
        public NtfxInfo NtfxInfo;
        public AppStorageProvider Storage = new AppStorageProvider();

        internal void DefineContext((IClass, IApplication, string, ParserFlags, int) output, Context context)
        {
            this.IsAdministrator = context.IsAdministrator;
            if (context.IsSuperuser)
            {
                IsSuperuser = true;
                IsAdministrator = true;
            }
            this.NtfxInfo = context.NtfxInfo;
            this.Arguments = output.Item3;
        }
    }
}
