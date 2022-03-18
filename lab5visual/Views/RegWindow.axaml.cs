using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using lab5visual.ViewModels;

namespace lab5visual.Views
{
    public partial class RegWindow : Window
    {
        public RegWindow(string Reg):this()
        {
            this.FindControl<TextBox>("regIn").Text = Reg;
        }
        public RegWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            this.FindControl<Button>("ok").Click += async delegate
            {
                Close(this.FindControl<TextBox>("regIn").Text);
            };
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
