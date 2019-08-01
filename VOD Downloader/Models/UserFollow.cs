using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VOD_Downloader
{

    public class UserFollowData
    {
        [JsonProperty(PropertyName = "total")]
        public int total { get; set; }

        [JsonProperty(PropertyName = "data")]
        public List<UserFollow> Data { get; set; }

        [JsonProperty(PropertyName = "pagination")]
        public UserFollowPagination pagination { get; set; }
    }


    public class UserFollow
    {
        [JsonProperty(PropertyName = "from_id")]
        public int from_id { get; set; }

        [JsonProperty(PropertyName = "from_name")]
        public string from_name { get; set; }

        [JsonProperty(PropertyName = "to_id")]
        public int to_id { get; set; }

        [JsonProperty(PropertyName = "to_name")]
        public string to_name { get; set; }

        [JsonProperty(PropertyName = "followed_at")]
        public DateTime followed_at { get; set; }
    }

    public class UserFollowPagination
    {
        [JsonProperty(PropertyName = "cursor")]
        public string cursor { get; set; }
    }
}
