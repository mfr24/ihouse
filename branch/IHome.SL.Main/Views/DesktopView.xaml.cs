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
using System.Collections.ObjectModel;
using IHome.Models;

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
                }

                e.QueryResult = true;
            });
            RadDragAndDropManager.AddDragInfoHandler(this, (sender, e) =>
            {
                ListBoxItem listBoxItem = e.Options.Source as ListBoxItem;
                ListBox box = ItemsControl.ItemsControlFromItemContainer(listBoxItem) as ListBox;
                IList<AppIcon> itemsSource = box.ItemsSource as IList<AppIcon>;
                AppIcon payload = e.Options.Payload as AppIcon;

                if (e.Options.Status == DragStatus.DragComplete)
                {
                    MessageBox.Show("Drag");
                    if (payload != null && itemsSource.Contains(payload))
                    {
                        itemsSource.Remove(payload);
                    }
                }

            });
            RadDragAndDropManager.AddDropQueryHandler(this, (sender, e) =>
            {
                ItemsControl box = e.Options.Destination as ItemsControl;
                IList<AppIcon> itemsSource = box.ItemsSource as IList<AppIcon>;
                AppIcon payload = e.Options.Payload as AppIcon;

                e.QueryResult = payload != null && !itemsSource.Contains(payload);
            });
            RadDragAndDropManager.AddDropInfoHandler(this, (sender, e) =>
            {
                ItemsControl box = e.Options.Destination as ItemsControl;
                IList<AppIcon> itemsSource = box.ItemsSource as IList<AppIcon>;
                AppIcon payload = e.Options.Payload as AppIcon;

                if (e.Options.Status == DragStatus.DropPossible)
                {
                    //box.BorderBrush = listBoxDragPossible;
                }
                else
                {
                    box.BorderBrush = new SolidColorBrush(Colors.Gray);
                }

                if (e.Options.Status == DragStatus.DropComplete)
                {
                    MessageBox.Show("Drop");
                    if (!itemsSource.Contains(payload))
                    {
                        itemsSource.Add(payload);
                    }
                }

            });
		}
	}
}