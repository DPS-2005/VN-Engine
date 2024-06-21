using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VNHub.Core;
using VNHub.Stores;

namespace VNHub.MVVM.ViewModel
{
    public class ProjectCreationViewModel : ObservableObject
    {
        public RelayCommand GoBackCommand { get; set; }
        public RelayCommand BrowseDialogCommand { get; set; }
        public RelayCommand CreateCommand { get; set; }

        private String? _name;

        public String? Name
        {
            get { return _name; }
            set 
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        private String? _location;

        public String? Location
        {
            get { return _location; }
            set 
            { 
                _location = value;
                OnPropertyChanged();
            }
        }



        public ProjectCreationViewModel(NavigationStore navigationStore)
        {
            GoBackCommand = new RelayCommand(o =>
            {
                navigationStore.CurrentVM = navigationStore.ProjectVM;
            });

            BrowseDialogCommand = new RelayCommand(o =>
            {
                var browseDialog = new OpenFolderDialog
                {
                    Title = "Select Folder",
                    InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments),                
                };
                bool? result = browseDialog.ShowDialog();
                if(result != null)
                {
                    if(result == true)
                    {
                        Location = browseDialog.FolderName;
                    }
                }
            });

            CreateCommand = new RelayCommand(o =>{
                navigationStore.ProjectVM.AddProject(new Model.Project(Name, Location));
            });

        }
    }
}
