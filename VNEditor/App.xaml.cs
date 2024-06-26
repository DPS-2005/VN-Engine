using System.IO;
using System.Windows;
using VNEditor.MVVM.ViewModel;

namespace VNEditor
{
    public partial class App : Application
    {
        private DirectoryInfo _projectDirectory;
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            _projectDirectory = new DirectoryInfo(e.Args[1]);
            MainWindow = new MainWindow
            {
                DataContext = new MainViewModel(this._projectDirectory),
                Title = e.Args[0]
            };
            MainWindow.Show();
        }
    }

}
