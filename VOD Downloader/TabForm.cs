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


        public TabForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load event that checks if there's a username and a FFmpeg path set and kicks off setting up StreamerPickControl Usercontrol
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabForm_Load(object sender, EventArgs e)
        {
            if(!Properties.Settings.Default.isUserNameSet)
            {
                new UserNameForm().ShowDialog();
            }
            if(!Properties.Settings.Default.isMpegLocation)
            {
                new MpegLocationForm().ShowDialog();
            }

            if(Properties.Settings.Default.UserName.Any())
            { 
                loadMainPageItems();
                PickSelectedStreamer();
            }
        }

        /// <summary>
        /// Loads pictures and text and sets userID 
        /// </summary>
        private void loadMainPageItems()
        {
            UserInformation userInformation = getUserInformation();

            _userID = userInformation.id;
            string userPictureURL = userInformation.profile_image_url;

            userPictureBox.Load(userPictureURL);
            userIdLinkLabel.Text = Properties.Settings.Default.UserName;
        }

        /// <summary>
        /// Sets up streamerPickControl 
        /// </summary>
        private void PickSelectedStreamer()
        {
            streamerPickControl1.setupStreamerPickControl(_userID);
            streamerPickControl1.ItemHasBeenSelected += StreamerPickControl1_ItemHasBeenSelected;
        }

        /// <summary>
        /// Event handler for streamerPickControl item clicked to move to next tab in the tabcontrol
        /// and pass selected item through to next tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StreamerPickControl1_ItemHasBeenSelected(object sender, StreamerPickControl.SelectedItemEventArgs e)
        {
            PickSelectedStream(e.SelectedChoice);
            Console.WriteLine(e.SelectedChoice.login);
            changeTab(TabDirection.Forward);
        }

        /// <summary>
        /// Gets the UserInformation for the Username in Properties.Settings UserName
        /// </summary>
        /// <returns>UserDataObject for the username in Properties.Settings UserName</returns>
        private UserInformation getUserInformation()
        {

            UserDataInformation userDataInformationObject = APICalls.GetStreamerInformation(Properties.Settings.Default.UserName);
            return userDataInformationObject.User[0];
        }

        /// <summary>
        /// Sets up streamerPickControl 
        /// </summary>
        /// <param name="selectedStreamer">Streamer object to load past VODS</param>
        public void PickSelectedStream(UserInformation selectedStreamer)
        {
            streamPickControl_Remake1.setupStreamPickControl(selectedStreamer);
            streamPickControl_Remake1.ItemHasBeenSelected += StreamPickControl_Remake1_ItemHasBeenSelected;
        }

        /// <summary>
        /// Event handler for StreamPickControl item clicked to move to next tab in the tabcontrol 
        /// and pass selected item through to next tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StreamPickControl_Remake1_ItemHasBeenSelected(object sender, StreamPickControl_Remake.SelectedItemEventArgs e)
        {
            Console.WriteLine(e.SelectedChoice.title);
            changeTab(TabDirection.Forward);
            GenerateDownloadVODControl(e.SelectedChoice);
        }

        
        /// <summary>
        /// Sets up DownloadControl
        /// </summary>
        /// <param name="selectedVOD">SelectedVOD object to download</param>
        public void GenerateDownloadVODControl(VODObject selectedVOD)
        {
            downloadControl1.SetUpDownload(selectedVOD);
        }

        /// <summary>
        /// Button click event to change tabs backwards
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabBackButton_Click(object sender, EventArgs e)
        {
            changeTab(TabDirection.Back);
        }

        /// <summary>
        /// Button click event to change tabs forward
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabForwardButton_Click(object sender, EventArgs e)
        {
            changeTab(TabDirection.Forward);
        }

        /// <summary>
        /// Handles logic for changing tabs forward or backwards
        /// </summary>
        /// <param name="tabDirection">Tabdirection Object forward or backwards</param>
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

        /// <summary>
        /// Linked label click event that opens a new UserNameForm to change Properties.Settings UserName
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Properties.Settings.Default.Reset();
            new UserNameForm().ShowDialog();
            if (Properties.Settings.Default.UserName.Any())
            {
                loadMainPageItems();
                PickSelectedStreamer();
            }
        }

        private enum TabDirection
        {
            Forward,
            Back
        }

        /// <summary>
        /// Linked label click event that opens to the Properties.Settings UserName twitch page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserIdLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://twitch.tv/" + userIdLinkLabel.Text);
        }
    }

    
}
