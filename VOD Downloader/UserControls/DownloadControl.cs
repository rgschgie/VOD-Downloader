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
using NYoutubeDL;
using Newtonsoft.Json;
using Syroot.Windows.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace VOD_Downloader
{
    public partial class DownloadControl : UserControl
    {

        VODObject _selectedVOD;
        VideoQualityFormat _videoQualityFormats;

        public DownloadControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Loads the video quality values and sets the download object
        /// </summary>
        /// <param name="selectedVOD"></param>
        public void SetUpDownload(VODObject selectedVOD)
        {
            _selectedVOD = selectedVOD;
            ClearForm();
            populateComboBoxWithVideoFormats();
        }

        /// <summary>
        /// loads the video qualities and puts them in the VideoQualityComboBox
        /// </summary>
        private void populateComboBoxWithVideoFormats()
        {
           
                var updateGUIThread = new Progress<VideoQualityFormat>((value) =>
            {
                ClearForm();
                value.VideoQualityList.ForEach(x => VideoQualityComboBox.Items.Add(x.format));
                selectedVODPictureBox.Load(_selectedVOD.thumbnail_url.Replace("%{width}", "300").Replace("%{height}", "300"));
                TitleLabel.Text = _selectedVOD.title;
                CreatedLabel.Text = _selectedVOD.created_at.ToShortTimeString();
                SizeLabel.Text = _selectedVOD.duration;
                FileNameTextBox.Text = String.Format("{0}", _selectedVOD.title);
            });

                var updateMainForm = updateGUIThread as IProgress<VideoQualityFormat>;

                if (_selectedVOD != null)
                {
                    Task.Run(() => {
                        _videoQualityFormats = getVideoFormats(_selectedVOD.url).Result;
                        updateMainForm.Report(_videoQualityFormats);
                    });                    
                }
        }

        /// <summary>
        /// Gets the download links and creates the global VideoQualityFormats object
        /// </summary>
        /// <param name="url">VOD url</param>
        /// <returns>Task that contains the VideoQualityObject for the URL</returns>
        private async Task<VideoQualityFormat> getVideoFormats(string url)
        {
            VideoQualityFormat data = null;

            var updateGUIThread = new Progress<Boolean>((value) =>
            {
                if (value)
                {
                    //loading image while video quality links loads
                    selectedVODPictureBox.Image = Properties.Resources.loadingIcon;
                }
                else
                {
                    //replace loading image with stream thumbnail
                    try
                    {
                        selectedVODPictureBox.Load(_selectedVOD.thumbnail_url.Replace("%{width}", "300").Replace("%{height}", "300"));
                    }
                    catch (Exception e)
                    {
                        selectedVODPictureBox.Load(_selectedVOD.thumbnail_url.Replace("%{width}", "300").Replace("%{height}", "300"));
                        Console.WriteLine(e.Message);
                    }           
                }
            });

            var updateMainForm = updateGUIThread as IProgress<Boolean>;

                string videoQualityRawJSON = "";


            var youtubeDL = new YoutubeDL()
                {
                    VideoUrl = url
                };
            youtubeDL.Options.VerbositySimulationOptions.DumpJson = true;

            youtubeDL.StandardOutputEvent += (sender, output) => {
                    Console.WriteLine(output);
                    videoQualityRawJSON = output;
                };
            youtubeDL.StandardErrorEvent += (sender, errorOutput) => Console.WriteLine(errorOutput);

            updateMainForm.Report(true);
            
            //downloads the json for video quality
            await youtubeDL.DownloadAsync();
            
            data = JsonConvert.DeserializeObject<VideoQualityFormat>(videoQualityRawJSON);
            updateMainForm.Report(false);
        
            return data;
        }
                  
        /// <summary>
        /// Downloads the VOD at the selected video quality using FFmpeg
        /// </summary>
        private void DownloadVOD()
        {

            string fileName = "";


            var updateProgressBar = new Progress<int>(value => {
                progressBar1.Value = (value > 100) ? 100 : value;
                if(value >= 100)
                {
                    Process.Start(System.IO.Directory.GetParent(fileName).FullName);
                }
            });

            var updateLoadingMessage = new Progress<bool>(isPreparingToDownload =>
            {
                if (isPreparingToDownload)
                {
                    LoadingPictureBox.Image = Properties.Resources.loadingIcon;
                }
                else
                {
                    LoadingPictureBox.Image = Properties.Resources.GreenCheck;
                }
            });

            var updateGUIThreadDownload = updateProgressBar as IProgress<int>;
            var UpdateGUIThreadLoading = updateLoadingMessage as IProgress<bool>;


            if (_selectedVOD != null)
            {
                if (VideoQualityComboBox.Text != string.Empty)
                {
                    PickVideoQualityLabel.Visible = false;

                    //get selected video quailty 
                    VideoQuality downloadQuality = _videoQualityFormats.VideoQualityList.Find(x => x.format == VideoQualityComboBox.Text);

                    
                    fileName = (_selectedVOD.title + downloadQuality.format + "." + downloadQuality.extension);
                    //replace all invalid filename chars with _
                    System.IO.Path.GetInvalidFileNameChars().ToList().ForEach(c => fileName = fileName.Replace(c,'_'));

                    //get filename
                    fileName = getSavedFileName(fileName);

                    YoutubeDL youtubeDL = new YoutubeDL()
                    {
                        VideoUrl = downloadQuality.url
                    };
                    youtubeDL.Options.PostProcessingOptions.FfmpegLocation = Properties.Settings.Default.MpegLocation;

                    if (fileName != "")
                    {
                        youtubeDL.Options.FilesystemOptions.Output = fileName;
                    }
                    else
                    {
                        return;
                    }


                    try
                    {
                        int totalSeconds = 0;

                        //download the VOD
                        Task.Run(() =>
                        {

                            youtubeDL.StandardOutputEvent += (sender, output) =>
                            {
                                Console.WriteLine(output);
                            };
                            youtubeDL.StandardErrorEvent += (sender, errorOutput) =>
                            {
                                Console.WriteLine(errorOutput);
                                int timeIndex = 0;

                                TimeSpan downloadedDuration = TimeSpan.Zero;

                                if (errorOutput.Contains("time="))
                                {
                                    timeIndex = errorOutput.IndexOf("time=") + 5;
                                    TimeSpan.TryParse(errorOutput.Substring(timeIndex, 8), out downloadedDuration);
                                }

                                if (timeIndex > 0)
                                {
                                    updateGUIThreadDownload.Report((int)(((double)downloadedDuration.TotalSeconds / (double)totalSeconds) * 100));
                                }
                            };

                            totalSeconds = VODDuration(_selectedVOD.duration);
                            UpdateGUIThreadLoading.Report(true);
                            youtubeDL.Download();

                            Thread.Sleep(1000);
                            updateGUIThreadDownload?.Report(100);
                            UpdateGUIThreadLoading.Report(false);
                        });

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                }
                else
                {
                    PickVideoQualityLabel.Visible = true;
                }
            }

        }

        /// <summary>
        /// Opens a SaveFileDialog to get a filename/ save path for the video
        /// </summary>
        /// <param name="fileName">VOD name</param>
        /// <returns>Filename/path to save video file</returns>
        private string getSavedFileName(string fileName)
        {
            SaveFileDialog savefileDialog = new SaveFileDialog()
            {
                RestoreDirectory = true,
                InitialDirectory = KnownFolders.Downloads.Path.ToString(),
                Filter = "All Media Files | *.wav; *.aac; *.wma; *.wmv; *.avi; *.mpg; *.mpeg; *.m1v; *.mp2; *.mp3; *.mpa; *.mpe; *.m3u; *.mp4; *.mov; *.3g2; *.3gp2; *.3gp; *.3gpp; *.m4a; *.cda; *.aif; *.aifc; *.aiff; *.mid; *.midi; *.rmi; *.mkv; *.WAV; *.AAC; *.WMA; *.WMV; *.AVI; *.MPG; *.MPEG; *.M1V; *.MP2; *.MP3; *.MPA; *.MPE; *.M3U; *.MP4; *.MOV; *.3G2; *.3GP2; *.3GP; *.3GPP; *.M4A; *.CDA; *.AIF; *.AIFC; *.AIFF; *.MID; *.MIDI; *.RMI; *.MKV",
                Title = "Save Selected VOD",
                FileName = fileName
            };
            savefileDialog.ShowDialog();

            return savefileDialog.FileName;
        }
        
        /// <summary>
        /// Gets the seconds the video has been downloaded in regards to the length of the video
        /// </summary>
        /// <param name="duration"></param>
        /// <returns>Number of seconds of video downloaded</returns>
        private int VODDuration(string duration)
        {
            string matchHour = Regex.Match(duration, "[1-9]+h").Value.ToString().Replace("h","");
            string matchMinute = Regex.Match(duration, "[1-9]+m").Value.ToString().Replace("m", "");
            string matchSecond = Regex.Match(duration, "[1-9]+s").Value.ToString().Replace("s", "");

            int hours = int.Parse(matchHour == "" ? "0" : matchHour);
            int minutes = int.Parse(matchMinute == "" ? "0" : matchMinute);
            int seconds = int.Parse(matchSecond == "" ? "0" : matchSecond);

            return ((hours * 3600) + (minutes * 60) + (seconds));
        }

        /// <summary>
        /// Button click event to kick off downloading the video
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DownloadStreamDownloadButton_Click(object sender, EventArgs e)
        {
            VideoQuality videoQuality = _videoQualityFormats.VideoQualityList.Find(x => x.format == VideoQualityComboBox.Text);
            DownloadVOD();
        }
        
        /// <summary>
        /// Clears the DownloadControl form
        /// </summary>
        private void ClearForm()
        {
            LoadingPictureBox.InitialImage = null;
            selectedVODPictureBox.InitialImage = null;
            TitleLabel.Text = "";
            CreatedLabel.Text = "";
            SizeLabel.Text = "";
            VideoQualityComboBox.Items.Clear();
            VideoQualityComboBox.Text = "";
            FileNameTextBox.Text = "";
        }

    }
}
