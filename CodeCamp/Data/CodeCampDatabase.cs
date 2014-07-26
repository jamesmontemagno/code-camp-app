using System;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using CodeCamp.Models.Database;

namespace CodeCamp
{
	public class CodeCampDatabase 
	{
		static object locker = new object ();

		SQLiteConnection database;

		/// <summary>
		/// Initializes a new instance of the <see cref="Tasky.DL.TaskDatabase"/> TaskDatabase. 
		/// if the database doesn't exist, it will create the database and all the tables.
		/// </summary>
		/// <param name='path'>
		/// Path.
		/// </param>
		public CodeCampDatabase(SQLiteConnection conn)
		{
			database = conn;
			// create the tables
			database.CreateTable<Speaker>();
			database.CreateTable<Session>();
			database.CreateTable<SessionSpeaker>();
			database.CreateTable<Favorite>();
			database.CreateTable<Conference>();
			database.CreateTable<MasterConference>();
			database.CreateTable<State>();
			database.CreateTable<Location> ();
		}

		public IList<Speaker> GetSpeakers ()
		{
			lock (locker) {
				var speakers = database.Query<Speaker>("SELECT * FROM [Speaker] ORDER BY [Name]");
				return speakers.ToList();
			}
		}

		public IList<Session> GetSessions ()
		{
			lock (locker) {
				var sessions = database.Query<Session>("SELECT * FROM [Session] ORDER BY [Name]");
				return sessions.ToList();
			}
		}

		public IList<Location> GetLocations ()
		{
			lock (locker) {
				var locations = database.Query<Location>("SELECT * FROM [Location]");
				return locations.ToList();
			}
		}

		public IList<State> GetStates ()
		{
			lock (locker) {
				var states = database.Query<State>("SELECT * FROM [State] ORDER BY [Name]");
				return states.ToList();
			}
		}

		public IList<MasterConference> GetMasterConferences ()
		{
			lock (locker) {
				var masterConferences = database.Query<MasterConference>("SELECT * FROM [MasterConference] ORDER BY [Name]");
				return masterConferences.ToList();
			}
		}

		public IList<Conference> GetConferencesByMasterConferenceId (int masterConferenceId)
		{
			lock (locker) {
				var conferences = database.Query<Conference>("SELECT * FROM [Conference] " + masterConferenceId + " ORDER BY [DateStart] DESC");
				return conferences.ToList();
			}
		}

	}
}