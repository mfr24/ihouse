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
        private bool isEditing=false;
        public BuildingView():this(new BuildingViewModel())
        {
        }
        public BuildingView(BuildingViewModel VM)
        {
            Resources.Add("BuildingViewModelDataSource", VM);
            this.InitializeComponent();
        }

        private void radGridView_RowActivated(object sender, Telerik.Windows.Controls.GridView.RowEventArgs e)
        {
            {
            if (!isEditing) 
                SbEdit.Begin();
            
            else
            SbEditR.Begin();
            }
            isEditing = !isEditing;
        }
    }
}