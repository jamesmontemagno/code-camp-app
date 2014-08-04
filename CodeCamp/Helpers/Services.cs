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
            SessionsForConferenceId
        };

        #region  InternalHelpers
        internal static string BuildUrl(EndPoints endPoint)
        {
            string servicePath="";

            switch (endPoint)
            {
                case EndPoints.ActiveMasterConferences:
                    servicePath = "/Services/MasterConference.svc/GetActiveMasterConferences";
                    break;
                case EndPoints.SessionsForConferenceId:
                    servicePath = "/Session.svc/GetSessionsByConferenceId?conferenceId={0}";
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
    }
}
