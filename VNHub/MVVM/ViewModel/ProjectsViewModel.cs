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
using System.Collections.Specialized;

namespace VNHub.MVVM.ViewModel
{
    public class ProjectsViewModel : ObservableObject
    {
        public ObservableCollection<Project> Projects { get; set; }

        public RelayCommand CreateProjectCommand { get; set; }
        public RelayCommand RemoveProjectCommand { get; set; }
        public RelayCommand LaunchEditorCommand { get; set; }

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

            RemoveProjectCommand = new RelayCommand(o =>
            {
                if(o!=null)
                RemoveProject((Project)(o));
            });

            LaunchEditorCommand = new RelayCommand(o =>
            {
                if(o is Project project)
                {
                    String[] args = {project.Name, project.Location};
                    Process.Start("VNEditor.exe", args);
                }
            });

            //initialise Projects Collection with contents of json file
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

        public void AddProject(Project project)
        {
            Projects.Add(project);
            WriteProjectRecord();
        }

        public void RemoveProject(Project project)
        {
            Projects.Remove(project);
            WriteProjectRecord();
        }

    }
}