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

        public void setupStreamPickControl(UserInformation selectedStreamer)
        {
            _selectedStreamer = selectedStreamer;
            FillPastStreamsDataGridView(GetPastStreams());
        }

        private void FillPastStreamsDataGridView(VODMasterObject VODList)
        {
            SharedFunctions.ClearDataGridView(StreamDataGridView);

            _VODList = VODList.data;
            _pagination = VODList.pagination.cursor;

            var addToDataGridView = new Progress<StreamDataGridViewValues>(value =>
            {
                StreamDataGridView.Rows.Add(value.ButtonText, value.StreamTitle, value.StreamImage, value.StreamDescription);
            });
            var updateGUIThread = addToDataGridView as IProgress<StreamDataGridViewValues>;

            Task.Run(() =>
            {
                if(VODList.data.Count != 0)
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

                        updateGUIThread.Report(new StreamDataGridViewValues("Download", vod.title, bitmap, vod.description));
                    }
                }
                else
                {
                    updateGUIThread.Report(new StreamDataGridViewValues("No videos", "No videos under " + VideoTypeComboBox.Text, new Bitmap(Properties.Resources.RedX), ""));
                }
               
            });

        }

        private VODMasterObject GetPastStreams()
        {
            return APICalls.GetStreams(_selectedStreamer.id, "highlight");
        }
        private VODMasterObject GetPastStreams(string beforeOrAfter, string pagination, string previousStreamType)
        {
            return APICalls.GetStreams(_selectedStreamer.id, beforeOrAfter, pagination, "highlight");
        }

        private void StreamDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && _VODList.Count != 0)
            {
                VODObject selectedStream = _VODList[e.RowIndex];

                ItemHasBeenSelected?.Invoke(this, new SelectedItemEventArgs
                { SelectedChoice = selectedStream });
            }
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            FillPastStreamsDataGridView(GetPastStreams("&after=", _pagination, VideoTypeComboBox.Text));
            ++nextCount;
            Console.WriteLine(nextCount);
            PreviousButton.Visible = true;
        }

        private void PreviousButton_Click(object sender, EventArgs e)
        {
            FillPastStreamsDataGridView(GetPastStreams("&before=", _pagination, VideoTypeComboBox.Text));
            --nextCount;
            Console.WriteLine(nextCount);
            if (nextCount < 1)
            {
                PreviousButton.Visible = false;
            }
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            if (_selectedStreamer != null)
            {
                FillPastStreamsDataGridView(APICalls.GetStreams(_selectedStreamer.id,VideoTypeComboBox.Text,CreatedPeriodComboBox.Text,SortByComboBox.Text, int.Parse(ItemsPerPageComboBox.Text)));
            }
        }

        struct StreamDataGridViewValues
        {
            public string ButtonText;
            public string StreamTitle;
            public Bitmap StreamImage;
            public string StreamDescription;

            public StreamDataGridViewValues(string buttonText, string streamTitle, Bitmap streamImage, string streamDesciption)
            {
                ButtonText = buttonText;
                StreamTitle = streamTitle;
                StreamImage = streamImage;
                StreamDescription = streamDesciption;
            }
        }

    }
}
