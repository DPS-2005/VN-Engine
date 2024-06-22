using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VNEditor.MVVM.Model;

namespace VNEditor.MVVM.ViewModel
{
    public class ExplorerViewModel
    {
        public ExplorerNode Root { get; set; }

        public ExplorerViewModel(DirectoryInfo ProjectDirectory)
        {
            Root = new ExplorerNode(NodeType.FOLDER,ProjectDirectory.Name, ProjectDirectory.FullName, null);
            PopulateTree(Root);
            Debug.Print("tree populated");
        }

        private void PopulateTree(ExplorerNode node)
        {
            List<ExplorerNode> fileNodes = new List<ExplorerNode>(
                Directory.EnumerateFiles(node.Path).Select(
                    file => new ExplorerNode(NodeType.FILE, Path.GetFileName(file), file, null)));

            List<ExplorerNode> folderNodes = new List<ExplorerNode>(
                Directory.EnumerateDirectories(node.Path).Select(
                    folder => new ExplorerNode(NodeType.FOLDER, Path.GetFileName(folder), folder, null)));
            node.Children = new List<ExplorerNode>(fileNodes.Concat(folderNodes));

            foreach(ExplorerNode folderNode in folderNodes)
            {
                PopulateTree(folderNode);
            }
        }
    }
}
