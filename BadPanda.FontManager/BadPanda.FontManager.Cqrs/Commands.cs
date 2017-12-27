using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BadPanda.FontManager.Core;
using BadPanda.FontManager.Fonts;
using BadPanda.FontManager.OsTools;

namespace BadPanda.FontManager.Cqrs
{
    public class Commands
    {
        private readonly IDiskTools _diskTools;
        private readonly FontReader _reader = new FontReader();

        public static Commands Instance = new Commands(null);

        public Commands(IDiskTools diskTools)
        {
            _diskTools = diskTools;
        }

        public async Task<IEnumerable<FontWeight>> ReadFontWeightsAsync(Uri path)
        {
            var files = await _diskTools.LoadFontFilesFromPathAsync(path);
            return await _reader.ReadFromAllAsync(files);
        }
    }
}
