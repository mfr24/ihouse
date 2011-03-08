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

namespace IHome.SLClient
{
	/// <summary>
	/// Interaction logic for MainView.xaml
	/// </summary>
	public partial class MainView : UserControl
	{
		public MainView()
		{
			this.InitializeComponent();
			
			// Insert code required on object creation below this point.
		}
        private void RibbonApplicationMenuItem_Hover(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
        }

        private void RibbonGroup_LaunchDialog(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {

        }
	}
}