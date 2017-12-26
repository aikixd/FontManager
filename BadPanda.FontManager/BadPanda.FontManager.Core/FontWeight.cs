using System;
using BadPanda.FontManager.Extentions;
using SharpToolkit.FunctionalExtensions;

namespace BadPanda.FontManager.Core
{
    public class FontWeight : Record<FontWeight>
    {
        public FontWeightName Name { get; }
        public Uri Path { get; }
        public FontWeightInstalled InstallStatus { get; }

        public FontWeight(FontWeightName name, Uri path, FontWeightInstalled installStatus)
        {
            Name = name;
            Path = path;
            InstallStatus = installStatus;
        }
    }

    public class FontWeightInstalled : ValueObject<bool>
    {
        public FontWeightInstalled(bool value) : base(value)
        {
        }
    }

    public class FontWeightName : ValueObject<string>
    {
        public FontWeightName(string value)
            : base(value)
        {
        }
    }
}
