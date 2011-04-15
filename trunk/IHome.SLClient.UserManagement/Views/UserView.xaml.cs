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
            Transition.Content = _uiList[0];
			
			// Insert code required on object creation below this point.
		}
        private UIElement[] _uiList = new UIElement[] { new UserListView(), new UserDetailView()};
        private void RadButton_Click(object sender, RoutedEventArgs e)
        {
            ((Telerik.Windows.Controls.TransitionEffects.SlideAndZoomTransition)Transition.Transition).SlideDirection = FlowDirection.RightToLeft;
            this.Transition.Content = _uiList[1];
          
        }

        private void RadButton_Click_1(object sender, RoutedEventArgs e)
        {
            ((Telerik.Windows.Controls.TransitionEffects.SlideAndZoomTransition)Transition.Transition).SlideDirection = FlowDirection.LeftToRight;
            this.Transition.Content = _uiList[0];
        }
	}
}