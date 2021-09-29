using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Windows.Input;

namespace Explorer.Shared.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region Public Properties   
        
        public ObservableCollection<DirectoryTabItemViewModel> DirectoryTabItems { get; set; } =
            new ObservableCollection<DirectoryTabItemViewModel>();
        public DirectoryTabItemViewModel CurrentDirectoryTabItem { get; set; }

        public ObservableCollection<MenuItemViewModel> Bookmarks { get; private set; } =
            new ObservableCollection<MenuItemViewModel>();
        #endregion

        #region Events
        public event EventHandler Closed;
        #endregion

        #region  Commands
        
        public DelegateCommand BookMarkClickCommand { get; }
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
            BookMarkClickCommand = new DelegateCommand(OnBookmarkClicked);
            Bookmarks = new ObservableCollection<MenuItemViewModel>
            {
                new MenuItemViewModel("C:\\")
                {
                    Header = "C:\\",
                    Command = BookMarkClickCommand
                }
            };

        }

        private void OnBookmarkClicked(object path)
        {
            var spath = (string)path;
            if (Directory.Exists(spath))
            {
                CurrentDirectoryTabItem.Open(new DirectoryViewModel(new DirectoryInfo(spath)));
            }
            else
            {
                CurrentDirectoryTabItem.Open(new FileViewModel(spath));
            }
        }

        private void OnAddTabItem(object obj)
        {
            AddTabItemViewModel();
        }

        #endregion

        #region Private Methods
        public void ApplicationClosing()
        {
            
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

    public class MenuItemViewModel
    {
        public string Path { get; set; }
        public string Header { get; set; }
        public ICommand Command { get; set; }
        public object CommandParameter { get; set; }
        public IList<MenuItemViewModel> Items { get; set; }
        public MenuItemViewModel(string path)
        {
            Path = path;
            CommandParameter = path;
        }
    }
}
