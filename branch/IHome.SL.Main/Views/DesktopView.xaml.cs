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

namespace IHome.SL.Main
{
	/// <summary>
	/// Interaction logic for DesktopView.xaml
	/// </summary>
	public partial class DesktopView : UserControl
	{
		public DesktopView()
		{
			this.InitializeComponent();
			Desk.Children.Add(new DeskIcon(){Text="测试",Url="/images/female.png"});
			// Insert code required on object creation below this point.
		}
	}
}