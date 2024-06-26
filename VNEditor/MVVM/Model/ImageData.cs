using System.IO;
using System.Security.Permissions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace VNEditor.MVVM.Model
{
    public class ImageData
    {
        public string ImagePath { get; set; }
        public ImageTransform Transform { get; set; }

        public ImageData(string imagePath, ImageTransform transform)
        {
            ImagePath = imagePath;
            Transform = transform;
        }
    }

}
