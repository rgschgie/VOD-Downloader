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
using System.Net.Http;
using System.Net;

namespace VOD_Downloader
{
    public partial class StreamerPickControl : UserControl
    {

        public class SelectedItemEventArgs : EventArgs
        {
            public UserInformation SelectedChoice { get; set; }
        }

        public event EventHandler<SelectedItemEventArgs> ItemHasBeenSelected;


        [Description("Selected Streamer information"), Category("Data")]
        public UserInformation SelectedStreamer
        {
            get { return SelectedStreamer; }
        }


        private int _userID;
        private List<UserInformation> _followedStreamerInformation;
        private UserInformation _selectedStreamer;
        Stack<string> _paginationStack = new Stack<string>();
        

        public StreamerPickControl()
        {
            InitializeComponent();
        }


        public void setupStreamerPickControl(int userID)
        {
            _userID = userID;

            loadTabFollowedStreamers(APICalls.GetFollowedStreamers(_userID));
        }


        private void loadTabFollowedStreamers(UserFollowData followedStreamerObject)
        {

            //get followed streamers object

            _paginationStack.Push(followedStreamerObject.pagination.cursor);

            string streamerLoginNames = "";
            //Create first 20 followed URL Query
            followedStreamerObject.Data.ForEach(streamerFollowed => streamerLoginNames = streamerLoginNames + streamerFollowed.to_id + "&id=");
            //Cleaning up last "&login="
            streamerLoginNames = streamerLoginNames.Substring(0, streamerLoginNames.Length - 3);

            UserDataInformation followedStreamersList = APICalls.GetStreamerInformation(streamerLoginNames);
            _followedStreamerInformation = followedStreamersList.User;

            var addToDataGridView = new Progress<Tuple<string, Bitmap, string>>(value =>
            {
                dataGridView1.Rows.Add(value.Item1, value.Item2, value.Item3);
            });

            var updateGUIThread = addToDataGridView as IProgress<Tuple<string, Bitmap, string>>;

            dataGridView1.RowTemplate.MinimumHeight = 90;

            Task.Run(() =>
                        {
                            followedStreamersList.User.ForEach(streamer =>
                            {

                                WebRequest request = System.Net.WebRequest.Create(streamer.profile_image_url);
                                WebResponse response = request.GetResponse();
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

        private void NextButton_Click(object sender, EventArgs e)
        {
            ClearDataGridView();
            string pagination = _paginationStack.Peek();
            loadTabFollowedStreamers(APICalls.GetFollowedStreamersNext(_userID, pagination));
            PreviousButton.Visible = true;
        }


         

        public void ClearDataGridView()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
        }

        private void PreviousButton_Click(object sender, EventArgs e)
        {


            ClearDataGridView();
            _paginationStack.Pop();
            _paginationStack.Pop();
            
            if(_paginationStack.Count == 0)
            {
                loadTabFollowedStreamers(APICalls.GetFollowedStreamers(_userID));
                PreviousButton.Visible = false;
            }
            else
            {
                string pagination = _paginationStack.Peek();
                loadTabFollowedStreamers(APICalls.GetFollowedStreamersNext(_userID, pagination));
            }
        }
    }
}
