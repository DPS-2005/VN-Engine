using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VNHub.MVVM.Model
{
	[JsonObject]
    public class FileRecord
    {
		private List<FileInfo> _files = new List<FileInfo>();

		public List<FileInfo> Files
		{
			get { return _files; }
			set { _files =  value; }
		}
	}
}
