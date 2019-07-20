using Newtonsoft.Json;
using NYoutubeDL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            loadMainPageItems();
            GetSelectedStreamer();
        }


        private void loadMainPageItems()
        {
            UserInformation userInformation = getUserInformation();

            _userID = userInformation.id;
            _userPictureURL = userInformation.profile_image_url;

            userPictureBox.Load(_userPictureURL);
            userIdLabel.Text = "feofeo0";
        }



        private void GetSelectedStreamer()
        {
            var uc = new StreamerPickControl();
            uc.ItemHasBeenSelected += uc_StreamerHasBeenSelected;

            tabPage4.Controls.Add(uc);
            uc.setupStreamerPickControl(_userID);
        }

        private void uc_StreamerHasBeenSelected(object sender, StreamerPickControl.SelectedItemEventArgs e)
        {
            GetSelectedStream(e.SelectedChoice);
            Console.WriteLine(e.SelectedChoice.login);
            tabControl1.SelectedIndex = 1;
        }

        private UserInformation getUserInformation()
        {

            UserDataInformation userDataInformationObject = APICalls.GetStreamerInformation("feofeo0");
            return userDataInformationObject.User[0];
        }

        public void GetSelectedStream(UserInformation selectedStreamer)
        {
            var uc = new StreamPickControl();
            uc.ItemHasBeenSelected += uc_StreamHasBeenSelected;

            tabPage5.Controls.Add(uc);
            uc.setupStreamPickControl(selectedStreamer);
        }
        private void uc_StreamHasBeenSelected(object sender, StreamPickControl.SelectedItemEventArgs e)
        {
            Console.WriteLine(e.SelectedChoice.title);
            tabControl1.SelectedIndex = 2;
            GenerateDownloadVODControl(e.SelectedChoice);
        }

        
        public void GenerateDownloadVODControl(VODObject selectedVOD)
        {
            var uc = new DownloadControl();
            tabPage6.Controls.Add(uc);
            uc.SetUpDownload(selectedVOD);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine(BaseURL.PastStreamURL.GetType()
            .GetMember(BaseURL.PastStreamURL.ToString())
            .FirstOrDefault()
            ?.GetCustomAttribute<DescriptionAttribute>()
            ?.Description
        ?? BaseURL.PastStreamURL.ToString());
        }
    }
}
