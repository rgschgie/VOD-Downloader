using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VOD_Downloader
{
    public class VideoQualityFormat
    {
        [JsonProperty(PropertyName = "formats")]
        public List<VideoQuality> VideoQualityList { get; set; }
         
    }

    public class VideoQuality
    {
        [JsonProperty(PropertyName = "quality")]
        public int quality { get; set; }

        [JsonProperty(PropertyName = "tbr")]
        public double size { get; set; }

        [JsonProperty(PropertyName = "ext")]
        public string extension { get; set; }

        [JsonProperty(PropertyName = "format_id")]
        public string formatID { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string url { get; set; }

        [JsonProperty(PropertyName = "format")]
        public string format { get; set; }

    }
}
