using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace BadPanda.FreeType.Interop
{

    [StructLayout(LayoutKind.Sequential)]
    internal struct IntPtrSfntName : IPtr
    {
        private IntPtr ptr;

        public IntPtr Pointer => this.ptr;

        public SfntNameRec Convert()
        {
            return Marshal.PtrToStructure<SfntNameRec>(this.ptr);
        }

        public void SetZero()
        {
            this.ptr = IntPtr.Zero;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SfntNameRec
    {
        public FT_UShort platformId;
        public FT_UShort encodingId;
        public FT_UShort languageId;
        public FT_UShort nameId;

        public IntPtr stringBytes;
        public FT_UInt stringLength;
    }
}
