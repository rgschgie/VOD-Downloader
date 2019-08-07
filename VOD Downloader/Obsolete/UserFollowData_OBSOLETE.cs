using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VOD_Downloader
{
    public class UserFollowDataObsolete
    {

        [JsonProperty(PropertyName = "total")]
        public int total { get; set; }

        [JsonProperty(PropertyName = "data")]
        public List<UserFollow> Data { get; set; }

        [JsonProperty(PropertyName = "pagination")]
        public UserFollowPagination pagination { get; set; }


    }
}
