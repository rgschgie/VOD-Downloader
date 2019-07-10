using Newtonsoft.Json;
using NYoutubeDL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VOD_Downloader
{
    public partial class TabForm : Form
    {

        private int _userID;
        private string _userPictureURL;
        List<UserInformation> _followedStreamerInformation;
        private UserInformation _selectedStreamer;
        List<VODObject> _VODList;
        VODObject _selectedVOD;
        VideoQualityFormat _videoQualityFormats;

        public TabForm()
        {
            InitializeComponent();
        }

        private async void TabForm_Load(object sender, EventArgs e)
        {
            await loadMainPageItems();

            loadTabFollowedStreamers();
        }





        private async Task loadMainPageItems()
        {


                var userInformation = await getUserInformation();

                _userID = userInformation.id;
                _userPictureURL = userInformation.profile_image_url;

                userPictureBox.Load(_userPictureURL);
                userIdLabel.Text = "feofeo0";
                        
        }

        private async Task<UserInformation> getUserInformation()
        {

            UserDataInformation userDataInformationObject = await APICalls.GetStreamerInformation("feofeo0");
            return userDataInformationObject.User[0];
        }

        private async void loadTabFollowedStreamers()
        {

            //get followed streamers object
            var followedStreamerObject = await APICalls.GetFollowedStreamers(_userID);

            string streamerLoginNames = "";
            //Create first 20 followed URL Query
            followedStreamerObject.Data.ForEach(streamerFollowed => streamerLoginNames = streamerLoginNames + streamerFollowed.to_name + "&login=");
            //Cleaning up last "&login="
            streamerLoginNames = streamerLoginNames.Substring(0, streamerLoginNames.Length - 7);
            UserDataInformation followedStreamersList = await APICalls.GetStreamerInformation(streamerLoginNames);
            _followedStreamerInformation = followedStreamersList.User;

            var addToDataGridView = new Progress<Tuple<string, Bitmap, string>>(value =>
            {
                dataGridView1.Rows.Add(value.Item1, value.Item2, value.Item3);
            });

            var updateGUIThread = addToDataGridView as IProgress<Tuple<string, Bitmap, string>>;
            await Task.Run(() =>
            {
                dataGridView1.RowTemplate.MinimumHeight = 90;
                followedStreamersList.User.ForEach(streamer =>
                {
                    System.Net.WebRequest request = System.Net.WebRequest.Create(streamer.profile_image_url);
                    System.Net.WebResponse response = request.GetResponse();
                    System.IO.Stream responseStream = response.GetResponseStream();
                    Bitmap bitmap2 = new Bitmap(responseStream);
                    updateGUIThread.Report(new Tuple<string, Bitmap, string>("Select", bitmap2, streamer.login));
                });
            });
        }

        private async void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 0)
            {
                _selectedStreamer = _followedStreamerInformation[e.RowIndex];
                tabControl1.SelectedIndex = 1;
                //fill vod datagridview
                await FillPastStreamsDataGridView();
            }
        }

        private async Task<VODMasterObject> GetPastStreams()
        {
            return await APICalls.GetPreviousStreams(_selectedStreamer.id, "highlight");
        }

        private async Task FillPastStreamsDataGridView()
        {
            _VODList = (await GetPastStreams()).data;

            dataGridView2.RowTemplate.Height = 50;

            var addToDataGridView = new Progress<Tuple<string, string, Bitmap, string>>(value =>
            {
                dataGridView2.Rows.Add(value.Item1, value.Item2, value.Item3, value.Item4);
            });

            var updateGUIThread = addToDataGridView as IProgress<Tuple<string, string, Bitmap, string>>;

            await Task.Run(() =>
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

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                tabControl1.SelectedIndex = 2;
                _selectedVOD = _VODList[e.RowIndex];
            }

            populateComboBoxWithVideoFormats();

        }

        private async void populateComboBoxWithVideoFormats()
        {

            if (_selectedVOD != null)
            {

                _videoQualityFormats = await getVideoFormatsAsync(_selectedVOD.url);
                _videoQualityFormats.VideoQualityList.ForEach(x => comboBox1.Items.Add(x.format));

                selectedVODPictureBox.Load(_selectedVOD.thumbnail_url.Replace("%{width}", "300").Replace("%{height}", "300"));
                TitleLabel.Text = _selectedVOD.title;
                CreatedLabel.Text = _selectedVOD.created_at.ToShortTimeString();
                SizeLabel.Text = _selectedVOD.duration;
               
                FileNameTextBox.Text = String.Format("{0}", _selectedVOD.title);
                Console.WriteLine(_selectedVOD.duration);
            }
        }

        private async Task<VideoQualityFormat> getVideoFormatsAsync(string url)
        {
            VideoQualityFormat data = null;

            var updateGUIThread = new Progress<Boolean>((value) =>
            {

                if(value)
                {
                    selectedVODPictureBox.Image = Properties.Resources.loadingIcon;
                }
                else
                {
                    selectedVODPictureBox.Load(_selectedVOD.thumbnail_url.Replace("%{width}", "300").Replace("%{height}", "300"));
                }

            });

            var updateMainForm = updateGUIThread as IProgress<Boolean>;

            await Task.Run(() => {
                string x = "";

                var youtubeDL1 = new YoutubeDL();
                youtubeDL1.StandardOutputEvent += (sender, output) => {
                    Console.WriteLine(output);
                    x = output;
                };
                youtubeDL1.StandardErrorEvent += (sender, errorOutput) => Console.WriteLine(errorOutput);
                youtubeDL1.VideoUrl = _selectedVOD.url;
                youtubeDL1.Options.VerbositySimulationOptions.DumpJson = true;
                updateMainForm.Report(true);
                //Only can do one json even at a time
                youtubeDL1.Download();

                data = JsonConvert.DeserializeObject<VideoQualityFormat>(x);
                updateMainForm.Report(false);
            });


            return data;
        }

        private void DownloadStreamDownloadButton_Click(object sender, EventArgs e)
        {
            downloadQueue1.addToDownloadQueue("Hello");
            
            
            //DownloadVOD();
        }




        private async void DownloadVOD()
        {
            var updateProgressBar = new Progress<int>(value => { progressBar1.Value = (value > 100) ? 100: value; });

            var updateLoadingMessage = new Progress<bool>(isPreparingToDownload =>
            {
                if(isPreparingToDownload)
                {
                    pleaseWaitLabel.Visible = true;
                    PreparingToLoadLabel.Visible = true;
                }
                else
                {
                    pleaseWaitLabel.Visible = false;
                    PreparingToLoadLabel.Visible = false;
                }
            });

            var updateGUIThreadDownload = updateProgressBar as IProgress<int>;
            var UpdateGUIThreadLoading = updateLoadingMessage as IProgress<bool>;


            if (_selectedVOD != null)
            {
                if (comboBox1.Text != string.Empty)
                {

                    VideoQuality downloadQuality = _videoQualityFormats.VideoQualityList.Find(x => x.format == comboBox1.Text);



                    NYoutubeDL.Helpers.FileSizeRate help = new NYoutubeDL.Helpers.FileSizeRate(1.0, NYoutubeDL.Helpers.Enums.ByteUnit.M);

                    var youtubeDL = new YoutubeDL();
                    youtubeDL.VideoUrl = downloadQuality.url;
                   // youtubeDL.Options.DownloadOptions.LimitRate = help;

                    string fileType = downloadQuality.extension;
                    youtubeDL.Options.PostProcessingOptions.FfmpegLocation = "C:\\ffmpeg.exe";
                    youtubeDL.Options.FilesystemOptions.Output = String.Format(@"C:\Users\rgsch\Downloads\{0}_{1}.{2}", _selectedVOD.title, downloadQuality.format, fileType);



                    Console.WriteLine(downloadQuality.size);


                    int totalSeconds = 0;



                    try
                    {
                        await Task.Run(() =>
                        {

                            youtubeDL.StandardOutputEvent += (sender, output) =>
                            {
                                Console.WriteLine(output);
                                //sw.WriteLine(output);
                            };
                            youtubeDL.StandardErrorEvent += (sender, errorOutput) =>
                            {
                                Console.WriteLine(errorOutput);
                                int timeIndex = errorOutput.IndexOf("time=");

                                TimeSpan downloadedDuration = TimeSpan.Zero;
                                if (timeIndex != -1)
                                {
                                    TimeSpan.TryParse(errorOutput.Substring(timeIndex + 5, 8), out downloadedDuration);
                                }

                                if (timeIndex > 0)
                                {
                                    Console.WriteLine(errorOutput.Substring(timeIndex + 5, 8));
                                    Console.WriteLine();
                                    Console.WriteLine();
                                    Console.WriteLine();
                                    Console.WriteLine((double)downloadedDuration.TotalSeconds / (double)totalSeconds);
                                    Console.WriteLine();
                                    Console.WriteLine();
                                    Console.WriteLine();


                                    //((double)downloadedDuration.TotalSeconds / (double)totalSeconds) * 100))
                                    UpdateGUIThreadLoading?.Report(false);
                                    updateGUIThreadDownload?.Report((int)(((double)downloadedDuration.TotalSeconds / (double)totalSeconds)*100));
                                }
                            };

                            totalSeconds = VODDuration(_selectedVOD.duration);
                            UpdateGUIThreadLoading?.Report(true);
                            youtubeDL.Download();

                            Thread.Sleep(1000);
                            updateGUIThreadDownload?.Report(100);
                        });
                        

                        MessageBox.Show("Done");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                }
            }
           
        }






        private int VODDuration(string duration)
        {


            int hourIndex = duration.IndexOf("h"); //1
            int minuteIndex = duration.IndexOf("m"); //0
            int secondIndex = duration.IndexOf("s"); //2

            int minuteOffset = 1;
            int secondOffset = 1;
            string hours;
            string minutes;
            string seconds;


            if (hourIndex == -1)
            {
                hours = "00";
                hourIndex = 0;
                minuteOffset = 0;
            }
            else
            {
                hours = duration.Substring(0, hourIndex);
            }

            if (minuteIndex == -1)
            {
                minuteIndex = 0;
                secondOffset = 0;
                minutes = "00";
            }
            else
            {
                minutes = duration.Substring(hourIndex + minuteOffset, ((minuteIndex - hourIndex) - minuteOffset));
            }

            if (secondIndex == -1)
            {
                secondIndex = 0;
                seconds = "00";
            }
            else
            {
                if (minuteIndex == 0 && hourIndex != 0)
                {
                    minuteIndex = hourIndex;
                    secondOffset = 1;
                }
                //0          //0         //2             //0             //0
                seconds = duration.Substring(minuteIndex + secondOffset, ((secondIndex - minuteIndex) - secondOffset));
            }



            //Console.WriteLine(format: ("Hours: {0} Minutes {1} Seconds {2}"), arg0: hours, arg1: minutes, arg2: seconds);

            Console.WriteLine((int.Parse(hours) * 3600) + (int.Parse(minutes) * 60) + int.Parse(seconds));

            return ((int.Parse(hours) * 3600) + (int.Parse(minutes) * 60) + int.Parse(seconds));


        }

   
    }
}
