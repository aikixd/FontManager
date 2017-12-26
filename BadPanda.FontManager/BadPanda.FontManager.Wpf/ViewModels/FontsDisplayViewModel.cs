using BadPanda.FontManager.Wpf.Models;
using Caliburn.Micro;

namespace BadPanda.FontManager.Wpf.ViewModels
{
    public interface IFontViewModel{}

    public class FontsDisplayViewModel: PropertyChangedBase, IFontViewModel
    {
        private readonly IFontModel _fonts;

        public FontsDisplayViewModel(IFontModel fonts)
        {
            _fonts = fonts;
        }
    }
}