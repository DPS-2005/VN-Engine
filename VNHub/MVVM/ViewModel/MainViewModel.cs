using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VNHub.Core;
using VNHub.Stores;

namespace VNHub.MVVM.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        public RelayCommand ProjectViewCommand { get; set; }
        public RelayCommand LearnViewCommand { get; set; }

        private readonly NavigationStore _navigationStore;
        public ObservableObject? CurrentViewModel => _navigationStore.CurrentVM;


        public MainViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            //RelayCommands
            ProjectViewCommand = new RelayCommand(o =>
            {
                _navigationStore.CurrentVM = _navigationStore.ProjectVM;
            });

            LearnViewCommand = new RelayCommand(o =>
            {
                _navigationStore.CurrentVM = _navigationStore.LearnVM;
            });

        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}