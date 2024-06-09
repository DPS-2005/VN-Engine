using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VNHub.Core;
using VNHub.MVVM.ViewModel;

namespace VNHub.Stores
{
    public class NavigationStore
    {
		private ObservableObject? _currentVM;
		public ObservableObject? CurrentVM
		{
			get => _currentVM;
			set 
			{ 
				_currentVM = value;
				OnCurrentViewModelChanged();
			}
		}

		public ProjectsViewModel ProjectVM;
		public LearnViewModel LearnVM;
		public ProjectCreationViewModel ProjectCreationVM;

		public NavigationStore()
		{
			ProjectVM = new ProjectsViewModel(this);
			ProjectCreationVM = new ProjectCreationViewModel(this);
			LearnVM = new LearnViewModel(this);
		}

        private void OnCurrentViewModelChanged()
        {
			CurrentViewModelChanged?.Invoke();
        }

        public event Action? CurrentViewModelChanged;
	}
}
