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


        private int _userID;
        private List<UserInformation> _followedStreamerInformation;
        Stack<string> _paginationStack = new Stack<string>();
        

        public StreamerPickControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userID"></param>
        public void setupStreamerPickControl(int userID)
        {
            _userID = userID;
            LoadTabFollowedStreamers(APICalls.GetFollowedStreamers(_userID));
        }

        /// <summary>
        /// Loads the first 20 followed streamers and inserts them into datagridview
        /// </summary>
        /// <param name="followedStreamerObject">Objects to insert into the datagridview</param>
        private void LoadTabFollowedStreamers(UserFollowData followedStreamerObject)
        {
            //Iprogress to update GUI Thread
            var addToDataGridView = new Progress<StreamerDataGridViewValues>(value =>
            {
                StreamerDataGridView.Rows.Add(value.ButtonText, value.StreamerImage, value.StreamerName);
            });
            var updateGUIThread = addToDataGridView as IProgress<StreamerDataGridViewValues>;

            try
            {
                SharedFunctions.ClearDataGridView(StreamerDataGridView);
                _paginationStack.Push(followedStreamerObject.pagination.cursor);

                string streamerLoginNames = "";
                //Create followed streamer URL Query
                followedStreamerObject.Data.ForEach(streamerFollowed => streamerLoginNames = streamerLoginNames + streamerFollowed.to_id + "&id=");
                //Cleaning up last "&id="
                streamerLoginNames = streamerLoginNames.Substring(0, streamerLoginNames.Length - 3);


                UserDataInformation followedStreamersList = APICalls.GetStreamerInformation(streamerLoginNames);
                _followedStreamerInformation = followedStreamersList.User;

                Task.Run(() =>
                {
                    followedStreamersList.User.ForEach(streamer =>
                    {
                        Bitmap bitmap = SharedFunctions.GetBitmapImage(streamer.profile_image_url);
                        updateGUIThread.Report(new StreamerDataGridViewValues("Select", bitmap, streamer.login));
                    });
                });
            }
            catch(ArgumentOutOfRangeException e)
            {

                updateGUIThread.Report(new StreamerDataGridViewValues("No More Streamers",Properties.Resources.RedX,
                                                                        "Click Previous button to go back to streamers"));
                Console.WriteLine(e.Message);
            }
            catch (NullReferenceException e)
            {
                updateGUIThread.Report(new StreamerDataGridViewValues("No More Streamers", Properties.Resources.RedX,
                                                                       "Click Previous button to go back to streamers"));
                Console.WriteLine(e.Message);
            }
           
        }

        /// <summary>
        /// Datagridview click event that processes the button click in the datagridview by 
        /// invoking ItemHasBeenSelected event with the corresponding selectedStreamer object
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StreamerGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                UserInformation selectedStreamer = _followedStreamerInformation[e.RowIndex];

                ItemHasBeenSelected?.Invoke(this, new SelectedItemEventArgs
                { SelectedChoice = selectedStreamer });
            }
        }

        /// <summary>
        /// Button click event that gets the next 20 followed streamers and loads them into the datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NextButton_Click(object sender, EventArgs e)
        {
            string pagination = _paginationStack.Peek();
            LoadTabFollowedStreamers(APICalls.GetFollowedStreamersNext(_userID, pagination));
            PreviousButton.Visible = true;
        }

        /// <summary>
        /// Button click event that gets the previous 20 followed streamers and loads them into the datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PreviousButton_Click(object sender, EventArgs e)
        {
            _paginationStack.Pop();
            _paginationStack.Pop();
            
            if(_paginationStack.Count == 0)
            {
                LoadTabFollowedStreamers(APICalls.GetFollowedStreamers(_userID));
                PreviousButton.Visible = false;
            }
            else
            {
                string pagination = _paginationStack.Peek();
                LoadTabFollowedStreamers(APICalls.GetFollowedStreamersNext(_userID, pagination));
            }
        }

        /// <summary>
        /// Button click event that fills the datagridview with criteria based in the combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ApplyButton_Click(object sender, EventArgs e)
        {
            int numOfObjects = int.Parse(ItemsPerPageComboBox.Text);
            LoadTabFollowedStreamers(APICalls.GetFollowedStreamers(_userID, numOfObjects));
        }


        struct StreamerDataGridViewValues
        {
            public string ButtonText;
            public Bitmap StreamerImage;
            public string StreamerName;

            public StreamerDataGridViewValues(string buttonText, Bitmap streamerImage, string streamerName)
            {
                ButtonText = buttonText;
                StreamerImage = streamerImage;
                StreamerName = streamerName;
            }
        }


    }
}
