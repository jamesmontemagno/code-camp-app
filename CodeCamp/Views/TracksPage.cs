using CodeCamp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CodeCamp
{
    public class TracksPage : ContentPage
    {
        ListView listView;
        //TracksViewModel viewModel;
        public TracksPage()
        {
            Title = "Tracks";
            //this.BindingContext = viewModel = new TracksViewModel();
            NavigationPage.SetHasNavigationBar(this, true);

            var refresh = new ToolbarItem
            {
                //Command = viewModel.LoadTracksCommand,
                Icon = "refresh.png",
                Name = "refresh",
                Priority = 0
            };

            ToolbarItems.Add(refresh);

            listView = new ListView
            {
                RowHeight = 40
            };
            // see the SessionCell implementation for how the variable row height is calculated
            listView.HasUnevenRows = true;

            //listView.ItemsSource = viewModel.Tracks;//App.Database.GetTracks ();
            //listView.ItemTemplate = new DataTemplate (typeof (SessionCell));

            var cell = new DataTemplate(typeof(TextCell));
            cell.SetBinding(TextCell.TextProperty, "Name");
            cell.SetBinding(TextCell.DetailProperty, "MainPresenter.DisplayName");

            listView.ItemTemplate = cell;


            listView.ItemSelected += (sender, e) =>
            {
                /*var session = e.SelectedItem as Session;
                var sessionPage = new SessionPage();
                sessionPage.BindingContext = session;
                Navigation.PushAsync(sessionPage);*/
            };

            var activityIndicator = new ActivityIndicator();
            activityIndicator.SetBinding(ActivityIndicator.IsVisibleProperty, "IsBusy");
            activityIndicator.SetBinding(ActivityIndicator.IsRunningProperty, "IsBusy");

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children = { activityIndicator, listView }
            };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //if (viewModel.IsInitialized)
            //    return;

            //viewModel.IsInitialized = true;
            //viewModel.LoadTracksCommand.Execute(null);
        }
    }
}