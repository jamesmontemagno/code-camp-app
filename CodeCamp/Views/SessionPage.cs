using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using CodeCamp.Models;
using CodeCamp.ViewModels;

namespace CodeCamp
{
	public class SessionPage : ContentPage
	{
		public SessionPage (Session session)
		{
			Title = "Session";



			NavigationPage.SetHasNavigationBar (this, true);

			var title = new Label { 
				Text = "Session",
				Font = Font.SystemFontOfSize(18)
			};
			title.SetBinding (Label.TextProperty, "Session.Name");

			var time = new Label { 
				Text = "Time",
				Font = Font.SystemFontOfSize(10)
			};
			time.SetBinding (Label.TextProperty, "Session.TimeDisplay");

			var location = new Label { 
				Text = "Location",
				Font = Font.SystemFontOfSize(10)
			};
			location.SetBinding (Label.TextProperty, "Session.Room.Name");

			var @abstract = new Label { 
				Text = "Brief",
				Font = Font.SystemFontOfSize(12)
			};
			@abstract.SetBinding (Label.TextProperty, "Session.Abstract");


			var scroll = new ScrollView { 
				Orientation = ScrollOrientation.Vertical,
				Content = new StackLayout {
					VerticalOptions = LayoutOptions.StartAndExpand,
					Padding = new Thickness(20),
					Children = {
						title, 
						time,
						location,
						@abstract,
					}
				}
			};
			Content = scroll;

			BindingContext = new SessionViewModel (session);
		}
	}
}