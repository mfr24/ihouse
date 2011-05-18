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
using Telerik.Windows.Controls.DragDrop;

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
            RadDragAndDropManager.AddDragQueryHandler(this, (sender, e) => {
                ListBoxItem listBoxItem = e.Options.Source as ListBoxItem;
                ListBox box = ItemsControl.ItemsControlFromItemContainer(listBoxItem) as ListBox;

                if (e.Options.Status == DragStatus.DragQuery && box != null)
                {
                    e.Options.Payload = box.SelectedItem;
                    ContentControl cue = new ContentControl();
                    cue.ContentTemplate = this.Resources["ApplicationDragTemplate"] as DataTemplate;
                    cue.Content = box.SelectedItem;
                    e.Options.DragCue = cue;
                    e.Options.ArrowCue = RadDragAndDropManager.GenerateArrowCue();
                }

                e.QueryResult = true;
            });
            RadDragAndDropManager.AddDragInfoHandler(this, (sender, e) => {
                ListBoxItem listBoxItem = e.Options.Source as ListBoxItem;
                ListBox box = ItemsControl.ItemsControlFromItemContainer(listBoxItem) as ListBox;
                IList<DeskIcon> itemsSource = box.ItemsSource as IList<DeskIcon>;
                DeskIcon payload = e.Options.Payload as DeskIcon;

                if (e.Options.Status == DragStatus.DragComplete)
                {
                    if (payload != null && itemsSource.Contains(payload))
                    {
                        itemsSource.Remove(payload);
                    }
                }

            });
            RadDragAndDropManager.AddDropQueryHandler(this, (sender, e) => {
                MessageBox.Show("3");
            });
            RadDragAndDropManager.AddDropInfoHandler(this, (sender, e) => {
                MessageBox.Show("4");
            });
		}
	}
}