using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using static BadPanda.FreeType.Interop.Config;

namespace BadPanda.FreeType.Interop
{
    internal static class Library
    {
        [DllImport(LibName, CallingConvention = Convention)]
        internal static extern Error FT_Init_FreeType(out IntPtr library);

        [DllImport(LibName, CallingConvention = Convention)]
        internal static extern Error FT_Done_FreeType(IntPtr library);
    }
}
