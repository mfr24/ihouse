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
    /// Interaction logic for DictionaryView.xaml
    /// </summary>
    public partial class DictionaryView : UserControl
    {
        public DictionaryView()
        {
            this.InitializeComponent();

            // Insert code required on object creation below this point.
        }


        private void RadContextMenu_Opened(object sender, RoutedEventArgs e)
        {
            Telerik.Windows.Controls.RadTreeViewItem treeViewItem =
((Telerik.Windows.Controls.RadContextMenu)sender).GetClickedElement<Telerik.Windows.Controls.RadTreeViewItem>();
            if (treeViewItem == null)
            {
                (sender as Telerik.Windows.Controls.RadContextMenu).IsOpen = false;
                return;
            }
            tree.SelectedItem = treeViewItem.Item;
        }

        private void RadMenuItemEdit_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
           tree.SelectedContainer.BeginEdit();
        }

    }
}