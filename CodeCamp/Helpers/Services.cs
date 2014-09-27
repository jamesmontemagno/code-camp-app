using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CodeCamp.Models;
using Newtonsoft.Json;

namespace CodeCamp.Helpers
{
    /// <summary>
    /// This is the Services static class that can be used to get data from the 
    /// MyConferenceEvents.com service
    /// </summary>
    public static class Services
    {
        private const string RootUrl = "http://myconferenceevents.com/Services";

        internal enum EndPoints
        {
            ActiveMasterConferences,
            SessionsForConferenceId,
						TracksForConferenceId,
						SessionForSessionId
        };

        #region  InternalHelpers
        internal static string BuildUrl(EndPoints endPoint)
        {
            string servicePath="";

            switch (endPoint)
            {
                case EndPoints.ActiveMasterConferences:
										servicePath = "/MasterConference.svc/GetActiveMasterConferences";
                    break;
                case EndPoints.SessionsForConferenceId:
                    servicePath = "/Session.svc/GetSessionsByConferenceId?conferenceId={0}";
                    break;
								case EndPoints.TracksForConferenceId:
									servicePath = "/Track.svc/GetTracksByConferenceId?conferenceId={0}";
									break;
								case EndPoints.SessionForSessionId:
									servicePath = "/Session.svc/GetSession?sessionId={0}";
									break;
            }

            return RootUrl + servicePath;
        }

        internal static async Task<string> ExecuteCall(string url)
        {
            var client = new HttpClient();
            return await client.GetStringAsync(url);
        }
        #endregion

        /// <summary>
        /// This call returns List of master conferences that are active.
        /// 
        /// NOTE: Sample of a call to service that does not need any values.
        /// </summary>
        /// <returns>List/<MasterConference/></returns>
        public static async Task<List<MasterConference>> GetActiveMasterConferences()
        {
            var url = BuildUrl(EndPoints.ActiveMasterConferences);

            var json = await ExecuteCall(url);

            return JsonConvert.DeserializeObject<List<MasterConference>>(json);
        }

        /// <summary>
        /// This call returns List ofsessions for a master conferences.
        /// 
        /// NOTE: Sample of a call to service that does a value.
        /// </summary>
        /// <returns>List/<Session/></returns>
        public static async Task<List<Session>> GetSessionsForConferenceId(int conferenceId)
        {
            var url = string.Format(BuildUrl(EndPoints.SessionsForConferenceId), conferenceId);

            var json = await ExecuteCall(url);

            return JsonConvert.DeserializeObject<List<Session>>(json);

        }

				/// <summary>
				/// Gets the tracks for conference identifier.
				/// </summary>
				/// <returns>The tracks for conference identifier.</returns>
				/// <param name="conferenceId">Conference identifier.</param>
				public static async Task<List<Track>> GetTracksForConferenceId(int conferenceId)
				{
					var url = string.Format(BuildUrl(EndPoints.TracksForConferenceId), conferenceId);

					var json = await ExecuteCall(url);

					return JsonConvert.DeserializeObject<List<Track>>(json);

				}

				/// <summary>
				/// Gets the sessions for session identifier.
				/// </summary>
				/// <returns>The sessions for session identifier.</returns>
				/// <param name="sessionId">Session identifier.</param>
				public static async Task<Session> GetSessionForSessionId(int sessionId)
				{
					var url = string.Format(BuildUrl(EndPoints.SessionForSessionId), sessionId);

					var json = await ExecuteCall(url);

					return JsonConvert.DeserializeObject<Session>(json);

				}
    }
}
