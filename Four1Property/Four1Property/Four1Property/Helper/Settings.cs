using System;
using System.Collections.Generic;
using System.Text;

namespace Four1Property.Helper
{
    public class Settings
    {
        private static Plugin.Settings.Abstractions.ISettings AppSettings { get { return Plugin.Settings.CrossSettings.Current; } }

        #region Setting Constants

        private const string SettingsKey = "settings_key";
        private static readonly string SettingsDefault = string.Empty;

        #endregion

        #region Properties
        public static string GeneralSettings
        {
            get { return AppSettings.GetValueOrDefault(SettingsKey, SettingsDefault); }
            set { AppSettings.AddOrUpdateValue(SettingsKey, value); }
        }
        public static bool Logedin
        {
            get { return AppSettings.GetValueOrDefault("Logedin_Key", true); }
            set { AppSettings.AddOrUpdateValue("Logedin_Key", value); }
        }
        public static string Language
        {
            get { return AppSettings.GetValueOrDefault("Language_Key", "en"); }
            set { AppSettings.AddOrUpdateValue("Language_Key", value); }
        }
        public static long CustomerId
        {
            get { return AppSettings.GetValueOrDefault("CustomerId_Key", long.MinValue); }
            set { AppSettings.AddOrUpdateValue("CustomerId_Key", value); }
        }
        public static string DeviceToken
        {
            get { return AppSettings.GetValueOrDefault("DeviceToken_Key", string.Empty); }
            set { AppSettings.AddOrUpdateValue("DeviceToken_Key", value); }
        }
        #endregion
    }
}
