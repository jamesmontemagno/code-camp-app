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
    public SessionsViewModel()
    {
      Title = "Sessions";
      Sessions = new ObservableCollection<Session>();
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
        var results = await Services.GetSessionsForConferenceId(9);
        foreach(var session in results)
        {
          Sessions.Add(session);
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
