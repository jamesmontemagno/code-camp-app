using System;
using Xamarin.Forms;

namespace CodeCamp
{
	public class MenuHeader : ViewCell
	{
		public MenuHeader () {

			var label = new Label () {
				Text = "Code Camp",
				TextColor = Color.White,
				Font = Font.SystemFontOfSize(20)
			};

			Height = 60;

			View = new StackLayout {
				Padding = new Thickness(20),
				BackgroundColor = App.HeaderTint,
				Children = { label }
			};
		}
	}
}