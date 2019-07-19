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



        public void SetUpDownload(VODObject selectedVOD)
        {
            _selectedVOD = selectedVOD;

          
                populateComboBoxWithVideoFormats();
            
            
        }






        private  void populateComboBoxWithVideoFormats()
        {
           
                var updateGUIThread = new Progress<VideoQualityFormat>((value) =>
            {

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
                    selectedVODPictureBox.Load(_selectedVOD.thumbnail_url.Replace("%{width}", "300").Replace("%{height}", "300"));
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
            var updateProgressBar = new Progress<int>(value => { progressBar1.Value = (value > 100) ? 100 : value; });

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
                        Task.Run(() =>
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
                                    updateGUIThreadDownload?.Report((int)(((double)downloadedDuration.TotalSeconds / (double)totalSeconds) * 100));
                                }
                            };

                            totalSeconds = VODDuration(_selectedVOD.duration);
                            UpdateGUIThreadLoading?.Report(true);
                            youtubeDL.Download();

                            Thread.Sleep(1000);
                            updateGUIThreadDownload?.Report(100);

                            MessageBox.Show("Done");
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
    }
}
