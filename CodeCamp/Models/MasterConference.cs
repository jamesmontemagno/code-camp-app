using System;

namespace CodeCamp
{
	public class MasterConference
	{

		public string AboutText { get; set; }
		public string BitlyClientId { get; set; }
		public string BitlyClientSecret { get; set; }
		public string BitlyGenericAccessToken { get; set; }
		public string BootstrapThemeFile { get; set; }
		public List<Conference> Conferences { get; set; }
		public DateTime CreatedOn { get; set; }
		public string Domain { get; set; }
		public string EmailFromAddress { get; set; }
		public string EmailFromName { get; set; }
		public string EmailTestAddress { get; set; }
		public string EmailTestFirstName { get; set; }
		public string EmailTestLastName { get; set; }
		public string FacebookAdmin { get; set; }
		public string FacebookAppId { get; set; }
		public string FacebookImage { get; set; }
		public string FacebookPageId { get; set; }
		public string FacebookSecret { get; set; }
		public string FavIconImage { get; set; }
		public string GoogleAnalyticsId { get; set; }
		public string HashTag { get; set; }
		public string HeaderBarImage { get; set; }
		public bool IsActive { get; set; }
		public int MasterConferenceId { get; set; }
		public string Name { get; set; }
		public int OwnerId { get; set; }
		public string ReCaptchaPrivateKey { get; set; }
		public string ReCaptchaPublicKey { get; set; }
		public string TwitterAccountName { get; set; }
		public string TwitterConsumerKey { get; set; }
		public string TwitterConsumerSecret { get; set; }
		public string TwitterOAuthSecret { get; set; }
		public string TwitterOAuthToken { get; set; }
		public DateTime UpdatedOn { get; set; }
		public string Url { get; set; }
	}
}