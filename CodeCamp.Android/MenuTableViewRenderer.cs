using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using CodeCamp;

[assembly: ExportRenderer(typeof(CodeCamp.MenuTableView), typeof(CodeCampAndroid.MenuTableViewRenderer))]
namespace CodeCampAndroid
{
	public class MenuTableViewRenderer : TableViewRenderer 
	{
		protected override void OnElementChanged (ElementChangedEventArgs<TableView> e)
		{
			base.OnElementChanged (e);
		
			var tableView = Control as global::Android.Widget.ListView;
			tableView.DividerHeight = 0;
			tableView.SetBackgroundColor (new global::Android.Graphics.Color((int)(255 * App.NavTint.R), (int)(255 * App.NavTint.G), (int)(255 * App.NavTint.B)));
		}
	}
}

