using System;
using System.Collections.ObjectModel;
using System.IO;

namespace Explorer.Shared.ViewModels
{
    public class DirectoryTabItemViewModel : BaseViewModel
    {
        #region Public Properties 
        public string FilePath { get; set; }
        public string Name { get; set; }
        public ObservableCollection<FileEntityViewModel> DirectoriesAndFiles { get; set; } = new ObservableCollection<FileEntityViewModel>();
        public FileEntityViewModel SelectedFileEntity
        {
            get;
            set;
        }
        #endregion

        #region Events
        public event EventHandler Closed;
        #endregion

        #region  Commands
        public DelegateCommand OpenCommand { get; }
        public DelegateCommand CloseCommand { get; }
        #endregion

        #region Constructor
        public DirectoryTabItemViewModel()
        {
            Name = "Мой компьютер";
            OpenCommand = new DelegateCommand(Open);
            CloseCommand = new DelegateCommand(OnClose);
            foreach (var logicalDrive in Directory.GetLogicalDrives())
            {
                DirectoriesAndFiles.Add(new DirectoryViewModel(logicalDrive));
            }
        }

        
        #endregion

        #region Commands Methods
        private void Open(object parameter)
        {
            if (parameter is DirectoryViewModel directoryViewModel)
            {
                FilePath = directoryViewModel.FullName;
                Name = directoryViewModel.Name;
                DirectoriesAndFiles.Clear();
                var directoryInfo = new DirectoryInfo(FilePath);
                foreach (var directory in directoryInfo.GetDirectories())
                {
                    DirectoriesAndFiles.Add(new DirectoryViewModel(directory));
                }
                foreach (var file in directoryInfo.GetFiles())
                {
                    DirectoriesAndFiles.Add(new FileViewModel(file));
                }
            }
        }
        private void OnClose(object obj)
        {
            Closed?.Invoke(this,EventArgs.Empty);
        }

        #endregion
    }
}