using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VNEditor.MVVM.ViewModel
{
    public class ExplorerViewModel
    {
        public ObservableCollection<FileInfo> ProjectFiles { get; set; }
    }
}
