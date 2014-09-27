using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCamp.Models
{
  public class Session
  {

    public string Abstract { get; set; }
    public object ApprovalUrl { get; set; }
    public Conference Conference { get; set; }
    public bool IsApproved { get; set; }
    public bool IsSuggestion { get; set; }
    public Presenter MainPresenter { get; set; }
    public string Name { get; set; }
    public List<Presenter> Presenters { get; set; }
    public object Room { get; set; }
    public string SessionEditUrl { get; set; }
    public int SessionId { get; set; }
    public string SessionUrl { get; set; }
    public Time Time { get; set; }
    public Track Track { get; set; }
		public string TimeDisplay
		{
			get { 
				return Time == null ? "TBA" : Time.Name;
			}
		}
  }
}
