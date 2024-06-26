using System;
using System.Collections.Generic;
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
using VNEditor.MVVM.Model;

namespace VNEditor.MVVM.View
{
    /// <summary>
    /// Interaction logic for ExplorerView.xaml
    /// </summary>
    public partial class ExplorerView : UserControl
    {
        public ExplorerView()
        {
            InitializeComponent();
        }

        private void Node_MouseMove(object sender, MouseEventArgs e)
        {
            TextBlock? fileNode = sender as TextBlock;
            ExplorerNode? node = fileNode?.DataContext as ExplorerNode;
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                DragDrop.DoDragDrop(fileNode, node?.ItemInfo, DragDropEffects.Copy);
            }
        }
    }
}
