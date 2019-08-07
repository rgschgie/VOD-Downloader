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
    public partial class StreamPickControl_Remake : UserControl
    {

        List<VODObject> _VODList;
        private UserInformation _selectedStreamer;
        private string _lastPagination;
        private string _pagination;
        private int nextCount = 0;

        public class SelectedItemEventArgs : EventArgs
        {
            public VODObject SelectedChoice { get; set; }
        }

        public event EventHandler<SelectedItemEventArgs> ItemHasBeenSelected;


        public StreamPickControl_Remake()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Loads the StreamPickControl and fills the data into the gridview
        /// </summary>
        /// <param name="selectedStreamer">UserInformation to setup the StreamPickControl UserControl</param>
        public void setupStreamPickControl(UserInformation selectedStreamer)
        {
            _selectedStreamer = selectedStreamer;
            FillPastStreamsDataGridView(GetPastStreams());
        }

        /// <summary>
        /// Fills the datagridview with the VODList
        /// </summary>
        /// <param name="VODList">List of VOD objects to fill the datagridview</param>
        private void FillPastStreamsDataGridView(VODMasterObject VODList)
        {
                //Iprogress to update GUI Thread
                var addToDataGridView = new Progress<StreamDataGridViewValues>(value =>
                {
                    if(value.IsGoodStreamObject)
                    {
                        StreamDataGridView.Rows.Add(value.ButtonText, value.StreamTitle, value.StreamImage, value.StreamDescription);
                    }
                    else
                    {
                        StreamDataGridView.Rows.Add(value.ButtonText, value.StreamTitle, value.StreamImage, value.StreamDescription);
                        NextButton.Visible = false;
                        PreviousButton.Visible = false;
                    }
                           
                });
                var updateGUIThread = addToDataGridView as IProgress<StreamDataGridViewValues>;

            string videoType = VideoTypeComboBox.Text;
            try
            {
                SharedFunctions.ClearDataGridView(StreamDataGridView);

                _VODList = VODList.data;
                _lastPagination = _pagination;
                _pagination = VODList.pagination.cursor;

                Task.Run(() =>
                {
                    if (VODList.data.Count != 0)
                    {
                        foreach (var vod in VODList.data)
                        {
                            Bitmap bitmap;
                            string thumbnail = vod.thumbnail_url.Replace("%{width}", "300").Replace("%{height}", "200");

                            if (thumbnail != "")
                            {
                                bitmap = SharedFunctions.GetBitmapImage(thumbnail);
                            }
                            else
                            {
                                bitmap = new Bitmap(Properties.Resources.replacementIcon);
                            }

                            updateGUIThread.Report(new StreamDataGridViewValues("Download", vod.title, bitmap, vod.description, true));
                        }
                    }
                    else
                    {
                        updateGUIThread.Report(new StreamDataGridViewValues("No videos", "No videos under " + videoType + ". Please click Apply to reset the list with a new Video Type or pick a new streamer.", new Bitmap(Properties.Resources.RedX), "", false));
                    }

                });
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
                updateGUIThread.Report(new StreamDataGridViewValues("No videos", "No more videos under " + videoType + ". Please click Apply to reset the list.", new Bitmap(Properties.Resources.RedX), "", false));
            }
           

        }

        /// <summary>
        /// Gets the VODMasterObject based on the streamerid in StreamPickControl and defaults to highlight VODs
        /// </summary>
        /// <returns>VODMasterObject of list of VODObjects of first 20 or less VOD highlights</returns>
        private VODMasterObject GetPastStreams()
        {
            return APICalls.GetStreams(_selectedStreamer.id, "highlight");
        }

        /// <summary>
        /// Gets the VODMasterObject based on the streamerid in StreamPickControl
        /// </summary>
        /// <param name="beforeOrAfter">Cursor for forward or backwards pagination: tells the server where to start fetching the next set of results, in a multi-page response. </param>
        /// <param name="pagination">A cursor value, to be used in a subsequent request to specify the starting point of the next set of results.</param>
        /// <param name="previousStreamType">Type of video. Valid values: "all", "upload", "archive", "highlight"</param>
        /// <returns></returns>
        private VODMasterObject GetPastStreams(string beforeOrAfter, string pagination, string previousStreamType)
        {
            return APICalls.GetStreams(_selectedStreamer.id, beforeOrAfter, pagination, previousStreamType);
        }

        /// <summary>
        /// Datagridview click event that processes the Datagridview button click by 
        /// invoking ItemHasBeenSelected event with the corresponding selectedStream object 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StreamDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && _VODList.Count != 0)
            {
                VODObject selectedStream = _VODList[e.RowIndex];

                ItemHasBeenSelected?.Invoke(this, new SelectedItemEventArgs
                { SelectedChoice = selectedStream });
            }
        }

        /// <summary>
        /// Button click event that fills the Datagridview with the next 20 or less streams items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NextButton_Click(object sender, EventArgs e)
        {
            FillPastStreamsDataGridView(GetPastStreams("&after=", _pagination, VideoTypeComboBox.Text));
            ++nextCount;
            Console.WriteLine(nextCount);
            PreviousButton.Visible = true;
        }

        /// <summary>
        /// Button click event that fills the Datagridview with the next 20 or less streams items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PreviousButton_Click(object sender, EventArgs e)
        {
            if(_pagination != null)
            {
                FillPastStreamsDataGridView(GetPastStreams("&before=", _pagination, VideoTypeComboBox.Text));
                --nextCount;
                Console.WriteLine(nextCount);
                if (nextCount < 1)
                {
                    PreviousButton.Visible = false;
                }
            }
            else
            {
                FillPastStreamsDataGridView(GetPastStreams("&before=", _lastPagination, VideoTypeComboBox.Text));
                --nextCount;
                Console.WriteLine(nextCount);
                if (nextCount < 1)
                {
                    PreviousButton.Visible = false;
                }
            }
            
        }

        /// <summary>
        /// Button click event that fills the datagridview with criteria based in the comboboxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ApplyButton_Click(object sender, EventArgs e)
        {
            if (_selectedStreamer != null)
            {
                NextButton.Visible = true;
                FillPastStreamsDataGridView(APICalls.GetStreams(_selectedStreamer.id,VideoTypeComboBox.Text,CreatedPeriodComboBox.Text,SortByComboBox.Text, int.Parse(ItemsPerPageComboBox.Text)));
            }
        }

        struct StreamDataGridViewValues
        {
            public string ButtonText;
            public string StreamTitle;
            public Bitmap StreamImage;
            public string StreamDescription;
            public bool IsGoodStreamObject;

            public StreamDataGridViewValues(string buttonText, string streamTitle, Bitmap streamImage, string streamDesciption, bool isGoodStreamObject)
            {
                ButtonText = buttonText;
                StreamTitle = streamTitle;
                StreamImage = streamImage;
                StreamDescription = streamDesciption;
                IsGoodStreamObject = isGoodStreamObject;
            }
        }

    }
}
