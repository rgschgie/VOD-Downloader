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
    /// <summary>
    /// Functions used in more than one class/ module
    /// </summary>
    public class SharedFunctions
    {
        /// <summary>
        /// Converts a URL to an image to a bitmap
        /// </summary>
        /// <param name="imageURL">URL to an image to convert to Bitmap</param>
        /// <returns></returns>
        public static Bitmap GetBitmapImage(string imageURL)
        {
            try
            {
                WebRequest request = System.Net.WebRequest.Create(imageURL);
                WebResponse response = request.GetResponse();
                System.IO.Stream responseStream = response.GetResponseStream();
                return new Bitmap(responseStream);
            }
            catch(WebException e )
            {
                Console.WriteLine(e.Message);
                return Properties.Resources.replacementIcon;
            }
            
        }

        /// <summary>
        /// Clears the datagridview of all contents
        /// </summary>
        /// <param name="dataGridViewToBeCleared">Datagridview to be cleared of contents</param>
        public static void ClearDataGridView(DataGridView dataGridViewToBeCleared)
        {
            dataGridViewToBeCleared.Rows.Clear();
            dataGridViewToBeCleared.Refresh();
        }

    }
}
