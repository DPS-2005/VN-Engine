using System.Collections.ObjectModel;
using System.IO;
using VNHub.Core;
using Newtonsoft.Json;
using System.Reflection;
using VNHub.MVVM.Model;

namespace VNHub.MVVM.ViewModel
{
    public class ProjectsViewModel : ObservableObject
    {
        public ObservableCollection<FileInfo> Files;
        
        public ProjectsViewModel()
        {
            FileRecord? record = JsonConvert.DeserializeObject<FileRecord>(ReadFileRecord());
            if(record != null)
            {
                Files = new ObservableCollection<FileInfo>(record.Files);
            }
            else
            {
                Files = new ObservableCollection<FileInfo>();
            }
        }

        public String ReadFileRecord()
        {
            var assembly = Assembly.GetEntryAssembly();
            var resourceStream = assembly?.GetManifestResourceStream("VNHub.Resources.FileRecord.json");
            if(resourceStream != null)
            {
                using (var reader = new StreamReader(resourceStream))
                {
                    String jsonFile = reader.ReadToEnd();
                    return jsonFile;
                }
            }
            else
            {
                return "{}";
            }
        }
    }
}