using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCamp.Models
{
  public class Conference
  {
    public int ConferenceId { get; set; }
    public string ConferenceTitle { get; set; }
    public string ConferenceUrl { get; set; }
    public DateTime DateEnd { get; set; }
    public DateTime DateStart { get; set; }
    public string Domain { get; set; }
    public string HashTag { get; set; }
    public Location Location { get; set; }
    public int MasterConferenceId { get; set; }
    public string Name { get; set; }
    public string NextConferenceText { get; set; }
    public State State { get; set; }
    public string Subdomain { get; set; }
  }
}
