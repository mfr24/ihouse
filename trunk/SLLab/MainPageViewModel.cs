using System;
using System.ComponentModel;
namespace SLLab
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private SampleClass _sample=new SampleClass();

        public SampleClass Sample
        {
            get { return _sample; }
            set { _sample = value;
            NotifyPropertyChanged("Sample");
            }
        }
        public string StringPro_ui {
            get { return Sample.StringPro; } 
            set{
                Sample.StringPro = value;
            }
        }
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        #endregion
    }
}