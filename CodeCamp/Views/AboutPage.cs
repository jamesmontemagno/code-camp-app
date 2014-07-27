using System;
using Xamarin.Forms;

namespace CodeCamp
{
	public class AboutPage : ContentPage
	{
		public AboutPage ()
		{
			NavigationPage.SetHasNavigationBar (this, true);
			Title = "About DCC";
			// a URL is easier
			var source = new UrlWebViewSource ();
      source.Url = "http://oct2014.desertcodecamp.com/about";

			var web = new WebView {
			};
			web.Source = source;

			Content = new StackLayout {
				VerticalOptions = LayoutOptions.FillAndExpand,
				Children = {
					web,
				}
			};
		}
	}
}

