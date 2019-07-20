using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VOD_Downloader
{
    public class UserDataInformationObsolete
    {
        [JsonProperty(PropertyName = "data")]
        public List<UserInformation> User { get; set; }
    }
}
