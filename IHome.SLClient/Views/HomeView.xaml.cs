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

            //这个地方不是很好,暂时不知道怎么把这个放到XAML里实现
            
                ((LoginView)ITurnLogin_Reg.Face).CloseButton.Click += (o, arg) => { this.Visibility = Visibility.Collapsed; };
                ((LoginView)ITurnLogin_Reg.Face).Button_TurnReg.Click += (o, arg) => { ITurnLogin_Reg.Turn(); };
                ((RegisterView)ITurnLogin_Reg.Back).CloseButton.Click += (o, arg) => { this.Visibility = Visibility.Collapsed; };
                ((RegisterView)ITurnLogin_Reg.Back).Button_TurnLogin.Click += (o, arg) => { ITurnLogin_Reg.Turn(); };
         
		}
        
	}
}