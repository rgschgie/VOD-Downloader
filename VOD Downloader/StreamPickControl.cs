using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VOD_Downloader
{
    public partial class StreamPickControl : UserControl
    {

        List<VODObject> _VODList;
        private UserInformation _selectedStreamer;
        private VODObject _selectedStream;





        public class SelectedItemEventArgs : EventArgs
        {
            public VODObject SelectedChoice { get; set; }
        }

        public event EventHandler<SelectedItemEventArgs> ItemHasBeenSelected;





        [Description("Selected Stream information"), Category("Data")]
        public VODObject SelectedStream
        {
            get { return SelectedStream; }
        }






        public StreamPickControl()
        {
            InitializeComponent();
        }

        public void setupStreamPickControl(UserInformation selectedStreamer)
        {
            _selectedStreamer = selectedStreamer;
            FillPastStreamsDataGridView();
        }

        private void FillPastStreamsDataGridView()
        {
            _VODList = (GetPastStreams()).data;

            dataGridView2.RowTemplate.Height = 50;

            var addToDataGridView = new Progress<Tuple<string, string, Bitmap, string>>(value =>
            {
                dataGridView2.Rows.Add(value.Item1, value.Item2, value.Item3, value.Item4);
            });

            var updateGUIThread = addToDataGridView as IProgress<Tuple<string, string, Bitmap, string>>;

            Task.Run(() =>
            {
                foreach (var vod in _VODList)
                {
                    //Console.WriteLine(vod.thumbnail_url);
                    string thumbnail = vod.thumbnail_url.Replace("%{width}", "300").Replace("%{height}", "300");
                    System.Net.WebRequest request = System.Net.WebRequest.Create(thumbnail);
                    System.Net.WebResponse response = request.GetResponse();
                    System.IO.Stream responseStream = response.GetResponseStream();
                    Bitmap bitmap2 = new Bitmap(responseStream);

                    updateGUIThread.Report(new Tuple<string, string, Bitmap, string>("Download", vod.title, bitmap2, vod.description));

                    //dataGridView1.Rows.Add("Download", vod.title, bitmap2, vod.description);

                }
            });

        }


        private VODMasterObject GetPastStreams()
        {
            return APICalls.GetPreviousStreams(_selectedStreamer.id, "highlight");
        }


        private void DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                _selectedStream = _VODList[e.RowIndex];

                ItemHasBeenSelected?.Invoke(this, new SelectedItemEventArgs
                { SelectedChoice = _selectedStream });
            }
        }
    }
}
