using CodeCamp.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CodeCamp
{
	public class SpeakersPage : ContentPage
	{
		ListView listView;
		public SpeakersPage ()
		{
			Title = "Speakers";
			Icon = "slideout.png";

			NavigationPage.SetHasNavigationBar (this, true);

			listView = new ListView {
				RowHeight = 60
			};
			listView.ItemsSource = App.Database.GetSpeakers ();
//			listView.ItemTemplate = new DataTemplate (typeof (ImageCell)){
//				Bindings = {
//					{ ImageCell.TextProperty, new Binding ("Name") },
//					{ ImageCell.ImageSourceProperty, new Binding ("HeadshotUrl") }
//				}
//			};
			listView.ItemTemplate = new DataTemplate (typeof (SpeakerCell));

			listView.ItemSelected += (sender, e) => {
				var speaker = e.SelectedItem as Speaker;
				var speakerPage = new SpeakerPage();
				speakerPage.BindingContext = speaker;
				Navigation.PushAsync(speakerPage);
			};

			Content = new StackLayout {
				VerticalOptions = LayoutOptions.FillAndExpand,
				Children = {listView}
			};
		}
	}
}