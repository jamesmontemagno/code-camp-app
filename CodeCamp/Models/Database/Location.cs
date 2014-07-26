using System;
using System.Collections.Generic;
using System.Collections;
using SQLite;

namespace CodeCamp.Models.Database
{
	public class Location
	{
		public Location ()
		{
		}

		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		public string FloorPlanUrl { get; set; }
		public string LogoUrl { get; set; }
		public string MapUrl { get; set; }
		public string Name { get; set; }
		public string Phone { get; set; }
		public string Url { get; set; }
	}
}

