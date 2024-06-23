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
        public double Posy { get; set; }
        public int ZIndex { get; set; }
        public double Rotation { get; set; }
        public double Scale { get; set; }


        public ImageTransform()
        {
            PosX = 0;
            Posy = 0;
            ZIndex = 0;
            Rotation = 0;
            Scale = 1;
        }

        public ImageTransform(double posX, double posy)
        {
            PosX = posX;
            Posy = posy;
            ZIndex = 0;
            Rotation = 0;
            Scale = 1;
        }

        public ImageTransform(double posX, double posy, int zIndex, double rotation, double scale)
        {
            PosX = posX;
            Posy = posy;
            ZIndex = zIndex;
            Rotation = rotation;
            Scale = scale;
        }

        public ImageTransform(ImageTransform transform)
        {
            this.PosX = transform.PosX;
            this.Posy = transform.Posy;
            this.ZIndex = transform.ZIndex;
            this.Rotation = transform.Rotation;
            this.Scale = transform.Scale;
        }
    }
}
