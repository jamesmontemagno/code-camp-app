using CodeCamp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCamp.Views
{
  public partial class TwitterPage
  {
    TwitterViewModel viewModel;
    public TwitterPage()
    {
      InitializeComponent();
      this.BindingContext = viewModel = new TwitterViewModel();
    }

    protected override void OnAppearing()
    {
      base.OnAppearing();
      if (viewModel.IsInitialized)
        return;

      viewModel.IsInitialized = true;
      viewModel.LoadTweetsCommand.Execute(null);

    }
  }
}
