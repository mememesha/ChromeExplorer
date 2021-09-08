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

        #region Events
        public event EventHandler Closed;
        #endregion

        #region  Commands

        public DelegateCommand CloseCommand { get; }
        public DelegateCommand AddNewTabCommand { get; }

        #endregion

        #region Constructor

        public MainViewModel()
        {
            AddNewTabCommand = new DelegateCommand(OnAddTabItem);
            CloseCommand = new DelegateCommand(OnClose);
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
            DirectoryTabItems.Add(vm);
            CurrentDirectoryTabItem = vm;
        }
        
        private void CloseTab(DirectoryTabItemViewModel directoryTabItemViewModel)
        {
            DirectoryTabItems.Remove(directoryTabItemViewModel);
            CurrentDirectoryTabItem = DirectoryTabItems.LastOrDefault();
        }
        private void OnClose(object obj)
        {
            if (obj is DirectoryTabItemViewModel directoryTabItemViewModel)
            {
                CloseTab(directoryTabItemViewModel);
            }
        }

        #endregion

    }
}
