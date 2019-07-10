using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VOD_Downloader
{
    public class BaseURL
    {

        private BaseURL(string value) { Value = value;  }

        public string Value { get; set; }


        public static BaseURL PastStreamsURL{get {return new BaseURL("https://api.twitch.tv/helix/videos?");}}
        public static BaseURL FollowedStreamersURL { get { return new BaseURL("https://api.twitch.tv/helix/users/follows?"); } }
        public static BaseURL UserAccountURL { get { return new BaseURL("https://api.twitch.tv/helix/users?"); } }

        public static BaseURL UserIDParam (int userID) {{ return new BaseURL(String.Format("user_id={0}",userID)); }}

        public static BaseURL FollowFromIDParam(int userID) { { return new BaseURL(String.Format("from_id={0}", userID)); } }


    }
}
