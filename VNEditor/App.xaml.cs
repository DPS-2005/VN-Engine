using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Windows;

namespace VNEditor
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Debug.WriteLine(e);
        }
    }

}
