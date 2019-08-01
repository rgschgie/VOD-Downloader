using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VOD_Downloader
{
    public class UserDataInformation
    {
        [JsonProperty(PropertyName = "data")]
        public List<UserInformation> User { get; set; }
    }
    public class UserInformation
    {
        [JsonProperty(PropertyName = "id")]
        public int id { get; set; }

        [JsonProperty(PropertyName = "login")]
        public string login { get; set; }

        [JsonProperty(PropertyName = "display_name")]
        public string display_name { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string type { get; set; }

        [JsonProperty(PropertyName = "broadcaster_type")]
        public string broadcaster_type { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string description { get; set; }

        [JsonProperty(PropertyName = "profile_image_url")]
        public string profile_image_url { get; set; }

        [JsonProperty(PropertyName = "offline_image_url")]
        public string offline_image_url { get; set; }

    }
}
