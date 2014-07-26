using System;

namespace CodeCamp.Models.Database
{
	public class Favorite
	{
		public Favorite ()
		{
		}

		public int SessionId { get; set; }
		public bool IsFavorite { get; set; }
	}
}

