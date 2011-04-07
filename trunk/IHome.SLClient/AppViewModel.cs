using System;
using System.ComponentModel;
using System.Windows.Input;
using IHome.Models;

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
        public static ICommand ShowWin
        {
            get
            {
                return new ILight.Core.Model.CommandBase((p) =>
                {
                    CmdWin win;
                    int width = 600;
                    int height = 400;
                    if(p is CmdWin)  win= p as CmdWin;
                    else  win = Newtonsoft.Json.JsonConvert.DeserializeObject<CmdWin>((string)p);
                    #region 最近访问
                    //if (Recent.item_list.Contains(dll))
                    //{
                    //    Recent.item_list.RemoveAt(Recent.item_list.IndexOf(dll));
                    //}
                    //if (Recent.item_list.Count == _recentMax)
                    //{
                    //    Recent.item_list.RemoveAt(Recent.item_list.Count - 1);
                    //}
                    //Recent.item_list.Insert(0, dll);
                    #endregion
                    Action<object> action=(frm) =>
                    {
                        if (win.Win == IHome.Models.CmdWin.WinType.tab)
                        {
                            foreach (ILight.Controls.RadControls.RadTabItemCloseable item in ((Telerik.Windows.Controls.RadTabControl)((System.Windows.FrameworkElement)System.Windows.Application.Current.RootVisual).FindName("MainTab")).Items)
                            {
                                if (item.Content.GetType().FullName == win.type_name)
                                {
                                    item.IsSelected = true;
                                    return;
                                }
                            }

                            ILight.Controls.RadControls.RadTabItemCloseable tab = new ILight.Controls.RadControls.RadTabItemCloseable() { Header = win.name, Content = frm, IsSelected = true };
                            ((Telerik.Windows.Controls.RadTabControl)((System.Windows.FrameworkElement)System.Windows.Application.Current.RootVisual).FindName("MainTab")).Items.Add(tab);
                        }
                        else if (win.Win == IHome.Models.CmdWin.WinType.window)
                        {
                            Telerik.Windows.Controls.RadWindow child = new Telerik.Windows.Controls.RadWindow() { Header = win.name, Content = frm };
                            child.WindowStartupLocation = Telerik.Windows.Controls.WindowStartupLocation.CenterScreen;
                            child.Show();
                        }
                        else if (win.Win == IHome.Models.CmdWin.WinType.modal)
                        {
                            Telerik.Windows.Controls.RadWindow child = new Telerik.Windows.Controls.RadWindow() { Header = win.name, Content = frm};
                            child.WindowStartupLocation =Telerik.Windows.Controls.WindowStartupLocation.CenterScreen;
                            child.ShowDialog();
                        }
                    };
                    if (win.VeiwModel != null)
                    {
                        ILight.Core.Reflection.AssemblyProvider.GetInstanceAsync(win.type_name, win.xap_name, win.version, action,win.VeiwModel);
                    }
                    else
                    {

                        ILight.Core.Reflection.AssemblyProvider.GetInstanceAsync(win.type_name, win.xap_name, win.version, action);
                    }
                });
            }
        }
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