using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VNEditor.MVVM.Model;

namespace VNEditor.MVVM.ViewModel
{
    public class SceneMakerViewModel
    {
        public ObservableCollection<ImageData> ImageList { get; set; }

        public SceneMakerViewModel(DirectoryInfo ProjectDirectory)
        {
            ImageList = new ObservableCollection<ImageData>();
            //temperory code for testing
            string imgPath1 = "C:\\Users\\divya\\Downloads\\VNNew\\Resources\\Images\\shot.png";
            string imgPath2 = "C:\\Users\\divya\\Downloads\\VNNew\\Resources\\Images\\ss.png";
            ImageList.Add(new ImageData(imgPath1));
            ImageList.Add(new ImageData(imgPath2));
        }
    }
}
