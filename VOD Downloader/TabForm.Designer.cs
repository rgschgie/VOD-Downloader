namespace VOD_Downloader
{
    partial class TabForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.streamerPickControl1 = new VOD_Downloader.StreamerPickControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.downloadControl1 = new VOD_Downloader.DownloadControl();
            this.userPictureBox = new System.Windows.Forms.PictureBox();
            this.TabBackButton = new System.Windows.Forms.Button();
            this.TabForwardButton = new System.Windows.Forms.Button();
            this.ResetLinkLabel = new System.Windows.Forms.LinkLabel();
            this.userIdLinkLabel = new System.Windows.Forms.LinkLabel();
            this.streamPickControl_Remake1 = new VOD_Downloader.StreamPickControl_Remake();
            this.tabControl1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Location = new System.Drawing.Point(216, 46);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(999, 649);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage4.Controls.Add(this.streamerPickControl1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(991, 623);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Followed Streamers";
            // 
            // streamerPickControl1
            // 
            this.streamerPickControl1.Location = new System.Drawing.Point(6, 0);
            this.streamerPickControl1.Name = "streamerPickControl1";
            this.streamerPickControl1.Size = new System.Drawing.Size(979, 615);
            this.streamerPickControl1.TabIndex = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage5.Controls.Add(this.streamPickControl_Remake1);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(991, 623);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Past Streams";
            // 
            // tabPage6
            // 
            this.tabPage6.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage6.Controls.Add(this.downloadControl1);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(991, 623);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Download Stream";
            // 
            // downloadControl1
            // 
            this.downloadControl1.Location = new System.Drawing.Point(40, 17);
            this.downloadControl1.Name = "downloadControl1";
            this.downloadControl1.Size = new System.Drawing.Size(776, 626);
            this.downloadControl1.TabIndex = 0;
            // 
            // userPictureBox
            // 
            this.userPictureBox.Location = new System.Drawing.Point(5, 5);
            this.userPictureBox.Name = "userPictureBox";
            this.userPictureBox.Size = new System.Drawing.Size(183, 159);
            this.userPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.userPictureBox.TabIndex = 2;
            this.userPictureBox.TabStop = false;
            // 
            // TabBackButton
            // 
            this.TabBackButton.Enabled = false;
            this.TabBackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabBackButton.Location = new System.Drawing.Point(216, 718);
            this.TabBackButton.Name = "TabBackButton";
            this.TabBackButton.Size = new System.Drawing.Size(164, 58);
            this.TabBackButton.TabIndex = 3;
            this.TabBackButton.Text = "Cannot go back";
            this.TabBackButton.UseVisualStyleBackColor = true;
            this.TabBackButton.Click += new System.EventHandler(this.TabBackButton_Click);
            // 
            // TabForwardButton
            // 
            this.TabForwardButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabForwardButton.Location = new System.Drawing.Point(876, 718);
            this.TabForwardButton.Name = "TabForwardButton";
            this.TabForwardButton.Size = new System.Drawing.Size(184, 58);
            this.TabForwardButton.TabIndex = 4;
            this.TabForwardButton.Text = "Forward to Past Streams";
            this.TabForwardButton.UseVisualStyleBackColor = true;
            this.TabForwardButton.Click += new System.EventHandler(this.TabForwardButton_Click);
            // 
            // ResetLinkLabel
            // 
            this.ResetLinkLabel.AutoSize = true;
            this.ResetLinkLabel.Location = new System.Drawing.Point(12, 167);
            this.ResetLinkLabel.Name = "ResetLinkLabel";
            this.ResetLinkLabel.Size = new System.Drawing.Size(125, 13);
            this.ResetLinkLabel.TabIndex = 5;
            this.ResetLinkLabel.TabStop = true;
            this.ResetLinkLabel.Text = "Choose another streamer";
            this.ResetLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ResetLinkLabel_LinkClicked);
            // 
            // userIdLinkLabel
            // 
            this.userIdLinkLabel.AutoSize = true;
            this.userIdLinkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userIdLinkLabel.Location = new System.Drawing.Point(194, 5);
            this.userIdLinkLabel.Name = "userIdLinkLabel";
            this.userIdLinkLabel.Size = new System.Drawing.Size(161, 25);
            this.userIdLinkLabel.TabIndex = 6;
            this.userIdLinkLabel.TabStop = true;
            this.userIdLinkLabel.Text = "Streamer Name";
            this.userIdLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.UserIdLinkLabel_LinkClicked);
            // 
            // streamPickControl_Remake1
            // 
            this.streamPickControl_Remake1.Location = new System.Drawing.Point(6, 6);
            this.streamPickControl_Remake1.Name = "streamPickControl_Remake1";
            this.streamPickControl_Remake1.Size = new System.Drawing.Size(963, 586);
            this.streamPickControl_Remake1.TabIndex = 0;
            // 
            // TabForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1390, 907);
            this.Controls.Add(this.userIdLinkLabel);
            this.Controls.Add(this.ResetLinkLabel);
            this.Controls.Add(this.TabForwardButton);
            this.Controls.Add(this.TabBackButton);
            this.Controls.Add(this.userPictureBox);
            this.Controls.Add(this.tabControl1);
            this.Name = "TabForm";
            this.Text = "TabForm";
            this.Load += new System.EventHandler(this.TabForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.userPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.PictureBox userPictureBox;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private StreamerPickControl streamerPickControl1;
        private DownloadControl downloadControl1;
        private System.Windows.Forms.Button TabBackButton;
        private System.Windows.Forms.Button TabForwardButton;
        private System.Windows.Forms.LinkLabel ResetLinkLabel;
        private System.Windows.Forms.LinkLabel userIdLinkLabel;
        private StreamPickControl_Remake streamPickControl_Remake1;
    }
}