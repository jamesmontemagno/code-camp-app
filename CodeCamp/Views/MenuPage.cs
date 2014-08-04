using CodeCamp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CodeCamp
{
	/// <summary>
	/// Required for PlatformRenderer
	/// </summary>
	public class MenuTableView : TableView 
	{
	}

	public class MenuPage : ContentPage
	{
		MasterDetailPage master;

		TableView tableView;

		public MenuPage (MasterDetailPage m)
		{
			master = m;
      BackgroundColor = App.NavTint;
			Title = "menu";
			Icon = "slideout.png";

			var section = new TableSection () {
				new MenuCell {Text = "Home", MenuOption = MenuOption.Home, Host = this},
				new MenuCell {Text = "Sessions", MenuOption = MenuOption.Sessions, Host = this},
				new MenuCell {Text = "Tracks", MenuOption = MenuOption.Tracks, Host = this},
				new MenuCell {Text = "Speakers", MenuOption = MenuOption.Speakers, Host = this},
				new MenuCell {Text = "Sponsors", MenuOption = MenuOption.Sponsors, Host = this},
				new MenuCell {Text = "Twitter", MenuOption = MenuOption.Twitter, Host = this},
				new MenuCell {Text = "Location", MenuOption = MenuOption.Location, Host = this},
				new MenuCell {Text = "About", MenuOption = MenuOption.About, Host = this},
			};

			var root = new TableRoot () {section} ;
		
      
			tableView = new MenuTableView ()
			{ 
				Root = root,
//				HeaderTemplate = new DataTemplate (typeof(MenuHeader)),
				Intent = TableIntent.Menu,
			};


			Content = new StackLayout {
				BackgroundColor = App.NavTint,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Children = {tableView}
			};
		}

		NavigationPage home, sessions, tracks, speakers, sponsors, location, about, twitter;
		public void Selected (MenuOption item) {

			switch (item) {
			case MenuOption.Home:
				if (home == null)
          home = new NavigationPage(new HomePage()) { BarBackgroundColor = App.NavTint, BarTextColor = Color.White };

        master.Detail = home;
				break;
      case MenuOption.Sessions:
				if (sessions == null)
          sessions = new NavigationPage(new SessionsPage()) { BarBackgroundColor = App.NavTint, BarTextColor = Color.White };
				
          master.Detail = sessions;
				break;
      case MenuOption.Tracks:
				if (tracks == null)
          tracks = new NavigationPage(new TracksPage()) { BarBackgroundColor = App.NavTint, BarTextColor = Color.White };
				
          master.Detail = tracks;
				break;
      case MenuOption.Speakers:
				if (speakers == null)
          speakers = new NavigationPage(new SpeakersPage()) { BarBackgroundColor = App.NavTint, BarTextColor = Color.White };
				
				master.Detail = speakers;
				break;
      case MenuOption.Sponsors:
        if (sponsors == null)
          sponsors = new NavigationPage(new SponsorsPage()) { BarBackgroundColor = App.NavTint, BarTextColor = Color.White };
        
        master.Detail = sponsors;
        break;
      case MenuOption.Twitter:
        if (twitter == null)
          twitter = new NavigationPage(new TwitterPage()) { BarBackgroundColor = App.NavTint, BarTextColor = Color.White };

        master.Detail = twitter;
        break;
			case MenuOption.Location:
         if (location == null)
           location = new NavigationPage(new LocationPage()) { BarBackgroundColor = App.NavTint, BarTextColor = Color.White };
        
        master.Detail = location;
        break;
      case MenuOption.About:
         if (about == null)
           about = new NavigationPage(new AboutPage()) { BarBackgroundColor = App.NavTint, BarTextColor = Color.White };
        
        master.Detail = about;
        break;
			};
			master.IsPresented = false;  // close the slide-out
		}
	}
}