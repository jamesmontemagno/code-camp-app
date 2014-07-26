using CodeCamp.Models;
using LinqToTwitter;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CodeCamp.ViewModels
{
  public class TwitterViewModel : BaseViewModel
  {

    public ObservableCollection<Tweet> Tweets { get; set; }

    public TwitterViewModel()
    {
      Title = "Twitter";
      Icon = "slideout.png";
      Tweets = new ObservableCollection<Tweet>();

    }

    private Command loadTweetsCommand;

    public Command LoadTweetsCommand
    {
      get { return loadTweetsCommand ?? (loadTweetsCommand = new Command(ExecuteLoadTweetsCommand)); }
    }

    private async void ExecuteLoadTweetsCommand()
    {
      if (IsBusy)
        return;

      IsBusy = true;
      try
      {

        Tweets.Clear();
        var auth = new ApplicationOnlyAuthorizer()
        {
          CredentialStore = new InMemoryCredentialStore
          {
            ConsumerKey = "ZTmEODUCChOhLXO4lnUCEbH2I",
            ConsumerSecret = "Y8z2Wouc5ckFb1a0wjUDT9KAI6DUat5tFNdmIkPLl8T4Nyaa2J",
          },
        };
        await auth.AuthorizeAsync();

        var twitterContext = new TwitterContext(auth);

        var searchResponse =
                await (from search in twitterContext.Search
                 where search.Type == SearchType.Search &&
                       search.Count == 100 &&
                       search.Query == "\"#dcc14\""
                 select search)
                .SingleOrDefaultAsync();

        if (searchResponse != null && searchResponse.Statuses != null)
        {
          var tweets =
            (from tweet in searchResponse.Statuses
             select new Tweet
             {
               StatusID = tweet.StatusID,
               ScreenName = tweet.User.ScreenNameResponse,
               Text = tweet.Text,
               CurrentUserRetweet = tweet.CurrentUserRetweet,
               CreatedAt = tweet.CreatedAt
             }).ToList();


          foreach (var tweet in tweets)
          {
            Tweets.Add(tweet);
          }
        }


       
      }
      catch (Exception ex)
      {
        var page = new ContentPage();
        page.DisplayAlert("Error", "Unable to load twitter.", "OK", null);
      }

      IsBusy = false;
    }
  }
}
