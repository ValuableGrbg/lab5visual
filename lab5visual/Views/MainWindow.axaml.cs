using Avalonia.Controls;
using lab5visual.ViewModels;
using System.IO;
using Avalonia.Interactivity;

namespace lab5visual.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.FindControl<Button>("SetReg").Click += RegSubHandler;


            this.FindControl<Button>("Open").Click += async delegate
            {
                var taskPath = new OpenFileDialog()
                {
                    Title = "Open file",
                    Filters = null
                }.ShowAsync((Window)this.VisualRoot);
                string[]? path = await taskPath;
                string clear_path;

                var context = this.DataContext as MainWindowViewModel;
                clear_path = string.Join(@"\", path);

                string s = File.ReadAllText(clear_path);

                context.Text = s;
                
            };

            this.FindControl<Button>("Save").Click += async delegate
            {
                var taskPath = new OpenFileDialog()
                {
                    Title = "Save File",
                    Filters = null
                }.ShowAsync((Window)this.VisualRoot);

                string[]? path = await taskPath;
                var context = this.DataContext as MainWindowViewModel;
                if (path != null)
                {
                    using (StreamWriter sw = File.CreateText(string.Join(@"\", path)))
                    {
                       sw.WriteLine(context.Res);
                    }
                }
            };
        }
        private async void RegSubHandler(object sender, RoutedEventArgs e) 
        {
            string? str = await new RegWindow().ShowDialog<string?>((Window)this.VisualRoot);
            var context = this.DataContext as MainWindowViewModel;
            context.Expression = str;
            context.Res = context.FindRegex();
        }
    }
}
