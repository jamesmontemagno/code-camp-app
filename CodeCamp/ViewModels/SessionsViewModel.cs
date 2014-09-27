using CodeCamp.Helpers;
using CodeCamp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CodeCamp.ViewModels
{
  public class SessionsViewModel : BaseViewModel
  {
    public ObservableCollection<Session> Sessions { get; set; }
		public ObservableCollection<Grouping<string, Session>>SessionsGrouped { get; set; }
    public SessionsViewModel()
    {
      Title = "Sessions";
      Sessions = new ObservableCollection<Session>();
			SessionsGrouped = new ObservableCollection<Grouping<string, Session>> ();
    }

    private ICommand loadSessionsCommand;
    public ICommand LoadSessionsCommand
    {
      get 
      {
        return loadSessionsCommand ??
          (loadSessionsCommand = new Command(()=>ExecuteLoadSessionsCommand()));
            
      }
    }

    private async Task ExecuteLoadSessionsCommand()
    {
      if (IsBusy)
        return;

      IsBusy = true;

      Sessions.Clear();
      try
      {
				var results = await Services.GetSessionsForConferenceId(Settings.Conference);
				foreach(var session in results.Where(s => s.IsApproved))
        {
          Sessions.Add(session);
        }


				//Use linq to sorty our monkeys by name and then group them by the new name sort property
				var sorted = from session in Sessions
					orderby session.Name
					group session by session.TimeDisplay into sessionGroup
					select new Grouping<string, Session>(sessionGroup.Key, sessionGroup);

				SessionsGrouped.Clear();
				//create a new collection of groups
				foreach(var sort in sorted)
					SessionsGrouped.Add(sort);
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
