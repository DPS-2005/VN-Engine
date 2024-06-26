using HandyControl.Tools.Extension;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using VNEditor.MVVM.Model;
using VNEditor.MVVM.ViewModel;

namespace VNEditor.MVVM.View
{
    /// <summary>
    /// Interaction logic for SceneMakerView.xaml
    /// </summary>
    public partial class SceneMakerView : UserControl
    {
        public SceneMakerView()
        {
            InitializeComponent();
        }

        private void canvas_Drop(object sender, DragEventArgs e)
        {
            object data = e.Data.GetData(DataFormats.Serializable);
            Point dropPosition = e.GetPosition(canvas);
            if (data is FileSystemInfo fileInfo)
            {
                ImageTransform transform = new ImageTransform(dropPosition.X, dropPosition.Y);
                ImageData imgData = new ImageData(fileInfo.FullName, transform);
                SceneMakerViewModel? sceneMaker = DataContext as SceneMakerViewModel;
                sceneMaker?.CurrentScene.Images.Add(imgData);
            }
            else if(data is Image image)
            {
                
            }
        }

        private void Image_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                Image? image = sender as Image;
                DragDrop.DoDragDrop(image, new DataObject(DataFormats.Serializable,image), DragDropEffects.Move);
            }
        }
    }
    public static class ToolModeProperty
    {
        public static ToolMode GetToolValue(DependencyObject obj)
        {
            return (ToolMode)obj.GetValue(ToolValueProperty);
        }

        public static void SetToolValue(DependencyObject obj, int value)
        {
            obj.SetValue(ToolValueProperty, value);
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ToolValueProperty =
            DependencyProperty.RegisterAttached("ToolValue", typeof(ToolMode), typeof(object), new PropertyMetadata(ToolMode.SELECT));
    }

    public class TransformConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ImageTransform? transform = value as ImageTransform;
            if (transform != null)
                return new MatrixTransform(1, 0, 0, 1, transform.PosX, transform.PosY);
            else
                return new MatrixTransform(1, 0, 0, 1, 0, 0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            MatrixTransform? transform = value as MatrixTransform;
            if (transform != null)
                return new ImageTransform(transform.Matrix.OffsetX, transform.Matrix.OffsetY);
            else
                return new ImageTransform();
        }
    }

}
