using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace VOD_Downloader
{
    /// <summary>
    /// Enum that has the twitch API calls as their descriptions 
    /// </summary>
    public enum BaseURL
    {
        [Description("https://api.twitch.tv/helix/videos?")]
        PastStreamURL,

        [Description("https://api.twitch.tv/helix/users/follows?")]
        FollowedStreamersURL,

        [Description("https://api.twitch.tv/helix/users?")]
        UserAccountURL
    }

    public static class EnumExtensions
    {
        /// <summary>
        /// Takes an enum and returns the description of the enum
        /// </summary>
        /// <param name="value">BaseURL enum to get URL from</param>
        /// <returns>Description of the enum</returns>
        public static string ToDescriptionString(this BaseURL value)
        {
            return  
                value.GetType()
                .GetMember(value.ToString())
                .FirstOrDefault()
                ?.GetCustomAttribute<DescriptionAttribute>()
                ?.Description
                    ?? value.ToString();
        }
    }

}
