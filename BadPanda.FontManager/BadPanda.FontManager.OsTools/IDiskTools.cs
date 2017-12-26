using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace BadPanda.FontManager.OsTools
{
    public interface IDiskTools
    {
        Task<IEnumerable<FileInfo>> LoadFontFilesFromPathAsync(Uri fromPath);
    }
}