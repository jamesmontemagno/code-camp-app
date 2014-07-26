using CodeCamp.Models.Database;
using System;
using Xamarin.Forms;

namespace CodeCamp
{
	public class SpeakerCell : ViewCell
	{
		public SpeakerCell ()
		{
			var title = new Label {
				YAlign = TextAlignment.Center,
        Font = Font.SystemFontOfSize(NamedSize.Medium)
			};
			title.SetBinding (Label.TextProperty, "Name");

			var label = new Label {
        YAlign = TextAlignment.Center,
        Font = Font.SystemFontOfSize(NamedSize.Small)
			};
      label.SetBinding(Label.TextProperty, "TwitterHandle");

			var photo = new Image {
				WidthRequest = 38, HeightRequest = 38,
			};
      photo.SetBinding(Image.SourceProperty, "HeadshotUrl");
      /*mask = new Image {
        Source = "roundmask.png",
        WidthRequest = 38, HeightRequest = 38, 
      };
      photoGrid = new Grid {
        ColumnDefinitions = { new ColumnDefinition () },
        RowDefinitions = { new RowDefinition () }
      };
      photoGrid.Children.Add (photo);
      photoGrid.Children.Add (mask);*/


      var text = new StackLayout {
				Orientation = StackOrientation.Vertical,
				Padding = new Thickness(0, 0, 0, 0),
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Children = {title, label}
			};

			View = new StackLayout {
				Padding = new Thickness(10, 0, 0, 0),
        Spacing = 10,
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.StartAndExpand,
        Children = { photo, text }
			};
		}

		/*protected override void OnBindingContextChanged ()
		{
			base.OnBindingContextChanged ();
			var speaker = (Speaker)BindingContext;

			title.Text = speaker.Name;
			label.Text = speaker.TwitterHandle;
			photo.Source = speaker.HeadshotUrl;
		}*/
	}
}

