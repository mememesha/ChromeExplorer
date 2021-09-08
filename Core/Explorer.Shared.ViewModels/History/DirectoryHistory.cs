using System;
using System.Collections;
using System.Collections.Generic;

namespace Explorer.Shared.ViewModels
{
    class DirectoryHistory : IDirectoryHistory
    {
        #region Private Fields
        private DirectoryNode _head;
        #endregion

        #region Public Properties

        public bool CanMoveBack => Current.PreviosNode != null;
        public bool CanMoveForward => Current.NextNode != null;

        public DirectoryNode Current { get; private set; }
        #endregion

        #region  Events

        public event EventHandler HistoryChanged;

        #endregion
        
        #region Constructor

        public DirectoryHistory(string directoryPath, string directoryPathName)
        {
            _head = new DirectoryNode(directoryPath, directoryPathName);
            Current = _head;
        }

        #endregion

        #region public Methods
        public void MoveBack()
        {
            var prev= Current.PreviosNode;

            Current = prev;
            
            RaiseHistoryChanged();
        }

        public void MoveForward()
        {
            var next = Current.NextNode;

            Current = next;

            RaiseHistoryChanged();
        }

        public void Add(string filePath, string name)
        {
            var node = new DirectoryNode(filePath, name)
            {
                PreviosNode = Current
            };
            Current.NextNode = node;
            Current = node;

            RaiseHistoryChanged();
        }

        #endregion

        #region private Methods

        private void RaiseHistoryChanged() => HistoryChanged?.Invoke(this,EventArgs.Empty);

        #endregion

        #region Enumerator

        public IEnumerator<DirectoryNode> GetEnumerator()
        {
            yield return Current;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion

    }
}