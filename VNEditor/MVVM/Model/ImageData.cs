using System.IO;
using System.Security.Permissions;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace VNEditor.MVVM.Model
{
    public class ImageData
    {
        public string ImagePath { get; set; }
        public TranslateTransform Transform { get; set; }

        public ImageData(string imagePath, TranslateTransform transform)
        {
            ImagePath = imagePath;
            Transform = transform;
        }
    }

}
