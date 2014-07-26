using CodeCamp.Views;
using System;
using Xamarin.Forms;

namespace CodeCamp
{
	public static class App
	{
		public static Page GetMainPage ()
		{
			var md = new MasterDetailPage ();

			md.Master = new MenuPage (md);
			md.Detail = new NavigationPage(new HomePage ()) {BarBackgroundColor = App.NavTint, BarTextColor = Color.White};

			return md;
		}

		static SQLite.SQLiteConnection conn;
		static CodeCampDatabase database;
		public static void SetDatabaseConnection (SQLite.SQLiteConnection connection)
		{
			conn = connection;
			database = new CodeCampDatabase (conn);
		}
		public static CodeCampDatabase Database {
			get { return database; }
		}


		public static Color NavTint {
			get {
        return Color.FromHex("DD4819"); 
			}
		}
		public static Color HeaderTint {
			get {
        return Color.FromHex("DD4819"); 
			}
		}
	}
}

