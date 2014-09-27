using System;
using Xamarin.Forms;
using CodeCamp.ViewModels;
using System.Linq;
using CodeCamp.Helpers;

namespace CodeCamp.Views
{
	public class HomePage : ContentPage
	{
		ListView listView;
		HomeViewModel viewModel;
		Picker masterPicker, conferencePicker;
		public HomePage ()
		{
			Title = "Home";
			this.BindingContext = viewModel = new HomeViewModel();
			NavigationPage.SetHasNavigationBar (this, true);

			var refresh = new ToolbarItem
			{
				Command = viewModel.LoadConferencesCommand,
				Icon = "refresh.png",
				Name = "refresh",
				Priority = 0
			};

			ToolbarItems.Add(refresh);

			var masterText = new Label {
				Text = "Select a conference:",
				Font = Font.SystemFontOfSize(NamedSize.Medium)
			};

			masterPicker = new Picker ();

			masterPicker.SelectedIndexChanged += (sender, e) => {

				if(masterPicker.SelectedIndex == -1)
					return;

				conferencePicker.Items.Clear(); 
					
				var selected = viewModel.MasterConferences[masterPicker.SelectedIndex];
				foreach(var item in selected.Conferences)
					conferencePicker.Items.Add(item.Name);

				Settings.MasterConference = viewModel.MasterConferences[masterPicker.SelectedIndex].MasterConferenceId;

				var conference = selected.Conferences.FirstOrDefault (c => c.ConferenceId == Settings.Conference);
				if (conference != null)
					conferencePicker.SelectedIndex = selected.Conferences.IndexOf (conference);
			};

			var conferenceText = new Label {
				Text = "Select conference date:",
				Font = Font.SystemFontOfSize(NamedSize.Medium)
			};

			conferencePicker = new Picker ();
			conferencePicker.SelectedIndexChanged += (sender, e) => {
				if(conferencePicker.SelectedIndex == -1)
					return;
				Settings.Conference = viewModel.MasterConferences[masterPicker.SelectedIndex].Conferences[conferencePicker.SelectedIndex].ConferenceId;
			};

			var activityIndicator = new ActivityIndicator();
			activityIndicator.SetBinding(ActivityIndicator.IsVisibleProperty, "IsBusy");
			activityIndicator.SetBinding(ActivityIndicator.IsRunningProperty, "IsBusy");

			Content = new StackLayout {
				Spacing = 10,
				Padding = 10,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Children = {activityIndicator, masterText, masterPicker, conferenceText, conferencePicker}
			};
		}

		protected async override void OnAppearing()
		{
			base.OnAppearing();
			if (viewModel.IsInitialized)
				return;

			viewModel.IsInitialized = true;
			await viewModel.ExecuteLoadConferencesCommand();

			masterPicker.Items.Clear ();
			foreach (var item in viewModel.MasterConferences)
				masterPicker.Items.Add (item.Name);

			var master = viewModel.MasterConferences.FirstOrDefault (c => c.MasterConferenceId == Settings.MasterConference);
			if (master != null)
				masterPicker.SelectedIndex = viewModel.MasterConferences.IndexOf (master);


		}
	}
}

