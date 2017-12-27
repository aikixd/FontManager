namespace BadPanda.FontManager.Wpf.Messages
{
    public class DisplayValueChanged
    {
        public string Text { get; }

        public DisplayValueChanged(string text)
        {
            Text = text;
        }
    }
}