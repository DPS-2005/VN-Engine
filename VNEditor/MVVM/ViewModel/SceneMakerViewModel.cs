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
        
        public ObservableCollection<Image> ImageList { get; set; }
        public ToolMode Mode { get; set; }
        public RelayCommand ChangeToolCommand { get; set; }

        public SceneMakerViewModel(DirectoryInfo ProjectDirectory)
        {
            Mode = ToolMode.SELECT;
            ImageList = new ObservableCollection<Image>();
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
