using BadPanda.FreeType.Interop;
using SharpToolkit.FunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using BadPanda.FontManager.Extentions;

namespace BadPanda.FreeType
{
    internal struct FaceRec
    {
        internal FT_Long numFaces;
        internal FT_Long faceIndex;

        internal FT_Long faceFlags;
        internal FT_Long styleFlags;

        internal FT_Long numGlyphs;

        internal IntPtrStr familyName;
        internal IntPtrStr styleName;

        internal FT_Int numFixedSizes;
        internal IntPtr availableSizes; // FT_Bitmap_Size*

        internal FT_Int numCharmaps;
        internal IntPtr charmaps; // FT_CharMap*

        internal IntPtr generic; // FT_Generic

        internal IntPtr bbox; // FT_BBox

        internal ushort unitsPerEm;
        internal short ascender;
        internal short descender;
        internal short height;

        internal short maxAdvanceWidth;
        internal short maxAdvanceHeight;

        internal short underlinePosition;
        internal short underlineThickness;

        internal IntPtr glyph;
        internal IntPtr size;
        internal IntPtr charmap;

        private IntPtr driver;
        private IntPtr memory;
        private IntPtr stream;

        private IntPtr sizes_list;
        private IntPtr autohint; // FT_Generic
        private IntPtr extensions;

        private IntPtr @internal;

        internal static int SizeInBytes { get { return Marshal.SizeOf(typeof(FaceRec)); } }
    }

    public class Face
    {
        private IntPtrFace pointer;

        private FontFormat format;
        private FaceRec data;

        private Face(IntPtrFace pointer, FontFormat format)
        {
            this.pointer = pointer;
            this.format = format;
            this.data = pointer.Convert();
        }

        internal static Result<Face> Create(IntPtrFace ptr)
        {
            return
                GetFontFormat(ptr)
                .Match(
                    ok =>
                    {
                        if (Enum.TryParse<FontFormat>(ok.Value, out var format))
                            return format.AsOkResult();

                        return new Result.Error(new ErrorResult("Unknown font format"));
                    },
                    err => new Result.Error(err.Value))
                .Then(fmt =>
                {
                    switch (fmt)
                    {
                        case FontFormat.TrueType:
                            return GetSfntNames(ptr).Match(
                                ok => new { format = fmt, names = ok.Value }.AsOkResult(),
                                err => new Result.Error(err.Value)); 

                        default:
                            return new Result.Error(new ErrorResult("Unknown font type."));
                    }
                })
                .Then(x =>
                {
                    return new Face(ptr, x.format).AsOkResult();
                });

            


            return GetFontFormat(ptr).Match<Result<Face>>(
                ok =>
                {
                    if (Enum.TryParse<FontFormat>(ok.Value, out var format))
                        return new Result<Face>.Ok(new Face(ptr, format));

                    return new Result.Error(new ErrorResult("Unknown font format"));
                },
                err => new Result.Error(err.Value));            
        }

        internal static Result<string> GetFontFormat(IntPtrFace ptr) =>
            Interop.Face.FT_Get_Font_Format(ptr).Ansi;

        public FontFormat Format => this.format;

        internal static Result<IEnumerable<SfntName>> GetSfntNames(IntPtrFace ptr)
        {
            var nameCount = Interop.Sfnt.FT_Get_Sfnt_Name_Count(ptr);

            var namesRaw = Enumerable.Range(0, Convert.ToInt32(nameCount))
                .Select(x =>
                {
                    var err = Interop.Sfnt.FT_Get_Sfnt_Name(ptr, Convert.ToUInt32(x), out var name);

                    return
                        err ?
                        (Result<SfntNameRec>)
                        new Result.Error(new ErrorResult(err.ToString())) :
                        new Result<SfntNameRec>.Ok(name);


                })
                .Partition(x => x.Match(
                    ok => true,
                    err => false));

            if (namesRaw.falses.Any())
                return new Result.Error(new ErrorResult(
                    "Could not read one or more names",
                    namesRaw.falses
                        .Select(x => x.When(((Result.Error err) => ("getNameResult", err.Value.Message)))
                    )));

            return new Result<IEnumerable<SfntName>>.Ok(namesRaw.trues
                .Select(x => x.When((Result<SfntNameRec>.Ok ok) => ok.Value))
                .Select(x => SfntName.Create(x))
                .ToArray());
        }

        public Result<string> FamilyName
        {
            get
            {
                switch (this.format)
                {
                    case FontFormat.TrueType:

                        var nameCount = Interop.Sfnt.FT_Get_Sfnt_Name_Count(this.pointer);

                        var namesRaw = Enumerable.Range(0, Convert.ToInt32(nameCount))
                            .Select(x =>
                            {
                                var err = Interop.Sfnt.FT_Get_Sfnt_Name(this.pointer, Convert.ToUInt32(x), out var name);

                                return
                                    err ?
                                    (Result<SfntNameRec>)
                                    new Result.Error(new ErrorResult(err.ToString())) :
                                    new Result<SfntNameRec>.Ok(name);


                            })
                            .Partition(x => x.Match(
                                ok => true,
                                err => false));

                        if (namesRaw.falses.Any())
                            return new Result.Error(new ErrorResult(
                                "Could not read one or more names",
                                namesRaw.falses
                                    .Select(x => x.When((Result.Error err) => ("getNameResult", err.Value.Message)))
                                ));

                        var names = namesRaw.trues
                            .Select(x => x.When((Result<SfntNameRec>.Ok ok) => ok.Value))
                            .Select(x => SfntName.Create(x))
                            .ToArray();

                        var platforms = names.Select(x => x.Platform).ToList();
                        var encodings = names.Select(x => x.Encoding).ToList();

                        var infos = names.Select(x => (x.Platform, x.Encoding, x.Value)).ToArray();

                        var justNames =
                            names
                            .Select(x => x.ValueUnicode);

                        throw new NotImplementedException();
                        break;

                    default:
                        return this.data.familyName.Ansi;
                }
            }
        }
        
    }
}
