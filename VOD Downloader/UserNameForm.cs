using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VOD_Downloader
{
    public partial class UserNameForm : Form
    {
        public UserNameForm()
        {
            InitializeComponent();
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            saveValues();
            Close();
        }

        private void saveValues()
        {
            if (UserNameTextBox.Text.Any())
            {
                Properties.Settings.Default.UserName = UserNameTextBox.Text;
            }
            if (RememberMeCheckBox.Checked)
            {
                Properties.Settings.Default.isUserNameSet = true;
                Properties.Settings.Default.Save();
            }
        }

        private void UserNameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                saveValues();
                Close();
            }
        }
    }
}
