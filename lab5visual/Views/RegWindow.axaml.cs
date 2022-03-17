using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace lab5visual.Views
{
    public partial class RegWindow : Window
    {
        public RegWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            this.FindControl<Button>("ok").Click += async delegate
            {
                var textbox = this.FindControl<TextBox>("regIn");
                Close(textbox.Text);
            };
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
