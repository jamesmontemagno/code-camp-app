using System;
using CodeCamp.Models;
using System.Windows.Input;
using Xamarin.Forms;
using System.Threading.Tasks;
using CodeCamp.Helpers;

namespace CodeCamp.ViewModels
{
	public class SessionViewModel: BaseViewModel
	{
		public Session Session { get; set;}
		private int sessionId;
		public SessionViewModel (Session session)
		{
			Session = session;
			sessionId = session.SessionId;
			IsInitialized = true;
		}

		public SessionViewModel(int sessionid)
		{
			this.sessionId = sessionId;
		}


		private ICommand loadSessionCommand;
		public ICommand LoadSessionCommand
		{
			get 
			{
				return loadSessionCommand ??
					(loadSessionCommand = new Command(()=>ExecuteLoadSessionCommand()));

			}
		}

		public async Task ExecuteLoadSessionCommand()
		{
			if (IsBusy)
				return;

			IsBusy = true;


			try
			{
				Session = await Services.GetSessionForSessionId(sessionId);
				OnPropertyChanged("Session");

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

