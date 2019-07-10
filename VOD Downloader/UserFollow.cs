using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VOD_Downloader
{
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
}
