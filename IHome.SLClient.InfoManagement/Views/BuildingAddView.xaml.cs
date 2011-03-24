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

namespace IHome.SLClient.InfoManagement
{
	/// <summary>
	/// Interaction logic for BuildingAddView.xaml
	/// </summary>
	public partial class BuildingAddView : UserControl
	{
		public BuildingAddView()
		{
			this.InitializeComponent();
			
			// Insert code required on object creation below this point.
		}
        public BuildingAddView(BuildingViewModel VM)
        {
            Resources.Add("BuildingViewModelDataSource", VM);
            this.InitializeComponent();
        }
	}
}