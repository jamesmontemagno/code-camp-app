// Helpers/Settings.cs
using Refractored.Xam.Settings;
using Refractored.Xam.Settings.Abstractions;

namespace CodeCamp.Helpers
{
  /// <summary>
  /// This is the Settings static class that can be used in your Core solution or in any
  /// of your client applications. All settings are laid out the same exact way with getters
  /// and setters. 
  /// </summary>
  public static class Settings
  {
    private static ISettings AppSettings
    {
      get
      {
        return CrossSettings.Current;
      }
    }

    #region Setting Constants

    private const string UsernameKey = "username_key";
    private static readonly string UsernameDefault = string.Empty;

    private const string MasterConferenceKey = "masterconference_key";
    private static readonly int MasterConferenceDefault = -1;

    private const string ConferenceKey = "conference_key";
    private static readonly int ConferenceDefault = -1;
    #endregion

    public static string UsernameSettings
    {
      get
      {
        return AppSettings.GetValueOrDefault(UsernameKey, UsernameDefault);
      }
      set
      {
        if (AppSettings.AddOrUpdateValue(UsernameKey, value))
          AppSettings.Save();
      }
    }

    public static int MasterConference
    {
      get
      {
        return AppSettings.GetValueOrDefault(MasterConferenceKey, MasterConferenceDefault);
      }
      set
      {
        if (AppSettings.AddOrUpdateValue(MasterConferenceKey, value))
          AppSettings.Save();
      }
    }

    public static int Conference
    {
      get
      {
        return AppSettings.GetValueOrDefault(ConferenceKey, ConferenceDefault);
      }
      set
      {
        if (AppSettings.AddOrUpdateValue(ConferenceKey, value))
          AppSettings.Save();
      }
    }

  }
}