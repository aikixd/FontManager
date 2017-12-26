using BadPanda.FontManager.Wpf.ViewModels;
using Caliburn.Micro;

namespace BadPanda.FontManager.Wpf {
    public class ShellViewModel : PropertyChangedBase, IShell
    {
        public FontsDisplayViewModel FontsDisplay => new FontsDisplayViewModel();
        public PresentationViewModel Presentation => new PresentationViewModel();
        public CategoriesViewModel Categories => new CategoriesViewModel();
    }
}