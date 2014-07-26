﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCamp.Models
{
  public class Tweet
  {
    public Tweet()
    {
    }


    public ulong StatusID { get; set; }

    public string ScreenName { get; set; }

    public string Text { get; set; }

    public string Date { get { return CreatedAt.ToString("g"); } }
    public string RTCount { get { return CurrentUserRetweet == 0 ? string.Empty : CurrentUserRetweet + " RT"; } }

    public string Title
    {
      get
      {
        return Date + " " + ScreenName;
      }
    }


    public DateTime CreatedAt
    {
      get;
      set;
    }

    public ulong CurrentUserRetweet
    {
      get;
      set;
    }
  }
}
