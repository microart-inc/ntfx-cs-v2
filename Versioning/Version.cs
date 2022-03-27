using System;
using System.Collections.Generic;
using System.Text;

namespace MicroART.NTFX.Versioning
{
    class Version
    {
        public Version(string version)
        {
            string[] versions = version.Split('.');
            try
            {
                Major = int.Parse(versions[0]);
            }
            catch (Exception) { }
            try
            {
                Minor = int.Parse(versions[1]);
            }
            catch (Exception) { }
            try
            {
                Patch = int.Parse(versions[2]);
            }
            catch (Exception) { }
        }
        public int Major;
        public int Minor;
        public int Patch;
        public override string ToString()
        {
            return $"{Major}.{Minor}.{Patch}";
        }
    }
}
