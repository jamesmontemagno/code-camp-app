using System;
using System.Collections.Generic;
using SQLite;
using Xamarin.Forms;


namespace CodeCamp.Models.Database
{
	public class Conference
	{
		public Conference ()
		{

		}

		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		public string ConferenceTitle { get; set; }
		public string ConferenceUrl { get; set; }
		public DateTime DateEnd { get; set; }
		public DateTime DateStart { get; set; }
		public string Domain { get; set; }
		public string HashTag { get; set; }
		[Ignore]
		public Location Location { get; set; }
		public int MasterConferenceId { get; set; }
		public string Name { get; set; }
		public string NextConferenceText { get; set; }
    [Ignore]
		public State State { get; set; }
		public string Subdomain { get; set; }
	}
}