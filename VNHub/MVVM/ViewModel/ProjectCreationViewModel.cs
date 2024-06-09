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

        public ProjectCreationViewModel(NavigationStore navigationStore)
        {
            GoBackCommand = new RelayCommand(o =>
            {
                navigationStore.CurrentVM = navigationStore.ProjectVM;
            });
        }
    }
}
