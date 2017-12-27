using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using BadPanda.FontManager.Core;
using BadPanda.FontManager.Cqrs;

namespace BadPanda.FontManager.Wpf.Models
{
    public interface IFontModel
    {
        IObservable<IEnumerable<FontWeight>> Fonts { get; }
        Task ReadFromDirectoryAsync(string path);
    }
    public class FontModel : IFontModel
    {
        private readonly Commands _commands;
        private readonly Subject<IEnumerable<FontWeight>> _fontsSubject = new Subject<IEnumerable<FontWeight>>();

        public IObservable<IEnumerable<FontWeight>> Fonts => _fontsSubject.AsObservable();


        public FontModel(Commands commands)
        {
            _commands = commands;
        }

        public async Task ReadFromDirectoryAsync(string path)
        {
            var fonts = await _commands.ReadFontWeightsAsync(new Uri(path));
            _fontsSubject.OnNext(fonts);
        }
    }
}