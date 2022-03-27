using System;
using System.Collections.Generic;
using System.Text;
using MicroART.NTFX.Internal;
using MicroART.NTFX.Models;

namespace MicroART.NTFX.Parsers
{
    interface IParser
    {
        Version Version { get; }
        string[] Capabilities { get; }
        (IClass, IApplication, string, ParserFlags, int) Parse(string content, StorageProvider storage);
    }
}
