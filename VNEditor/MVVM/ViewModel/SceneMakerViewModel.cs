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
        
        public ObservableCollection<ImageData> ImageList { get; set; }
        public ToolMode Mode { get; set; }
        public RelayCommand ChangeToolCommand { get; set; }

        public SceneMakerViewModel(DirectoryInfo ProjectDirectory)
        {
            Mode = ToolMode.SELECT;
            ImageList = new ObservableCollection<ImageData>();
            //temperory code for testing
            string imgPath1 = "C:\\Users\\divya\\Downloads\\VNNew\\Resources\\Images\\shot.png";
            string imgPath2 = "C:\\Users\\divya\\Downloads\\VNNew\\Resources\\Images\\ss.png";
            ImageList.Add(new ImageData(imgPath1));
            ImageList.Add(new ImageData(imgPath2));
            ChangeToolCommand = new RelayCommand(o =>
            {
                if(o is TabItem item)
                {
                    Mode = ToolModeProperty.GetToolValue(item);
                }
            });
        }
    }
}
