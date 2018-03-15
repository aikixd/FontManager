using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using static BadPanda.FreeType.Interop.Config;

namespace BadPanda.FreeType.Interop
{
    public static class Face
    {
        [DllImport(LibName, CallingConvention = Convention, CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        internal static extern Error FT_New_Face(IntPtr library, string path, FT_Int faceIndex, out IntPtrFace facePtr);

        [DllImport(LibName, CallingConvention = Convention, CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        internal static extern IntPtrStr FT_Get_Font_Format(IntPtrFace face);
    }
}
