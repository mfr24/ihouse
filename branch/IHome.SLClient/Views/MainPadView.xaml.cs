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
	/// Interaction logic for MainPadView.xaml
	/// </summary>
	public partial class MainPadView : UserControl
	{
		public MainPadView()
		{
			this.InitializeComponent();
            _uiList = new UIElement[] { Transition.Content as UIElement,new NavigationView() };
			// Insert code required on object creation below this point.
		}

        private UIElement[] _uiList;
        private string[] _btnName = {"首页","返回"};
        private int _btnStatus=0;
        private void RadButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            _btnStatus++;
            Transition.Content = _uiList[_btnStatus%2];
            HomeButton.Content = _btnName[_btnStatus%2];
        }
	}
}