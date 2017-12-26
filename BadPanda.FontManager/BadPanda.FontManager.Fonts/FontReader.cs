using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using BadPanda.FontManager.Core;

namespace BadPanda.FontManager.Fonts
{
    public class FontReader
    {
        public Task<IEnumerable<FontWeight>> ReadFromAllAsync(IEnumerable<FileInfo> files)
        {
            throw new NotImplementedException();
        }
    }
}