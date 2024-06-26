using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VNEditor.Core;

namespace VNEditor.MVVM.Model
{
    public class ImageTransform : ObservableObject
    {
        private double _posX;

        public double PosX
        {
            get { return _posX; }
            set 
            { 
                _posX = value;
                OnPropertyChanged();
            }
        }

        private double _posY;

        public double PosY
        {
            get { return _posY; }
            set 
            {
                _posY = value;
                OnPropertyChanged(); 
            }
        }

        private int _zIndex;

        public int ZIndex
        {
            get { return _zIndex; }
            set 
            {
                _zIndex = value;
                OnPropertyChanged();
            }
        }

        private double _rotation;

        public double Rotation
        {
            get { return _rotation; }
            set
            {
                _rotation = value;
                OnPropertyChanged();
            }
        }
        private double _scaleX;

        public double ScaleX
        {
            get { return _scaleX; }
            set
            {
                _scaleX = value;
                OnPropertyChanged();
            }
        }
        private double _scaleY;

        public double ScaleY
        {
            get { return _scaleY; }
            set
            {
                _scaleY = value;
                OnPropertyChanged();
            }
        }


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
