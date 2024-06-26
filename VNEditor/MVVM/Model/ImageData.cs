using System.Security.Permissions;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace VNEditor.MVVM.Model
{
    public class ImageData
    {
        public string ImagePath { get; set; }
        public ImageTransform Transform { get; set; }

        public ImageData(string path)
        {
            ImagePath = path;
            Transform = new ImageTransform();
        }
        public ImageData(String path, ImageTransform transform)
        {
            ImagePath = path;
            Transform = transform;
        }       
    }

}
