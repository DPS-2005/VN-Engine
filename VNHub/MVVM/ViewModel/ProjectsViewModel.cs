using System.Collections.ObjectModel;
using System.IO;
using VNHub.Core;
using Newtonsoft.Json;
using System.Reflection;
using VNHub.MVVM.Model;
using VNHub.Stores;

namespace VNHub.MVVM.ViewModel
{
    public class ProjectsViewModel : ObservableObject
    {
        public ObservableCollection<Project> Projects;

        public RelayCommand CreateProjectCommand { get; set; }
        
        public ProjectsViewModel(NavigationStore navigationStore)
        {
            CreateProjectCommand = new RelayCommand(o =>
            {
                navigationStore.CurrentVM = navigationStore.ProjectCreationVM;
            });

            ProjectRecord? record = JsonConvert.DeserializeObject<ProjectRecord>(ReadProjectRecord());
            if(record != null)
            {
                Projects = new ObservableCollection<Project>(record.Projects);
            }
            else
            {
                Projects = new ObservableCollection<Project>();
            }
        }

        public String ReadProjectRecord()
        {
            var assembly = Assembly.GetEntryAssembly();
            var resourceStream = assembly?.GetManifestResourceStream("VNHub.Resources.ProjectRecord.json");
            if(resourceStream != null)
            {
                using (var reader = new StreamReader(resourceStream))
                {
                    String jsonProject = reader.ReadToEnd();
                    return jsonProject;
                }
            }
            else
            {
                return "{}";
            }
        }
    }
}