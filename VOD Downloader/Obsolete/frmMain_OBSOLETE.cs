using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.IO;
using Newtonsoft.Json;
using NYoutubeDL;
using System.Diagnostics;

namespace VOD_Downloader
{
    public partial class frmMain : Form
    {

        List<UserInformation> StreamerInfo = null;


        public frmMain()
        {
            //used
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //used
            Task.Run(() => {
                datagridviewLayout();
            });
            
            
        }

        private async void datagridviewLayout()
        {

            var loadingPicture = new PictureBox()
            {
                Size = new Size(this.Size.Width, this.Size.Height),
                Location = new Point(0,0),
                Image = Properties.Resources.loadingIcon,
                BackColor = Color.Transparent
            };
            
            this.Controls.Add(loadingPicture);
            loadingPicture.BringToFront();
            this.Controls.Remove(loadingPicture);

            //used
            var user = await getUserInformation();
            StreamerInfo = user.User;
            dgv1.RowTemplate.MinimumHeight = 90;
            foreach (var usr in user.User)
            {
                System.Net.WebRequest request = System.Net.WebRequest.Create(usr.profile_image_url);
                System.Net.WebResponse response = request.GetResponse();
                System.IO.Stream responseStream = response.GetResponseStream();
                Bitmap bitmap2 = new Bitmap(responseStream);

                dgv1.Rows.Add("Select",bitmap2, usr.login);

            }

            
        }

        /// <summary>
        /// Gets followed streamers
        /// </summary>
        /// <returns>UserFollowData object wich has a list of followed streamers' information</returns>
        private async Task<UserFollowData> getFollowedStreamers()
        {
            //used
            UserFollowData returnValue = null;

            string twitchUserName = txtTwitchUserName.Text;
            int twitchUserID;

            twitchUserID = await getUserID(twitchUserName);
            returnValue = APICalls.GetFollowedStreamers(twitchUserID);

            return returnValue;
        }

        /// <summary>
        /// Get twitch user ID 
        /// </summary>
        /// <param name="username">Twitch username</param>
        /// <returns></returns>
        private async Task<int> getUserID(string username)
        {
            UserDataInformation userDataInformationObject = APICalls.GetStreamerInformation(username);
            return userDataInformationObject.User[0].id;
        }


        private async Task<UserDataInformation> getUserInformation()
        {
            //used
            UserDataInformation user = null;
            UserFollowData followedStreamerList = await getFollowedStreamers();

            string streamerLoginNames = "";
            //Create first 20 followed URL Query
            followedStreamerList.Data.ForEach(streamerFollowed => streamerLoginNames = streamerLoginNames + streamerFollowed.to_name + "&login=");
            //Cleaning up last "&login="
            streamerLoginNames = streamerLoginNames.Substring(0, streamerLoginNames.Length - 7);

            user = APICalls.GetStreamerInformation(streamerLoginNames);

            return user;
        }

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (StreamerInfo != null)
            {
                StreamerForm streamerForm = new StreamerForm(StreamerInfo[e.RowIndex]);
                streamerForm.Show();
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            TabForm tabform = new TabForm();
            tabform.Show();
        }
    }
}
