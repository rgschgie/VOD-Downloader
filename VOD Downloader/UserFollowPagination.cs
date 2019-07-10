using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VOD_Downloader
{
    public class UserFollowPagination
    {
         
        [JsonProperty(PropertyName = "cursor")]
        public string cursor { get; set; }
    
    }
}
