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
            _uiList.Add(new UserListView());
            _uiList.Add(new UserDetailView());
			this.InitializeComponent();
            Transition.Content = _uiList[0];
			
			// Insert code required on object creation below this point.
		}
        private List<UIElement> _uiList = new List<UIElement>();
        private void RadButton_Click(object sender, RoutedEventArgs e)
        {
            this.Transition.Content = new UserDetailView();
        }
	}
}