using System;
using System.Collections.Generic;
using System.Collections;
using SQLite;

namespace CodeCamp.Models.Database
{
	public class State
	{
		public State ()
		{
		}

		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		public string Description { get; set; }
		public string Name { get; set; }
		public string ShortName { get; set; }
	}
}