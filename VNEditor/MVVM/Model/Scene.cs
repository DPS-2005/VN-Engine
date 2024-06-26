using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace VNEditor.MVVM.Model
{
    public class Scene
    {
        public ObservableCollection<ImageData> Images { get; set; }
        public ObservableCollection<Dialogue> Dialogues { get; set; }

        public Scene()
        {
            Images = new ObservableCollection<ImageData>();
            Dialogues = new ObservableCollection<Dialogue>();
        }
    }
}
