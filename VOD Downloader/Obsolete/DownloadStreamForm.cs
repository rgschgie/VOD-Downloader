using Newtonsoft.Json;
using NYoutubeDL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VOD_Downloader
{
    public partial class DownloadStreamForm : Form
    {

        VODObject _VODObject;

        VideoQualityFormat _videoQualityFormats;


        public DownloadStreamForm(VODObject vodObject)
        {
            InitializeComponent();
            _VODObject = vodObject;

        }

        //private void DownloadStreamForm_Load(object sender, EventArgs e)
        //{
            
        //}



        private void testTwitchDownload()
        {
            if (_VODObject != null)
            {
                if(comboBox2.Text != string.Empty)
                {

                    VideoQuality downloadQuality = _videoQualityFormats.VideoQualityList.Find(x=> x.format == comboBox2.Text);



                    NYoutubeDL.Helpers.FileSizeRate help = new NYoutubeDL.Helpers.FileSizeRate(1.0, NYoutubeDL.Helpers.Enums.ByteUnit.M);

                    var youtubeDL = new YoutubeDL();
                    youtubeDL.VideoUrl = downloadQuality.url;
                    youtubeDL.Options.DownloadOptions.LimitRate = help;

                    string fileType = downloadQuality.extension;
                    youtubeDL.Options.PostProcessingOptions.FfmpegLocation = "C:\\ffmpeg.exe";
                    youtubeDL.Options.FilesystemOptions.Output = String.Format(@"C:\Users\rgsch\Downloads\{0}_{1}.{2}",_VODObject.title,downloadQuality.format, fileType);

                    

                    Console.WriteLine(downloadQuality.size);


                    int totalSeconds = 0;


                    try
                    {
                        
                        youtubeDL.StandardOutputEvent += (sender, output) => { Console.WriteLine(output);
                            //sw.WriteLine(output);
                        };
                        youtubeDL.StandardErrorEvent += (sender, errorOutput) => { Console.WriteLine(errorOutput);
                            int timeIndex = errorOutput.IndexOf("time=");

                            TimeSpan downloadedDuration = TimeSpan.Zero;
                            if(timeIndex != -1)
                            {
                                TimeSpan.TryParse(errorOutput.Substring(timeIndex + 5, 8), out downloadedDuration);
                            }
                            
                            if (timeIndex > 0)
                            {
                                Console.WriteLine(errorOutput.Substring(timeIndex + 5,8));
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine((double)downloadedDuration.TotalSeconds / (double)totalSeconds);
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine();
                            }
                        };

                        totalSeconds = VODDuration(_VODObject.duration);
                        youtubeDL.Download();

                        
                        

                        MessageBox.Show("Done");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                }
            }



        }

        private async Task<VideoQualityFormat> getVideoFormatsAsync(string url)
        {
            VideoQualityFormat data = null;

            var updateGUIThread = new Progress<string>((value) =>
            {

            });


            var updateMainForm = updateGUIThread as IProgress<string>;


            await Task.Run(() => {
                string x = "";

                var youtubeDL1 = new YoutubeDL();
                youtubeDL1.StandardOutputEvent += (sender, output) => {
                    Console.WriteLine(output);
                    x = output;
                };
                youtubeDL1.StandardErrorEvent += (sender, errorOutput) => Console.WriteLine(errorOutput);
                youtubeDL1.VideoUrl = _VODObject.url;
                youtubeDL1.Options.VerbositySimulationOptions.DumpJson = true;

                //Only can do one json even at a time
                youtubeDL1.Download();

                data = JsonConvert.DeserializeObject<VideoQualityFormat>(x);
            });
           

            return data;
        }

        private void Info_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            testTwitchDownload();
        }

        private async void DownloadStreamForm_Load_1Async(object sender, EventArgs e)
        {
            if (_VODObject != null)
            {

                _videoQualityFormats = await getVideoFormatsAsync(_VODObject.url);
                _videoQualityFormats.VideoQualityList.ForEach(x => comboBox2.Items.Add(x.format));

                pictureBox1.Load(_VODObject.thumbnail_url.Replace("%{width}", "300").Replace("%{height}", "300"));
                label1.Text = _VODObject.title;
                label2.Text = _VODObject.created_at.ToShortTimeString();
                label3.Text = _VODObject.duration;
                label4.Text = "";
                label5.Text = "";
                textBox1.Text = String.Format("{0}", _VODObject.title);
                Console.WriteLine(_VODObject.duration);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            label4.Text = _videoQualityFormats.VideoQualityList.Find(x => x.format == comboBox2.Text).size.ToString();
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
