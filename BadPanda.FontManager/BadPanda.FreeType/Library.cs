using BadPanda.FontManager.Extentions;
using BadPanda.FreeType.Interop;
using SharpToolkit.FunctionalExtensions;
using System;

namespace BadPanda.FreeType
{
    public sealed class Library : Disposable
    {
        internal struct LibraryRec
        {
            public IntPtr memoryPtr;

            public FT_Int versionMajor;
            public FT_Int versionMinor;
            public FT_Int versionPatch;

            public FT_UInt numModules;

            public IntPtr modulesPtr;
        }

        private IntPtr pointer;

        private Library(IntPtr reference)
        {
            this.pointer = reference;
        }

        public static Result<Library> Create()
        {
            var err = Interop.Library.FT_Init_FreeType(out var ptr);

            if (err.Value == 0)
                return new Result<Library>.Ok(new Library(ptr));

            return new Result.Error(new ErrorResult(err.Value.ToString()));
        }

        public Result<Face> Open(Uri path)
        {
            var err = Interop.Face.FT_New_Face(this.pointer, path.LocalPath, 0, out var facePtr);

            if (err.Value == 0)
                return Face.Create(facePtr).Match<Result<Face>>(
                    ok => new Result<Face>.Ok(ok.Value),
                    faceErr => new Result.Error(faceErr.Value));

            return new Result.Error(new ErrorResult(err.Value.ToString()));
        }

        protected override void DisposeManaged()
        {
            
        }

        protected override void DisposeUnmanaged()
        {
            Interop.Library.FT_Done_FreeType(this.pointer);
            this.pointer = IntPtr.Zero;
        }
    }
}
