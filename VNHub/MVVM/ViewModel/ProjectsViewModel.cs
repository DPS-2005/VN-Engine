using System.Collections.ObjectModel;
using System.IO;
using VNHub.Core;
using Newtonsoft.Json;
using System.Reflection;
using VNHub.MVVM.Model;
using VNHub.Stores;
using System.Resources;
using System.Diagnostics;
using System.Text.Json.Nodes;

namespace VNHub.MVVM.ViewModel
{
    public class ProjectsViewModel : ObservableObject
    {
        public ObservableCollection<Project> Projects { get; set; }

        public RelayCommand CreateProjectCommand { get; set; }

        private readonly string _jsonFilePath = "projects.json";

        public ProjectsViewModel(NavigationStore navigationStore)
        {
            //add json file if not available
            if (!File.Exists(_jsonFilePath))
            {
                File.WriteAllText(_jsonFilePath, "[]");
                Debug.WriteLine(File.ReadAllText(_jsonFilePath));
            }

            CreateProjectCommand = new RelayCommand(o =>
            {
                navigationStore.CurrentVM = navigationStore.ProjectCreationVM;
            });

            Projects = new ObservableCollection<Project>();
            ReadProjectRecord();
        }

        public void WriteProjectRecord()
        {
            String json = JsonConvert.SerializeObject(Projects);
            File.WriteAllText(_jsonFilePath, json);
        }
        public void ReadProjectRecord()
        {
            String json = File.ReadAllText(_jsonFilePath);
            var record = JsonConvert.DeserializeObject<IList<Project>>(json);
            if (record != null)
            {
                Projects = new ObservableCollection<Project>(record);
            }
            else
            {
                Projects = new ObservableCollection<Project>();
            }
        }
    }
}