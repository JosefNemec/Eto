using swc = System.Windows.Controls;
using sw = System.Windows;
using Eto.Forms;
using System;

namespace Eto.Wpf.Forms.Menu
{
	public class ContextMenuHandler : WidgetHandler<swc.ContextMenu, ContextMenu, ContextMenu.ICallback>, ContextMenu.IHandler
	{
		public ContextMenuHandler ()
		{
			Control = new swc.ContextMenu ();
            Control.Opened += Control_Opened;
		}

        void Control_Opened(object sender, sw.RoutedEventArgs e)
        {
            Callback.OnMenuOpening(Widget, EventArgs.Empty);
        }

		public void AddMenu (int index, MenuItem item)
		{
			Control.Items.Insert (index, item.ControlObject);
		}

		public void RemoveMenu (MenuItem item)
		{
			Control.Items.Remove (item.ControlObject);
		}

		public void Clear ()
		{
			Control.Items.Clear ();
		}

		public void Show (Control relativeTo)
		{
			Control.Placement = swc.Primitives.PlacementMode.MousePoint;
			if (relativeTo != null) {
				Control.PlacementTarget = relativeTo.ControlObject as sw.UIElement;
			}
			Control.IsOpen = true;
            WpfFrameworkElementHelper.ShouldCaptureMouse = false;
		}
	}
}
