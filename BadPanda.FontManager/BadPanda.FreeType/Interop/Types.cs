using SharpToolkit.FunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace BadPanda.FreeType.Interop
{
    internal interface IPtr
    {
        IntPtr Pointer { get; }
        void SetZero();
    }

    [StructLayout(LayoutKind.Sequential)]
    [DebuggerDisplay("{value}")]
    internal struct FT_Byte
    {
        public byte value;
    }

    [StructLayout(LayoutKind.Sequential)]
    [DebuggerDisplay("{value}")]
    internal struct FT_Short
    {
        public short value;
    }

    [StructLayout(LayoutKind.Sequential)]
    [DebuggerDisplay("{value}")]
    internal struct FT_UShort
    {
        public ushort value;

        public FT_UShort(ushort i)
        {
            this.value = i;
        }

        public static implicit operator ushort(FT_UShort s)
        {
            return s.value;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    [DebuggerDisplay("{value}")]
    internal struct FT_Int
    {
        public int value;

        public FT_Int(int i)
        {
            this.value = i;
        }

        public static implicit operator FT_Int(int i)
        {
            return new FT_Int(i);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    [DebuggerDisplay("{value}")]
    internal struct FT_UInt
    {
        public uint value;

        public FT_UInt(uint i)
        {
            this.value = i;
        }

        public static implicit operator FT_UInt(uint i)
        {
            return new FT_UInt(i);
        }

        public static implicit operator uint(FT_UInt s)
        {
            return s.value;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    [DebuggerDisplay("{value}")]
    internal struct FT_Long
    {
        public long value;
    }

    [StructLayout(LayoutKind.Sequential)]
    [DebuggerDisplay("{value}")]
    internal struct FT_ULong
    {
        public ulong value;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct IntPtr<T>
    {
        public IntPtr ptr;

        public T Convert()
        {
            return Marshal.PtrToStructure<T>(ptr);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct IntPtrFace
    {
        public IntPtr ptr;

        public FaceRec Convert()
        {
            return Marshal.PtrToStructure<FaceRec>(ptr);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct IntPtrStr
    {
        private IntPtr ptr;

        public Result<string> Ansi =>
            ptr == IntPtr.Zero ?
            (Result<string>)
            new Result<string>.Error(new ErrorResult("Could not determine font format.")) :
            new Result<string>.Ok(Marshal.PtrToStringAnsi(ptr));
    }
}
