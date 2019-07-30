using Newtonsoft.Json;
using NYoutubeDL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
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


        public TabForm()
        {
            InitializeComponent();
        }

        private void TabForm_Load(object sender, EventArgs e)
        {
            if(!Properties.Settings.Default.isUserNameSet)
            {
                new UserNameForm().ShowDialog();
            }

            if(Properties.Settings.Default.UserName.Any())
            { 
                loadMainPageItems();
                GetSelectedStreamer();
            }
        }


        private void loadMainPageItems()
        {
            UserInformation userInformation = getUserInformation();

            _userID = userInformation.id;
            _userPictureURL = userInformation.profile_image_url;

            userPictureBox.Load(_userPictureURL);
            userIdLinkLabel.Text = Properties.Settings.Default.UserName;
        }


        private void GetSelectedStreamer()
        {
            streamerPickControl1.setupStreamerPickControl(_userID);
            streamerPickControl1.ItemHasBeenSelected += StreamerPickControl1_ItemHasBeenSelected;
        }

        private void StreamerPickControl1_ItemHasBeenSelected(object sender, StreamerPickControl.SelectedItemEventArgs e)
        {
            GetSelectedStream(e.SelectedChoice);
            Console.WriteLine(e.SelectedChoice.login);
            changeTab(TabDirection.Forward);
        }

        private UserInformation getUserInformation()
        {

            UserDataInformation userDataInformationObject = APICalls.GetStreamerInformation(Properties.Settings.Default.UserName);
            return userDataInformationObject.User[0];
        }

        public void GetSelectedStream(UserInformation selectedStreamer)
        {
            streamPickControl_Remake1.setupStreamPickControl(selectedStreamer);
            streamPickControl_Remake1.ItemHasBeenSelected += StreamPickControl_Remake1_ItemHasBeenSelected;
        }

        private void StreamPickControl_Remake1_ItemHasBeenSelected(object sender, StreamPickControl_Remake.SelectedItemEventArgs e)
        {
            Console.WriteLine(e.SelectedChoice.title);
            changeTab(TabDirection.Forward);
            GenerateDownloadVODControl(e.SelectedChoice);
        }
        
        public void GenerateDownloadVODControl(VODObject selectedVOD)
        {
            downloadControl1.SetUpDownload(selectedVOD);
        }

        private void TabBackButton_Click(object sender, EventArgs e)
        {
            changeTab(TabDirection.Back);
        }

        private void changeTab(TabDirection tabDirection)
        {
            switch (tabDirection)
            {
                case TabDirection.Forward:

                    switch (tabControl1.SelectedIndex)
                    {
                        case 0:
                            TabBackButton.Text = "Back to Followed Streamers";
                            TabForwardButton.Text = "Forward to Download Stream";
                            TabBackButton.Enabled = true;
                            tabControl1.SelectedIndex = 1;
                            break;
                        case 1:
                            TabBackButton.Text = "Back to Past Streams";
                            TabForwardButton.Text = "Cannot go forward";
                            tabControl1.SelectedIndex = 2;
                            TabForwardButton.Enabled = false;
                            break;
                        case 2:
                            break;
                    }    
                    break;


                case TabDirection.Back:

                    switch (tabControl1.SelectedIndex)
                    {
                        case 0:

                            break;
                        case 1:
                            TabBackButton.Text = "Cannot go back";
                            TabForwardButton.Text = "Forward to Past Streams";
                            TabBackButton.Enabled = false;
                            tabControl1.SelectedIndex = 0;
                            break;
                        case 2:
                            TabBackButton.Text = "Back to Followed Streamers";
                            TabForwardButton.Text = "Forward to Download Stream";
                            TabForwardButton.Enabled = true;
                            tabControl1.SelectedIndex = 1;
                            break;
                    }


                    break;

                default:
                        break;
            }

        }

        private void TabForwardButton_Click(object sender, EventArgs e)
        {
            changeTab(TabDirection.Forward);
        }

        private void ResetLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Properties.Settings.Default.Reset();
            new UserNameForm().ShowDialog();
            if (Properties.Settings.Default.UserName.Any())
            {
                loadMainPageItems();
                GetSelectedStreamer();
            }
        }

        private enum TabDirection
        {
            Forward,
            Back
        }

        private void UserIdLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://twitch.tv/" + userIdLinkLabel.Text);
        }
    }

    
}
