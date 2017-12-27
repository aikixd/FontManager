using BadPanda.FontManager.Wpf.ViewModels;
using Caliburn.Micro;

namespace BadPanda.FontManager.Wpf {
    public class ShellViewModel : PropertyChangedBase, IShell
    {
        public IFontViewModel FontsDisplay { get; }
        public IPresentationViewModel Presentation { get; }
        public ICategoriesViewModel Categories { get; }

        public ShellViewModel(IFontViewModel fontModel, ICategoriesViewModel categoriesModel, IPresentationViewModel presentationModel)
        {
            FontsDisplay = fontModel;
            Categories = categoriesModel;
            Presentation = presentationModel;
        }
    }
}