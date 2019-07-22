using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VOD_Downloader;

namespace VOD_Downloader
{
    public partial class StreamerForm : Form
    {
        UserInformation StreamerInformation;
        List<VODObject> vodList;

        public StreamerForm(UserInformation streamerInformation)
        {
            InitializeComponent();
            StreamerInformation = streamerInformation;
        }


        private async void StreamerForm_LoadAsync(object sender, EventArgs e)
        {

            pictureBox1.Load(StreamerInformation.profile_image_url);
            label1.Text = StreamerInformation.display_name;
            await FillDataGridView();
        }




        private VODMasterObject getPastStreams()
        {
            return APICalls.GetStreams(StreamerInformation.id,"archive");
        }


        private async Task FillDataGridView()
        {
            var VODMaster = getPastStreams();
            vodList = VODMaster.data;

            dataGridView1.RowTemplate.Height = 50;

            var addToDataGridView = new Progress<Tuple<string, string, Bitmap, string>>(value =>
            {
                dataGridView1.Rows.Add(value.Item1, value.Item2, value.Item3, value.Item4);
            });

            var updateGUIThread = addToDataGridView as IProgress<Tuple<string, string, Bitmap, string>>;

            await Task.Run(() =>
            {
                foreach (var vod in VODMaster.data)
                {
                    //Console.WriteLine(vod.thumbnail_url);
                    string thumbnail = vod.thumbnail_url.Replace("%{width}", "300").Replace("%{height}", "300");
                    System.Net.WebRequest request = System.Net.WebRequest.Create(thumbnail);
                    System.Net.WebResponse response = request.GetResponse();
                    System.IO.Stream responseStream = response.GetResponseStream();
                    Bitmap bitmap2 = new Bitmap(responseStream);

                    updateGUIThread.Report(new Tuple<string, string, Bitmap, string> ( "Download", vod.title, bitmap2, vod.description ));

                    //dataGridView1.Rows.Add("Download", vod.title, bitmap2, vod.description);

                }
            });


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 0)
            {
                if (vodList != null)
                {
                    DownloadStreamForm DownloadForm = new DownloadStreamForm(vodList[e.RowIndex]);
                    DownloadForm.Show();
                }
                
            }
        }


    }
}
