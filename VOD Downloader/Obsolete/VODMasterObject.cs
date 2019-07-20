using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VOD_Downloader
{
    public class VODMasterObjectObsolete
    {
        public List<VODObject> data { get; set; }

        [JsonProperty(PropertyName = "pagination")]
        public UserFollowPagination pagination { get; set; }
    }
}
