using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using MicroART.Pipe;
using Microsoft.Extensions.Configuration;

namespace MicroART.NTFX.CredentialsManager
{
    class SecureContext
    {
        public SHA512 Sha512 = new SHA512Managed();
        private string _storedPasswordHash;

        public SecureContext()
        {
            _storedPasswordHash = System.
        }

        public void ReadPassword()
        {
            SecureString buffer = new SecureString();
            string passwordHash = "";
        Read:
            var key = Read.Key(true);
            if (key.Key != ConsoleKey.Enter) { buffer.AppendChar(key.KeyChar); goto Read; }
            buffer.MakeReadOnly();
            var bstr = Marshal.SecureStringToBSTR(buffer);
            var length = Marshal.ReadInt32(bstr, -4);
            var bytes = new byte[length];
            var bytesPin = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            try
            {
                Marshal.Copy(bstr, bytes, 0, length);
                Marshal.ZeroFreeBSTR(bstr);

                passwordHash = Encoding.UTF8.GetString(Sha512.ComputeHash(bytes));
            }
            finally
            {
                for (var i = 0; i < bytes.Length; i++)
                {
                    bytes[i] = 0;
                }

                bytesPin.Free();
            }
        }
    }
}
