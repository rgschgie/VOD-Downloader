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

namespace VOD_Downloader
{
    public partial class DownloadQueue : UserControl
    {

        private Queue<string> _downloadQueue = new Queue<string>();
        private string _videoName = "";
        private int _userID;
        private string _userPictureURL;
        private string _videoFormat;
        List<UserInformation> _followedStreamerInformation;
        private UserInformation _selectedStreamer;
        List<VODObject> _VODList;
        VODObject _selectedVOD;
        VideoQualityFormat _videoQualityFormats;





        public DownloadQueue()
        {
            InitializeComponent();
        }



        private void DownloadQueue_Load(object sender, EventArgs e)
        {

        }














        private async void DownloadVOD()
        {
            var updateProgressBar = new Progress<int>(value => { progressBar1.Value = (value > 100) ? 100 : value; });

            var updateLoadingMessage = new Progress<bool>(isPreparingToDownload =>
            {
                if (isPreparingToDownload)
                {
                    //pleaseWaitLabel.Visible = true;
                    //PreparingToLoadLabel.Visible = true;
                }
                else
                {
                    //pleaseWaitLabel.Visible = false;
                    //PreparingToLoadLabel.Visible = false;
                }
            });

            var updateGUIThreadDownload = updateProgressBar as IProgress<int>;
            var UpdateGUIThreadLoading = updateLoadingMessage as IProgress<bool>;


            if (_selectedVOD != null)
            {
                if (_videoFormat != string.Empty)
                {

                    VideoQuality downloadQuality = _videoQualityFormats.VideoQualityList.Find(x => x.format == _videoFormat);



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
                                    updateGUIThreadDownload?.Report((int)(((double)downloadedDuration.TotalSeconds / (double)totalSeconds) * 100));
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

























        private async Task startDownloadVOD()
        {
            while(_downloadQueue.Count != 0 && _videoName != string.Empty)
            {

                


            }



        }





        private async Task updateGUI()
        {
            var updateCountNum = new Progress<Tuple<int,string,double>>(value => {
                numItemsInQueueLabel.Text = value.Item1.ToString();
                listView1.Items.Add(value.Item2);
            });
            var updateGUI = updateCountNum as IProgress<Tuple<int, string, double>>;


            await Task.Run(() =>
            {
                //Thread.Sleep(1000);
                updateGUI.Report(new Tuple<int,string,double>(_downloadQueue.Count, _videoName,2.0));
            });
        }




        public async void addToDownloadQueue(string videoToAddToQueue, string videoFormat)
        {
            _downloadQueue.Enqueue(videoToAddToQueue);
            _videoName = _downloadQueue.Dequeue();
            await updateGUI();
        }


    }
}
