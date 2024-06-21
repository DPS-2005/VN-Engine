using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Windows;
using VNEditor.MVVM.ViewModel;

namespace VNEditor
{
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            MainWindow = new MainWindow
            {
                DataContext = new MainViewModel()
            };
            MainWindow.Show();
        }
    }

}
