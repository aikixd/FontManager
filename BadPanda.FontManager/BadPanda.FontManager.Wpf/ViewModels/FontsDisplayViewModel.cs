using System;
using System.IO;
using System.Linq;
using System.Reactive.Linq;
using System.Windows.Forms;
using System.Windows.Media;
using BadPanda.FontManager.Core;
using BadPanda.FontManager.Wpf.Messages;
using BadPanda.FontManager.Wpf.Models;
using Caliburn.Micro;

namespace BadPanda.FontManager.Wpf.ViewModels
{
    public interface IFontViewModel { }

    public class FontsDisplayViewModel : PropertyChangedBase, IFontViewModel, IHandle<DisplayValueChanged>
    {
        private readonly IFontModel _fonts;
        private string currentText = string.Empty;

        public BindableCollection<FontViewModel> Fonts { get; set; }

        public FontsDisplayViewModel(IFontModel fonts, IEventAggregator eventAggregator)
        {
            _fonts = fonts;
            Fonts = new BindableCollection<FontViewModel>();

            eventAggregator
                .Subscribe(this);

            _fonts
                .Fonts
                .ObserveOnDispatcher()
                .Subscribe(f =>
                {
                    Fonts.Clear();
                    Fonts.AddRange(f.Select(i => new FontViewModel(i, currentText)));
                });
        }

        public void Handle(DisplayValueChanged message)
        {
            currentText = message.Text;
            foreach (var f in Fonts)
                f.Message = message.Text;
        }

        public void Open()
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    _fonts.ReadFromDirectoryAsync(fbd.SelectedPath);
            }
        }
    }

    public class FontViewModel : PropertyChangedBase
    {
        private readonly FontWeight _font;
        private string _message;
        private FontFamily _fontFamily;

        public FontFamily FontFamily { get; }

        public string Message
        {
            get => _message;
            set
            {
                if (value == _message) return;
                _message = value;
                NotifyOfPropertyChange(() => Message);
            }
        }

        public FontViewModel(FontWeight font, string startMessage)
        {
            _font = font;
            Message = startMessage;
            var a = $"{_font.Path.AbsoluteUri}#{_font.Name.Value}";
            FontFamily = new FontFamily(a);
        }
    }
}