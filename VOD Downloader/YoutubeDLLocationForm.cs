using Syroot.Windows.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VOD_Downloader
{
    public partial class YoutubeDLLocationForm : Form
    {
        public YoutubeDLLocationForm()
        {
            InitializeComponent();
        }

        private string _fileName;

        /// <summary>
        /// Button click event that opens the website to downloaf youtube-dl
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DownloadLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://ytdl-org.github.io/youtube-dl/download.html");
        }
           
        /// <summary>
        /// Button click event that opens file dialog to pick youtube-dl.exe path
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenFileButton_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                InitialDirectory = KnownFolders.Downloads.Path.ToString(),
                Filter = "Executable Files (.exe)|*.exe|All Files (*.*)|*.*"
            };
            openFileDialog.ShowDialog();

            _fileName = openFileDialog.FileName;
            FilePathTextBox.Text = openFileDialog.FileName;
        }

        /// <summary>
        /// Button click event that saves youtube-dl.exe path to Properties.Settings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ApplyButton_Click_1(object sender, EventArgs e)
        {
            if (_fileName != null)
            {
                Properties.Settings.Default.YoutubeDLLocation = _fileName;
                Properties.Settings.Default.isYoutubeDLSet = true;
                Properties.Settings.Default.Save();
                Close();
            }
            else
            {
                MessageBox.Show("Please select the youtube-dl.exe file.");
            }
        }
    }
}
