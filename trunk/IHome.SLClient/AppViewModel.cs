using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows;
using System.Collections.ObjectModel;
using System.Windows.Controls;
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
                    CmdWin win = Newtonsoft.Json.JsonConvert.DeserializeObject<CmdWin>((string)p);
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
                    ILight.Core.Reflection.AssemblyProvider.GetInstanceAsync(win.type_name, win.xap_name, win.version, (frm) =>
                    {
                        if (win.Win == IHome.Models.CmdWin.WinType.tab)
                        {
                            foreach (ILight.Controls.RadControls.RadTabItemCloseable item in ((Telerik.Windows.Controls.RadTabControl)((FrameworkElement)Application.Current.RootVisual).FindName("MainTab")).Items)
                            {
                                if (item.Content.GetType().FullName == win.type_name)
                                {
                                    item.IsSelected = true;
                                    return;
                                }
                            }

                            ILight.Controls.RadControls.RadTabItemCloseable tab = new ILight.Controls.RadControls.RadTabItemCloseable() { Header = win.name, Content = frm, IsSelected = true };
                            ((Telerik.Windows.Controls.RadTabControl)((FrameworkElement)Application.Current.RootVisual).FindName("MainTab")).Items.Add(tab);
                        }
                        else if (win.Win == IHome.Models.CmdWin.WinType.child)
                        {
                            ChildWindow child = new ChildWindow() { Content = frm };
                            child.Show();
                        }
                    });
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