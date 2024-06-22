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
                DataContext = new MainViewModel(),
                Title = e.Args[0]
            };
            MainWindow.Show();
        }
    }

}
