using System.IO;
using System.Windows;
using VNEditor.MVVM.ViewModel;

namespace VNEditor
{
    public partial class App : Application
    {
        public DirectoryInfo ProjectDirectory;
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            ProjectDirectory = new DirectoryInfo(e.Args[1]);
            MainWindow = new MainWindow
            {
                DataContext = new MainViewModel(this.ProjectDirectory),
                Title = e.Args[0]
            };
            MainWindow.Show();
        }
    }

}
