using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;

namespace Explorer.Shared.ViewModels
{
    public class DirectoryTabItemViewModel : BaseViewModel
    {
        #region Private fields

        private readonly IDirectoryHistory _history;

        #endregion

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
        
        #endregion

        #region  Commands

        public DelegateCommand OpenCommand { get; }
        public DelegateCommand MoveForwardCommand { get; set; }
        public DelegateCommand MoveBackCommand { get; set; }

        #endregion

        #region Constructor

        public DirectoryTabItemViewModel()
        {
            _history = new DirectoryHistory("Мой компьютер", "Мой компьютер");

            OpenCommand = new DelegateCommand(Open);
            MoveBackCommand = new DelegateCommand(OnMoveBack, CanMoveBack);
            MoveForwardCommand = new DelegateCommand(OnMoveForward, CanMoveForward);

            Name = _history.Current.DirectoryPathName;
            FilePath = _history.Current.DirectoryPath;

            OpenDirectory();

            _history.HistoryChanged += _history_HistoryChanged;
        }
        
        #endregion

        #region Commands Methods

        private void Open(object parameter)
        {
            if (parameter is DirectoryViewModel directoryViewModel)
            {
                FilePath = directoryViewModel.FullName;
                Name = directoryViewModel.Name;

                _history.Add(FilePath,Name);

                OpenDirectory();
            }
            else if (parameter is FileViewModel fileViewModel)
            {
                new Process
                {
                    StartInfo = new ProcessStartInfo(fileViewModel.FullName)
                    {
                        WorkingDirectory = Path.GetDirectoryName(fileViewModel.FullName),
                        UseShellExecute = true
                    }
                }.Start();
            }
        }
        private bool CanMoveBack(object obj) => _history.CanMoveBack;
        private void OnMoveBack(object obj)
        {
            _history.MoveBack();
            var current = _history.Current;
            FilePath = current.DirectoryPath;
            Name = current.DirectoryPathName;
            OpenDirectory();
        }
        private bool CanMoveForward(object obj) => _history.CanMoveForward;
        private void OnMoveForward(object obj)
        {
           _history.MoveForward();
           var current = _history.Current;
           FilePath = current.DirectoryPath;
           Name = current.DirectoryPathName;
           OpenDirectory();
        }

        #endregion

        #region Private Methods

        private void OpenDirectory()
        {
            DirectoriesAndFiles.Clear();
            if (Name == "Мой компьютер")
            {
                foreach (var logicalDrive in Directory.GetLogicalDrives())
                    DirectoriesAndFiles.Add(new DirectoryViewModel(logicalDrive));
                return;
            }

            var directoryInfo = new DirectoryInfo(FilePath);

            try
            {
                foreach (var directory in directoryInfo.GetDirectories())
                {
                    DirectoriesAndFiles.Add(new DirectoryViewModel(directory));
                }

                foreach (var file in directoryInfo.GetFiles())
                {
                    DirectoriesAndFiles.Add(new FileViewModel(file));
                }
            }
            catch (Exception e)
            {
                //todo try exception
            }

        }
        private void _history_HistoryChanged(object sender, EventArgs e)
        {
            MoveBackCommand?.NotifyCanExecuteChanged();
            MoveForwardCommand?.NotifyCanExecuteChanged();
        }

        #endregion

        #region Public Methods

        public void Open(FileEntityViewModel viewModel)
        {
            Open((object)viewModel);
        }

        #endregion
    }
}