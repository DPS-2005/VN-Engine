using System.Configuration;
using System.Data;
using System.Windows;
using VNHub.MVVM.ViewModel;
using VNHub.Stores;

namespace VNHub
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NavigationStore _navigationStore;

        public App()
        {
            _navigationStore = new NavigationStore();
        }
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            _navigationStore.CurrentVM = _navigationStore.ProjectVM;
            MainWindow = new MainWindow
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();
        }
    }

}
