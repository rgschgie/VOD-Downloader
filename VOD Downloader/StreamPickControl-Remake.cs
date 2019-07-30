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
        private VODObject _selectedStream;
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

        private void StreamPickControl_Remake_Load(object sender, EventArgs e)
        {

        }


        public void setupStreamPickControl(UserInformation selectedStreamer)
        {
            _selectedStreamer = selectedStreamer;
            ClearDataGridView();
            FillPastStreamsDataGridView(GetPastStreams());

        }

        private void FillPastStreamsDataGridView(VODMasterObject VODList)
        {
            dataGridView2.Rows.Clear();

            _VODList = VODList.data;
            _pagination = VODList.pagination.cursor;

            dataGridView2.RowTemplate.Height = 50;

            var addToDataGridView = new Progress<Tuple<string, string, Bitmap, string>>(value =>
            {
                dataGridView2.Rows.Add(value.Item1, value.Item2, value.Item3, value.Item4);
            });

            var updateGUIThread = addToDataGridView as IProgress<Tuple<string, string, Bitmap, string>>;

            Task.Run(() =>
            {

                foreach (var vod in VODList.data)
                {
                    Bitmap bitmap2;
                    string thumbnail = vod.thumbnail_url.Replace("%{width}", "300").Replace("%{height}", "300");
                    if (thumbnail != "")
                    {
                        System.Net.WebRequest request = System.Net.WebRequest.Create(thumbnail);
                        System.Net.WebResponse response = request.GetResponse();
                        System.IO.Stream responseStream = response.GetResponseStream();
                        bitmap2 = new Bitmap(responseStream);
                    }
                    else
                    {
                        bitmap2 = new Bitmap(Properties.Resources.replacementIcon);
                    }


                    updateGUIThread.Report(new Tuple<string, string, Bitmap, string>("Download", vod.title, bitmap2, vod.description));

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

        public void ClearDataGridView()
        {
            dataGridView2.Rows.Clear();
            dataGridView2.Refresh();
        }

       

        private void DataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                _selectedStream = _VODList[e.RowIndex];

                ItemHasBeenSelected?.Invoke(this, new SelectedItemEventArgs
                { SelectedChoice = _selectedStream });
            }
        }

        private void NextButton_Click_1(object sender, EventArgs e)
        {
            ClearDataGridView();
            FillPastStreamsDataGridView(GetPastStreams("&after=", _pagination, "highlight"));
            ++nextCount;
            Console.WriteLine(nextCount);
            PreviousButton.Visible = true;

        }

        private void PreviousButton_Click_1(object sender, EventArgs e)
        {
            ClearDataGridView();
            FillPastStreamsDataGridView(GetPastStreams("&before=", _pagination, "highlight"));
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
    }
}
