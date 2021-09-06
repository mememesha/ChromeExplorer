using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace Explorer.Shared.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region Public Properties   
        
        public ObservableCollection<DirectoryTabItemViewModel> DirectoryTabItems { get; set; } =
            new ObservableCollection<DirectoryTabItemViewModel>();
        public DirectoryTabItemViewModel CurrentDirectoryTabItem { get; set; }

        #endregion

        #region  Commands

        public DelegateCommand AddNewTabCommand { get; }

        #endregion

        #region Constructor

        public MainViewModel()
        {
            AddNewTabCommand = new DelegateCommand(OnAddTabItem);
            AddTabItemViewModel();            
            CurrentDirectoryTabItem = DirectoryTabItems.FirstOrDefault();
        }

        private void OnAddTabItem(object obj)
        {
            AddTabItemViewModel();
        }

        #endregion

        #region Commands Methods      
        private void AddTabItemViewModel()
        {
            var vm = new DirectoryTabItemViewModel();
            vm.Closed += vm_Closed;   
            DirectoryTabItems.Add(vm);
            CurrentDirectoryTabItem = vm;
        }

        private void vm_Closed(object sender, System.EventArgs e)
        {
            if(sender is DirectoryTabItemViewModel directoryTabItemViewModel)
            {
                CloseTab(directoryTabItemViewModel);
            }
        }

        private void CloseTab(DirectoryTabItemViewModel directoryTabItemViewModel)
        {
            directoryTabItemViewModel.Closed -= vm_Closed;
            DirectoryTabItems.Remove(directoryTabItemViewModel);
            CurrentDirectoryTabItem = DirectoryTabItems.FirstOrDefault();
        }

        #endregion

    }
}
