using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VNEditor.Core;

namespace VNEditor.MVVM.Model
{
    public class ExplorerNode : ObservableObject
    {
        public NodeType Type;
        private string _name;

        public string Name
        {
            get { return _name; }
            set 
            { 
                _name = value; 
                OnPropertyChanged();
            }
        }

        private string _path;

        public string Path
        {
            get { return _path; }
            set 
            { 
                _path = value;
                OnPropertyChanged();
            }
        }

        private List<ExplorerNode>? _children;

        public List<ExplorerNode>? Children
        {
            get { return _children; }
            set { 
                _children = value;
                OnPropertyChanged();
            }
        }


        public ExplorerNode(NodeType type, string name, string path, List<ExplorerNode>? children)
        {
            this.Type = type;
            this.Name = name;
            this.Path = path;
            this.Children = children;
        }
    }
}
