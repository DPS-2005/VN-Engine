using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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

    public class CenterXConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
