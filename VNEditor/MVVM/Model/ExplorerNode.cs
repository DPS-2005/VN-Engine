using System.IO;
using VNEditor.Core;

namespace VNEditor.MVVM.Model
{
    public class ExplorerNode : ObservableObject
    {
        public FileSystemInfo ItemInfo;

        private String _name;

        public String Name
        {
            get { return _name; }
            set 
            { 
                _name = value;
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

        private bool _isEditable;

        public bool IsEditable
        {
            get { return _isEditable; }
            set { 
                _isEditable = value; 
                OnPropertyChanged();
            }
        }

        public RelayCommand RenameCommand { get; set; }
        public RelayCommand FinishRenameCommand { get; set; }



        public ExplorerNode(FileSystemInfo itemInfo, List<ExplorerNode>? children)
        {
            _name = itemInfo.Name;
            this.ItemInfo = itemInfo;
            this.Children = children;
            IsEditable = false;
            RenameCommand = new RelayCommand(o =>
            {
                IsEditable = true;
            });

            FinishRenameCommand = new RelayCommand(o =>
            {
                if((ItemInfo.GetType() != typeof(FileInfo) || (Name.LastIndexOf('.') != -1 && Name.Remove(Name.LastIndexOf('.')) != null)))
                {
                    IsEditable = false;
                    DirectoryInfo? parentDirectory = Directory.GetParent(ItemInfo.FullName);
                    if(parentDirectory != null)
                    {
                        String newPath = Path.Combine(parentDirectory.FullName, Name);
                        Rename(newPath);
                    }
                    else
                    {
                        String newPath = Name;
                        Rename(newPath);
                    }
                }
            });
        }

        public void Rename(String newPath)
        {
            if(ItemInfo is DirectoryInfo )
            {
                Directory.Move(ItemInfo.FullName, newPath);
                ItemInfo = new DirectoryInfo(newPath);
            }
            else if(ItemInfo is FileInfo)
            {
                File.Move(ItemInfo.FullName, newPath);
                ItemInfo = new FileInfo(newPath);
            }
        }
    }
}
