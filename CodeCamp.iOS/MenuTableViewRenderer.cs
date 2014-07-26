using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using MonoTouch.UIKit;

[assembly:ExportRenderer(typeof(CodeCamp.MenuTableView), typeof(CodeCamp.MenuTableViewRenderer))]
namespace CodeCamp
{
	public class MenuTableViewRenderer : TableViewRenderer 
	{

		protected override void OnElementChanged (ElementChangedEventArgs<TableView> e)
		{
			base.OnElementChanged (e);
		
			var tableView = Control as UITableView;

			tableView.SeparatorStyle = UITableViewCellSeparatorStyle.None;

      tableView.BackgroundColor = UIColor.FromRGB((float)App.NavTint.R, (float)App.NavTint.G, (float)App.NavTint.B);
		}
	}
}

