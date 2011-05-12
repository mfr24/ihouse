using System;
using System.ComponentModel;
using System.Windows.Input;
using IHome.Models;
using System.Windows.Data;

namespace IHome.Models
{

    public class AppViewModel : ILight.Core.Model.IAppVM
    {


        public AppViewModel()
        {

        }

        private int _requestCount = 0;
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

        private static ICommand GetCommand()
        {
            return null;
        }
        private ICommand _cmd = GetCommand();
        public ICommand ShowWin
        {
            get
            {
                return _cmd;
            }
        }
        public bool IsInDesignMode { get; set; }
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