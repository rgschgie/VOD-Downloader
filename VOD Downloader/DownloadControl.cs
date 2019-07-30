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

namespace VOD_Downloader
{
    public partial class DownloadControl : UserControl
    {


        VODObject _selectedVOD;
        VideoQualityFormat _videoQualityFormats;
        string _fileName = "";




        public DownloadControl()
        {
            InitializeComponent();
        }



        public void SetUpDownload(VODObject selectedVOD)
        {
            _selectedVOD = selectedVOD;
            ClearForm();
            populateComboBoxWithVideoFormats();
        }

        private void populateComboBoxWithVideoFormats()
        {
           
                var updateGUIThread = new Progress<VideoQualityFormat>((value) =>
            {
                ClearForm();
                value.VideoQualityList.ForEach(x => comboBox1.Items.Add(x.format));
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

        private async Task<VideoQualityFormat> getVideoFormats(string url)
        {
            VideoQualityFormat data = null;

            var updateGUIThread = new Progress<Boolean>((value) =>
            {

                if (value)
                {
                    selectedVODPictureBox.Image = Properties.Resources.loadingIcon;
                }
                else
                {
                    try
                    {
                        selectedVODPictureBox.Load(_selectedVOD.thumbnail_url.Replace("%{width}", "300").Replace("%{height}", "300"));
                    }
                    catch (Exception e)
                    {
                        selectedVODPictureBox.Load(_selectedVOD.thumbnail_url.Replace("%{width}", "300").Replace("%{height}", "300"));
                    }
                        
                }

            });

            var updateMainForm = updateGUIThread as IProgress<Boolean>;

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
            //Only can do one json even at a time - downloads the json for video quality
                await youtubeDL1.DownloadAsync();

            
                data = JsonConvert.DeserializeObject<VideoQualityFormat>(x);
                updateMainForm.Report(false);
        
            return data;
        }






        private void DownloadVOD()
        {
            var updateProgressBar = new Progress<int>(value => {
                progressBar1.Value = (value > 100) ? 100 : value;
                if(value >= 100)
                {
                    Process.Start(System.IO.Directory.GetParent(_fileName).FullName);
                }
            });

            var updateLoadingMessage = new Progress<bool>(isPreparingToDownload =>
            {
                if (isPreparingToDownload)
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


                    string fileType = downloadQuality.extension;


                    _fileName = String.Format("{0}{1}.{2}", _selectedVOD.title, downloadQuality.format, fileType);
                    foreach (char c in System.IO.Path.GetInvalidFileNameChars())
                    {
                        _fileName = _fileName.Replace(c, '_');
                    }

                    SaveFileDialog savefileDialog = new SaveFileDialog()
                    {
                        RestoreDirectory = true,
                        InitialDirectory = KnownFolders.Downloads.Path.ToString(),
                        Filter = "All Media Files | *.wav; *.aac; *.wma; *.wmv; *.avi; *.mpg; *.mpeg; *.m1v; *.mp2; *.mp3; *.mpa; *.mpe; *.m3u; *.mp4; *.mov; *.3g2; *.3gp2; *.3gp; *.3gpp; *.m4a; *.cda; *.aif; *.aifc; *.aiff; *.mid; *.midi; *.rmi; *.mkv; *.WAV; *.AAC; *.WMA; *.WMV; *.AVI; *.MPG; *.MPEG; *.M1V; *.MP2; *.MP3; *.MPA; *.MPE; *.M3U; *.MP4; *.MOV; *.3G2; *.3GP2; *.3GP; *.3GPP; *.M4A; *.CDA; *.AIF; *.AIFC; *.AIFF; *.MID; *.MIDI; *.RMI; *.MKV",
                        Title = "Save Selected VOD",
                        FileName = _fileName
                };
                    savefileDialog.ShowDialog();

                    _fileName = savefileDialog.FileName;

                    YoutubeDL youtubeDL = new YoutubeDL()
                    {
                        VideoUrl = downloadQuality.url
                    };
                    youtubeDL.Options.PostProcessingOptions.FfmpegLocation = "C:\\ffmpeg.exe";


                    if (savefileDialog.FileName != "")
                    {
                        youtubeDL.Options.FilesystemOptions.Output = savefileDialog.FileName;
                    }
                    else
                    {
                        return;
                    }


                    Console.WriteLine(downloadQuality.size);


                    int totalSeconds = 0;



                    try
                    {
                        Task.Run(() =>
                        {

                            youtubeDL.StandardOutputEvent += (sender, output) =>
                            {
                                Console.WriteLine(output);
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
                                    updateGUIThreadDownload?.Report((int)(((double)downloadedDuration.TotalSeconds / (double)totalSeconds) * 100));
                                }
                            };

                            totalSeconds = VODDuration(_selectedVOD.duration);
                            UpdateGUIThreadLoading?.Report(true);
                            youtubeDL.Download();

                            Thread.Sleep(1000);
                            updateGUIThreadDownload?.Report(100);

                            

                            //MessageBox.Show("Done");

                        });

                       
                        
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

        private void DownloadStreamDownloadButton_Click_1(object sender, EventArgs e)
        {
            VideoQuality videoQuality = _videoQualityFormats.VideoQualityList.Find(x => x.format == comboBox1.Text);
            //downloadQueue1.addToDownloadQueue(videoQuality, _selectedVOD);
            DownloadVOD();
        }

        private void DownloadControl_Load(object sender, EventArgs e)
        {

        }

        private void ClearForm()
        {
            selectedVODPictureBox.InitialImage = null;
            TitleLabel.Text = "";
            CreatedLabel.Text = "";
            SizeLabel.Text = "";
            comboBox1.Items.Clear();
            comboBox1.Text = "";
            FileNameTextBox.Text = "";
        }

    }
}
