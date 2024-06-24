using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VNEditor.MVVM.Model
{
    public class ImageTransform
    {
        public double PosX { get; set; }
        public double PosY { get; set; }
        public int ZIndex { get; set; }
        public double Rotation { get; set; }
        public double ScaleX { get; set; }
        public double ScaleY { get; set; }


        public ImageTransform()
        {
            PosX = 0;
            PosY = 0;
            ZIndex = 0;
            Rotation = 0;
            ScaleX = 1;
            ScaleY = 1;
        }

        public ImageTransform(double posX, double posy)
        {
            PosX = posX;
            PosY = posy;
            ZIndex = 0;
            Rotation = 0;
            ScaleX = 1;
            ScaleY = 1;
        }

        public ImageTransform(double posX, double posy, int zIndex, double rotation, double scaleX, double scaleY)
        {
            PosX = posX;
            PosY = posy;
            ZIndex = zIndex;
            Rotation = rotation;
            ScaleX = scaleX;
            ScaleY = scaleY;
        }

        public ImageTransform(ImageTransform transform)
        {
            this.PosX = transform.PosX;
            this.PosY = transform.PosY;
            this.ZIndex = transform.ZIndex;
            this.Rotation = transform.Rotation;
            this.ScaleX = transform.ScaleX;
            this.ScaleY = transform.ScaleY;
        }
    }
}
