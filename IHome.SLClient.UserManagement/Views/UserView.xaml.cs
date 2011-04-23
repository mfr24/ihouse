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
		public UserView()
		{
			this.InitializeComponent();
            _uiList = new UIElement[] { new UserListView() { DataContext = ((UserViewModel)this.Resources["UserViewModelDataSource"]).ListVM }, 
                new UserDetailView(){DataContext=((UserViewModel)this.Resources["UserViewModelDataSource"]).DetailVM} };
            Transition.Content = _uiList[0];
			
			// Insert code required on object creation below this point.
		}
        private UIElement[] _uiList;

        private void RadButton_Click_Select(object sender, RoutedEventArgs e)
        {
            ((Telerik.Windows.Controls.TransitionEffects.SlideAndZoomTransition)Transition.Transition).SlideDirection = FlowDirection.LeftToRight;
            this.Transition.Content = _uiList[0];
        }
        
        private void RadButton_Click_Add(object sender, RoutedEventArgs e)
        {
            ((Telerik.Windows.Controls.TransitionEffects.SlideAndZoomTransition)Transition.Transition).SlideDirection = FlowDirection.RightToLeft;
            this.Transition.Content = _uiList[1];
        }

        private void RadButton_Click_Update(object sender, RoutedEventArgs e)
        {
            ((Telerik.Windows.Controls.TransitionEffects.SlideAndZoomTransition)Transition.Transition).SlideDirection = FlowDirection.RightToLeft;
            this.Transition.Content = _uiList[1];
        }
	}
}