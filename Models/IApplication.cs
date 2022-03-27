using System;
using System.Collections.Generic;
using System.Text;
using MicroART.NTFX.Internal;

namespace MicroART.NTFX.Models
{
    public interface IApplication
    {
        string Name { get; }
        string FullName { get; }
        string Description { get; }
        Version Version { get; }
        bool RequiresAdministrator { get; }
        void Execute(ref AppContext _context);
    }
}
