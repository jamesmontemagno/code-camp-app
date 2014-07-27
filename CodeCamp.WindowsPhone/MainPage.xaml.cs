using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using CodeCamp.WindowsPhone.Resources;
using Xamarin.Forms;
using System.IO;
using SQLite;
using Windows.Storage;

namespace CodeCamp.WindowsPhone
{
  public partial class MainPage : PhoneApplicationPage
  {
    // Constructor
    public MainPage()
    {
      InitializeComponent();

      Xamarin.FormsMaps.Init();
      Forms.Init();

      var dbLocation = "CodeCampSQLite.db3";
      dbLocation = Path.Combine(ApplicationData.Current.LocalFolder.Path, dbLocation);
      var connection = new SQLiteConnection(dbLocation);
      // Set the database connection string
      CodeCamp.App.SetDatabaseConnection(connection);

      // Set our view from the "main" layout resource
      Content = CodeCamp.App.GetMainPage().ConvertPageToUIElement(this);
      // Sample code to localize the ApplicationBar
      //BuildLocalizedApplicationBar();
    }

    // Sample code for building a localized ApplicationBar
    //private void BuildLocalizedApplicationBar()
    //{
    //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
    //    ApplicationBar = new ApplicationBar();

    //    // Create a new button and set the text value to the localized string from AppResources.
    //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
    //    appBarButton.Text = AppResources.AppBarButtonText;
    //    ApplicationBar.Buttons.Add(appBarButton);

    //    // Create a new menu item with the localized string from AppResources.
    //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
    //    ApplicationBar.MenuItems.Add(appBarMenuItem);
    //}
  }
}