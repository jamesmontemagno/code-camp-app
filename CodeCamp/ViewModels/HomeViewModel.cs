using System;
using System.Windows.Input;
using Xamarin.Forms;
using System.Threading.Tasks;
using CodeCamp.Models;
using System.Collections.ObjectModel;
using CodeCamp.Helpers;

namespace CodeCamp.ViewModels
{
	public class HomeViewModel : BaseViewModel
	{
		public ObservableCollection<MasterConference> MasterConferences { get; set; }
		public HomeViewModel ()
		{
			MasterConferences = new ObservableCollection<MasterConference> ();
		}



		private ICommand loadConferencesCommand;
		public ICommand LoadConferencesCommand
		{
			get 
			{
				return loadConferencesCommand ??
					(loadConferencesCommand = new Command(()=>ExecuteLoadConferencesCommand()));

			}
		}

		public async Task ExecuteLoadConferencesCommand()
		{
			if (IsBusy)
				return;

			IsBusy = true;

			MasterConferences.Clear();
			try
			{
				var results = await Services.GetActiveMasterConferences();
				foreach(var conference in results)
				{
					MasterConferences.Add(conference);
				}

			}
			catch (Exception ex)
			{

			}
			finally
			{
				IsBusy = false;
			}
		}
	}
}

