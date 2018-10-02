﻿

namespace ResponsabilidadesGT.Helpers
{
    using Plugin.Settings;
    using Plugin.Settings.Abstractions;
    public class Settings
    {
        static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        const string isRemembered = "IsRemembered";
        const string token = "Token";
        const string tokenType = "TokenType";
        static readonly string stringDefault = string.Empty;

        public static string IsRemembered
        {
            get
            {
                return AppSettings.GetValueOrDefault(isRemembered, stringDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(isRemembered, value);
            }
        }

        public static string Token
        {
            get
            {
                return AppSettings.GetValueOrDefault(token, stringDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(token, value);
            }
        }
        public static string TokenType
        {
            get
            {
                return AppSettings.GetValueOrDefault(tokenType, stringDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(tokenType, value);
            }
        }
    }
}