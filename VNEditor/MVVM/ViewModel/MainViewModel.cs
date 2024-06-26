using System.IO;
using System.Windows.Input;
using VNEditor.Core;

namespace VNEditor.MVVM.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        public ExplorerViewModel ExplorerVM { get; set; }
        public SceneMakerViewModel SceneMakerVM { get; set; }

        public RelayCommand SaveCommand { get; set; }

        public MainViewModel(DirectoryInfo projectDirectory)
        {
            ExplorerVM = new ExplorerViewModel(projectDirectory);
            SceneMakerVM = new SceneMakerViewModel(projectDirectory);
            SaveCommand = new RelayCommand(o =>
            {
                SceneMakerVM.SaveData();
            });
        }

        public void SaveCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            SceneMakerVM.SaveData();
        }
        
    }
}
