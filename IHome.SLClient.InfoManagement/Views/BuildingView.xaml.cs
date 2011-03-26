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
    /// Interaction logic for BuildingView.xaml
    /// </summary>
    public partial class BuildingView : UserControl
    {
        public BuildingView()
        {
            this.InitializeComponent();

            // Insert code required on object creation below this point.
        }
        public BuildingView(BuildingViewModel VM)
        {
            Resources.Add("BuildingViewModelDataSource", VM);
            this.InitializeComponent();
        }
    }
}