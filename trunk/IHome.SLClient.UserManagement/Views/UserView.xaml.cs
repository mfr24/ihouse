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
			
			// Insert code required on object creation below this point.
		}

        private void RadButton_Click(object sender, RoutedEventArgs e)
        {
            this.Transition.Content = new UserDetailView();
        }
	}
}