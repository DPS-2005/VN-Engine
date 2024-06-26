using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace VNEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            UIElement? element = Keyboard.FocusedElement as UIElement;
            if(element is TextBox tb)
            {
                FrameworkElement parent = (FrameworkElement)tb.Parent;
                while (parent != null && parent is IInputElement && !((IInputElement)parent).Focusable)
                {
                    parent = (FrameworkElement)parent.Parent;
                }
                DependencyObject scope = FocusManager.GetFocusScope(tb);
                FocusManager.SetFocusedElement(scope, parent as IInputElement);
            }
        }
    }
}