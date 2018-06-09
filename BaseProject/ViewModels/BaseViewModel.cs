using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using BaseProject.Models;
using BaseProject.Services;

namespace BaseProject.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        private int _busyCount = 0;
        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        public ServiceManager ServiceManager;

        private bool _isDisconect;
        public bool IsDisconect
        {
            get { return _isDisconect; }
            set
            {
                SetProperty(ref _isDisconect, value);
            }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        public BaseViewModel()
        {
            ServiceManager = new ServiceManager(this);
        }


        public void OnPreFeed()
        {
            _busyCount--;
            IsBusy = true;
        }

        public void OnFeedCompleted()
        {
            _busyCount++;
            if (_busyCount > 0) _busyCount = 0;
            if (_busyCount == 0)
            {
                IsBusy = false;
            }
        }

    }
}

