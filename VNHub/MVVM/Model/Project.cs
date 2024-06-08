using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VNHub.MVVM.Model
{
    public class Project
    {
        public String Name;
        public String Location;

        public Project(string name, string location)
        {
            Name = name;
            Location = location;
        }
    }
}
