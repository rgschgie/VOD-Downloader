using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace VOD_Downloader
{
    public partial class StreamerPickControl : UserControl
    {
        //public UserInformation SelectedStreamer;


        public class SelectedItemEventArgs : EventArgs
            {
                public UserInformation SelectedChoice { get; set; }
            }

        public event EventHandler <SelectedItemEventArgs> ItemHasBeenSelected;





        [Description("Selected Streamer information"), Category("Data")]
        public UserInformation SelectedStreamer
        {
            get { return SelectedStreamer; }
        }







        private int _userID;
        private List<UserInformation> _followedStreamerInformation;
        private UserInformation _selectedStreamer;

        public event EventHandler PropertyChanged;

        public StreamerPickControl()
        {
            InitializeComponent();
        }


        public void setupStreamerPickControl(int userID)
        {
            _userID = userID;
            loadTabFollowedStreamers();
        }


        private void loadTabFollowedStreamers()
        {

            //get followed streamers object
            UserFollowData followedStreamerObject = APICalls.GetFollowedStreamers(_userID);

            string streamerLoginNames = "";
            //Create first 20 followed URL Query
            followedStreamerObject.Data.ForEach(streamerFollowed => streamerLoginNames = streamerLoginNames + streamerFollowed.to_name + "&login=");
            //Cleaning up last "&login="
            streamerLoginNames = streamerLoginNames.Substring(0, streamerLoginNames.Length - 7);

            UserDataInformation followedStreamersList = APICalls.GetStreamerInformation(streamerLoginNames);
            _followedStreamerInformation = followedStreamersList.User;

            var addToDataGridView = new Progress<Tuple<string, Bitmap, string>>(value =>
            {
                dataGridView1.Rows.Add(value.Item1, value.Item2, value.Item3);
            });

            var updateGUIThread = addToDataGridView as IProgress<Tuple<string, Bitmap, string>>;
            Task.Run(() =>
            {
                dataGridView1.RowTemplate.MinimumHeight = 90;
                followedStreamersList.User.ForEach(streamer =>
                {
                    //Thread.Sleep(1000);
                    System.Net.WebRequest request = System.Net.WebRequest.Create(streamer.profile_image_url);
                    System.Net.WebResponse response = request.GetResponse();
                    System.IO.Stream responseStream = response.GetResponseStream();
                    Bitmap bitmap2 = new Bitmap(responseStream);
                    updateGUIThread.Report(new Tuple<string, Bitmap, string>("Select", bitmap2, streamer.login));
                });
            });
        }



        private void DataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                _selectedStreamer = _followedStreamerInformation[e.RowIndex];

                ItemHasBeenSelected?.Invoke(this, new SelectedItemEventArgs
                { SelectedChoice = _selectedStreamer });
            }
        }

    }
}
