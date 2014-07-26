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
    About
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
        Font = Font.SystemFontOfSize(20, FontAttributes.None)
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

