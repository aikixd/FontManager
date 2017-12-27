using BadPanda.FontManager.Wpf.Messages;
using Caliburn.Micro;

namespace BadPanda.FontManager.Wpf.ViewModels
{
    public interface IPresentationViewModel { }
    public class PresentationViewModel: PropertyChangedBase, IPresentationViewModel
    {
        private readonly IEventAggregator _eventAggregator;
        private string _displayText;

        public string DisplayText
        {
            get => _displayText;
            set
            {
                if (value == _displayText) return;
                _displayText = value;
                NotifyOfPropertyChange(() => DisplayText);
                _eventAggregator.PublishOnUIThread(new DisplayValueChanged(DisplayText));
            }
        }

        public PresentationViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            DisplayText = "Hellow world";
        }
    }
}