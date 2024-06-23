using Microsoft.VisualBasic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using VNEditor.Core;
using VNEditor.MVVM.Model;

namespace VNEditor.MVVM.ViewModel
{
    public class ExplorerViewModel:ObservableObject
    {
        private ExplorerNode _root;

        public ExplorerNode Root
        {
            get { return _root; }
            set 
            { 
                _root = value;
                OnPropertyChanged();
            }
        }

        public ExplorerViewModel(DirectoryInfo ProjectDirectory)
        {
            Root = new ExplorerNode(ProjectDirectory, null);
            PopulateTree(Root);
        }
        private void PopulateTree(ExplorerNode node)
        {
            List<ExplorerNode> fileNodes = new List<ExplorerNode>(
                Directory.EnumerateFiles(node.ItemInfo.FullName).Select(
                    filePath => new ExplorerNode(new FileInfo(filePath), null)));

            List<ExplorerNode> folderNodes = new List<ExplorerNode>(
                Directory.EnumerateDirectories(node.ItemInfo.FullName).Select(
                    folderPath => new ExplorerNode(new DirectoryInfo(folderPath), null)));
            node.Children = new List<ExplorerNode>(fileNodes.Concat(folderNodes));

            foreach(ExplorerNode folderNode in folderNodes)
            {
                PopulateTree(folderNode);
            }
        }
    }
}
