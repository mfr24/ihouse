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

            LoginView login = new LoginView();
            RegisterView reg = new RegisterView();
            ITurnGrid.SetFace(login);
            ITurnGrid.SetBack(reg);
            login.CloseButton.Click += (o, arg) => { this.Visibility = Visibility.Collapsed; };
            login.Button_TurnReg.Click += (o, arg) => { ITurnGrid.Turn(); };
            reg.CloseButton.Click += (o, arg) => { this.Visibility = Visibility.Collapsed; };
            reg.Button_TurnLogin.Click += (o, arg) => { ITurnGrid.Turn(); };
		}
	}
}