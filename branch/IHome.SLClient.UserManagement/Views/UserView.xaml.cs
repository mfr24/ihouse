using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace IHome.SLClient.UserManagement
{
    /// <summary>
    /// Interaction logic for UserView.xaml
    /// </summary>
    public partial class UserView : UserControl
    {


        public int ViewIndex
        {
            get { return (int)GetValue(ViewIndexProperty); }
            set { SetValue(ViewIndexProperty, value); }
        }

        public static readonly DependencyProperty ViewIndexProperty =
            DependencyProperty.Register("ViewIndex", typeof(int), typeof(UserView), new PropertyMetadata(0,
                (d, e) =>
                {
                    ViewTo((UserView)d, (int)e.NewValue);
                }));
        public static void ViewTo(UserView view, int viewIndex)
        {

            ((Telerik.Windows.Controls.TransitionEffects.SlideAndZoomTransition)view.Transition.Transition).SlideDirection = (FlowDirection)viewIndex;
            view.Transition.Content = view.UiList[viewIndex];
        }

        public UserView()
        {
            this.InitializeComponent();
            _uiList = new UIElement[] { new UserListView() { DataContext = ((UserViewModel)this.Resources["UserViewModelDataSource"]).ListVM }, 
                new UserDetailView(){DataContext=((UserViewModel)this.Resources["UserViewModelDataSource"]).DetailVM} };
            Transition.Content = _uiList[0];
            Binding b=new Binding();
            b.Source=this.Resources["UserViewModelDataSource"];
            b.Path=new PropertyPath("ViewIndex");
            this.SetBinding(ViewIndexProperty, b);
        }
        private UIElement[] _uiList;

        public UIElement[] UiList
        {
            get { return _uiList; }
        }
    }
}