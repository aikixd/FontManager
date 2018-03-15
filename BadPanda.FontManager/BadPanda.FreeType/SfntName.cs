using BadPanda.FontManager.Extentions;
using BadPanda.FreeType.Interop;
using SharpToolkit.FunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace BadPanda.FreeType
{
    internal class SfntName
    {
        private SfntNameRec data;

        private SfntName(SfntNameRec data)
        {
            this.data = data;
        }

        public static SfntName Create(SfntNameRec data)
        {
            return new SfntName(data);
        }

        public Result<PlatformId> Platform
        {
            get
            {
                if (typeof(PlatformId).IsEnumDefined((ushort)this.data.platformId))
                    return new Result<PlatformId>.Ok((PlatformId)(ushort)this.data.platformId);

                return new Result<PlatformId>.Error(
                    new ErrorResult(
                        "Font defined platform id does not exist.",
                        ("platformId", this.data.platformId.value.ToString())
                    ));
            }
        }
            
        public string Encoding =>
            this.Platform.Match(
                ok =>
                {
                    if (Identifications.PlatformIds[ok.Value].TryGetValue(this.data.encodingId, out var en))
                        return en;

                    return string.Empty;
                },
                err => string.Empty
                );

        public string Language =>
            this.Platform.Match(
                ok =>
                {
                    if (Identifications.PlatformIds[ok.Value].Languages.TryGetValue(this.data.encodingId, out var ln))
                        return ln;

                    return string.Empty;
                },
                err => string.Empty
            );

        public string NameType
        {
            get
            {
                if (Identifications.NameIds.TryGetValue(this.data.nameId, out var nt))
                    return nt;

                return string.Empty;
            }
        }

        public string ValueUnicode
        {
            get
            {

                return Marshal.PtrToStringUni(this.data.stringBytes, Convert.ToInt32(this.data.stringLength));
            }
        }

        public string ValueUnicodeBigEndian
        {
            get
            {
                byte[] arr = new byte[this.data.stringLength];
                Marshal.Copy(this.data.stringBytes, arr, 0, Convert.ToInt32(this.data.stringLength));

                return System.Text.Encoding.BigEndianUnicode.GetString(arr);
            }
        }

        public string ValueAnsi
        {
            get
            {

                return Marshal.PtrToStringAnsi(this.data.stringBytes, Convert.ToInt32(this.data.stringLength));
            }
        }

        public Result<string> Value =>
            this.Platform.Match<Result<string>>(
                ok =>
                {
                    switch (ok.Value)
                    {
                        case PlatformId.Mac:
                            return new Result<string>.Ok(this.ValueAnsi);

                        case PlatformId.Microsoft:
                            return new Result<string>.Ok(this.ValueUnicodeBigEndian);

                        default:
                            throw new NotImplementedException("Add implementations.");
                    }
                },
                err => new Result<string>.Error(err.Value)
                );
    }
}
