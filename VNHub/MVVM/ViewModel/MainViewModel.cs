using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VNHub.Core;

namespace VNHub.MVVM.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        public ProjectViewModel ProjectVM { get; set; }
        public LearnViewModel LearnVM { get; set; }

        public RelayCommand ProjectViewCommand { get; set; }
        public RelayCommand LearnViewCommand { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }


        public MainViewModel()
        {
            ProjectVM = new ProjectViewModel();
            LearnVM = new LearnViewModel();
            _currentView = ProjectVM;
            ProjectViewCommand = new RelayCommand(o =>
            {
                CurrentView = ProjectVM;
            });

            LearnViewCommand = new RelayCommand(o =>
            {
                CurrentView = LearnVM;
            });

        }
    }
}