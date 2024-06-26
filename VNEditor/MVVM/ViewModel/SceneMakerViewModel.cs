using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using VNEditor.Core;
using VNEditor.MVVM.Model;
using VNEditor.MVVM.View;

namespace VNEditor.MVVM.ViewModel
{
    public enum ToolMode
    {
        SELECT,
        MOVE,
        RESIZE,
        ROTATE
    }
    public class SceneMakerViewModel
    {
        public Scene CurrentScene { get; set; }
        public ObservableCollection<Scene> Scenes { get; set; }
        public ToolMode Mode { get; set; }
        public RelayCommand ChangeToolCommand { get; set; }

        private readonly String _savePath = "";

        public SceneMakerViewModel(DirectoryInfo projectDirectory)
        {
            _savePath = Path.Combine(projectDirectory.FullName, "Resources", "savedata.json");
            Mode = ToolMode.SELECT;
            LoadData();
            ChangeToolCommand = new RelayCommand(o =>
            {
                if(o is TabItem item)
                {
                    Mode = ToolModeProperty.GetToolValue(item);
                }
            });
        }

        public void LoadData()
        {
            String json = File.ReadAllText(_savePath);
            IList<Scene>? data = JsonConvert.DeserializeObject<IList<Scene>>(json);
            if(data != null && data.Count > 0)
            {
                Scenes = new ObservableCollection<Scene>(data);
                CurrentScene = Scenes[Scenes.Count - 1];
            }
            else
            {
                Scenes = new ObservableCollection<Scene>();
                CurrentScene = new Scene();
                Scenes.Add(CurrentScene);
                SaveData();
            }
        }

        public void SaveData()
        {
            string json = JsonConvert.SerializeObject(Scenes, Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            File.WriteAllText(_savePath, json);
        }
    }
}
