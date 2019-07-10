using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VOD_Downloader
{
    public class VODObject
    {
        public int id { get; set; }

        public int user_id { get; set; }

        public string user_name { get; set; }

        public string title { get; set; }

        public string description { get; set; }

        public DateTime created_at { get; set; }

        public DateTime published_at { get; set; }

        public string url { get; set; }

        public string thumbnail_url { get; set; }

        public string viewable { get; set; }

        public int view_count { get; set; }

        public string language { get; set; }

        public string archive { get; set; }

        public string duration { get; set; }


    }
}
