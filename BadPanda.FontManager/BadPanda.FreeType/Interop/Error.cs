using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace BadPanda.FreeType.Interop
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct Error
    {
        public int Value;

        public static implicit operator bool (Error err)
        {
            return err.Value != 0;
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}
