using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using static BadPanda.FreeType.Interop.Config;

namespace BadPanda.FreeType.Interop
{
    public static class Sfnt
    {
        [DllImport(LibName, CallingConvention = Convention, CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        internal static extern FT_UInt FT_Get_Sfnt_Name_Count(IntPtrFace face);

        [DllImport(LibName, CallingConvention = Convention, CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        internal static extern Error FT_Get_Sfnt_Name(IntPtrFace face, FT_UInt idx, out SfntNameRec name);
    }
}
