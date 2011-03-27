using System.Collections.Generic;
using System.ComponentModel;
namespace IHome.Models
{
    public class Pager<T> : INotifyPropertyChanged
    {
        public int page_size { get; set; }
        public int page_index { get; set; }
        private int _total;

        public int total
        {
            get { return _total; }
            set { _total = value;
            NotifyPropertyChanged("total");
            }
        }
        public System.Collections.ObjectModel.ObservableCollection<T> data_list { get; set; }
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        #endregion
    }
}
