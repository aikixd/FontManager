using BadPanda.FontManager.Extentions;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace BadPanda.FreeType.Interop
{
    internal class NativeStruct<TPtr, TStruct> : Disposable
        where TPtr : IPtr
    {

        protected TPtr pointer;

        protected TStruct data;

        public NativeStruct(TPtr ptr)
        {
            this.pointer = ptr;
            this.data = Marshal.PtrToStructure<TStruct>(ptr.Pointer);
        }

        protected override void DisposeManaged()
        {
            pointer.SetZero();
        }

        protected override void DisposeUnmanaged()
        {
            
        }

        protected override void ReportFinalization()
        {
            throw new InvalidOperationException("This object was not disposed.");
        }
    }
}
