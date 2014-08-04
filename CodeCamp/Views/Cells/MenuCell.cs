using System;
using Xamarin.Forms;

namespace CodeCamp
{
  public enum MenuOption
  {
    Home,
    Sessions,
    Speakers,
    Sponsors,
    Twitter,
    Location,
    About,
    Tracks
  }

	public class MenuCell : ViewCell
	{
		public string Text { 
			get { return label.Text; }
			set{ label.Text = value;} 
		}

    public MenuOption MenuOption { get; set; }

		Label label;

		public MenuPage Host { get; set; }

		public MenuCell ()
		{
			label = new Label {
				YAlign = TextAlignment.Center,
				TextColor = Color.White,
        Font = Device.OnPlatform(Font.SystemFontOfSize(20),
        Font.SystemFontOfSize(20),
        Font.SystemFontOfSize(40))
			};

			var layout = new StackLayout {
				BackgroundColor = App.HeaderTint,
				Padding = new Thickness(20, 0, 0, 0),
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.StartAndExpand,
				Children = {label}
			};
			View = layout;
		}

		protected override void OnTapped ()
		{
			base.OnTapped ();

			Host.Selected (MenuOption);
		}
	}
}

