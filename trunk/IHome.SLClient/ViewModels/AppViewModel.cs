using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows;
using System.Collections.ObjectModel;

namespace IHome.SLClient
{

    public class AppViewModel : ILight.Core.Model.IAppVM
    {

        public AppViewModel()
        {
            
        }
        private bool _isBusy = false;

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                if (value)
                {
                    _requestCount += 1;

                }
                else
                {
                    _requestCount -= 1;
                }
                if (_requestCount > 0)
                {
                    lock (this)
                    {
                        if (_isBusy) return;
                        _isBusy = true;
                        NotifyPropertyChanged("IsBusy");
                    }
                }
                else
                {
                    lock (this)
                    {
                        if (!_isBusy) return;
                        _isBusy = false;
                        NotifyPropertyChanged("IsBusy");
                    }
                }

            }
        }
        private int _requestCount = 0;

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        #endregion
    }
}