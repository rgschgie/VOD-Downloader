using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VOD_Downloader
{
    public class SharedFunctions
    {
        public static Bitmap GetBitmapImage(string imageURL)
        {
            WebRequest request = System.Net.WebRequest.Create(imageURL);
            WebResponse response = request.GetResponse();
            System.IO.Stream responseStream = response.GetResponseStream();
            return new Bitmap(responseStream);
        }

        public static void ClearDataGridView(DataGridView dataGridViewToBeCleared)
        {
            dataGridViewToBeCleared.Rows.Clear();
            dataGridViewToBeCleared.Refresh();
        }

    }
}
