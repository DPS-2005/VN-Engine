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
    public class ProjectRecord
    {
		private List<Project> _projects = new List<Project>();

		public List<Project> Projects
		{
			get { return _projects; }
			set { _projects =  value; }
		}
	}
}
