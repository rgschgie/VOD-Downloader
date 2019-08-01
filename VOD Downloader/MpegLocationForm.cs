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
    public partial class MpegLocationForm : Form
    {

        private string _fileName;

        public MpegLocationForm()
        {
            InitializeComponent();
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://ffmpeg.zeranoe.com/builds/");
        }

        private void OpenFileButton_Click(object sender, EventArgs e)
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

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            if(_fileName != null)
            {
                Properties.Settings.Default.MpegLocation = _fileName;
                Properties.Settings.Default.isMpegLocation = true;
                Properties.Settings.Default.Save();
                Close();
            }
            else
            {
                MessageBox.Show("Please select the FFmpeg file.");
            }

        }
    }
}
