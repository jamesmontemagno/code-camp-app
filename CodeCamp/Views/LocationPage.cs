using System;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace CodeCamp
{
	public class LocationPage : ContentPage
	{
    public LocationPage()
		{
			NavigationPage.SetHasNavigationBar (this, true);

			Title = "Austin, Texas";

			/* DON'T FORGET
			 * Xamarin.QuickUIMaps.Init (); 
			 */
			var map = new Map(new MapSpan(new Position(30.26535, -97.738613), 0.05, 0.05))
			{
				MapType = MapType.Street,
			};
			map.BackgroundColor = Color.White;

			Pin pin;
			map.Pins.Add(pin = new Pin()
				{
					Label = "Code Camp", 
					Position = new Position(30.26535, -97.738613),
					Type = PinType.Place
				});

			Content = new StackLayout {
				VerticalOptions = LayoutOptions.FillAndExpand,
				Children = {
					map

				}
			};
//			Content = new AbsoluteLayout {
//				//BackgroundColor = Color.Gray,
//				Children = {
//					map
//				}
//			};
		}
	}
}

