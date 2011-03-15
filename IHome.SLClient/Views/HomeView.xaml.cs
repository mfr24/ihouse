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
	/// Interaction logic for HomeView.xaml
	/// </summary>
	public partial class HomeView : UserControl
	{
		public HomeView()
		{
			this.InitializeComponent();
            //Login.CloseButton.Click += (o, arg) => { this.Visibility = Visibility.Collapsed; };
            //Login.Button_TurnReg.Click += (o, arg) => { ITurnGrid.Turn(); };
            //Reg.CloseButton.Click += (o, arg) => { this.Visibility = Visibility.Collapsed; };
            //Reg.Button_TurnLogin.Click += (o, arg) => { ITurnGrid.Turn(); };
		}
	}
}