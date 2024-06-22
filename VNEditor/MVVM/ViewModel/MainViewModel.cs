using System.Configuration;
using System.IO;
using VNEditor.Core;

namespace VNEditor.MVVM.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        public ExplorerViewModel ExplorerVM { get; set; }

        public MainViewModel(DirectoryInfo ProjectDirectory)
        {
            ExplorerVM = new ExplorerViewModel(ProjectDirectory);
        }
        
    }
}
