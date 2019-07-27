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
            this.streamPickControl_Remake1 = new VOD_Downloader.StreamPickControl_Remake();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.downloadControl1 = new VOD_Downloader.DownloadControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.streamerPickControl = new VOD_Downloader.StreamerPickControl();
            this.loadingDoneLabel = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.SelectColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.StreamerPicture = new System.Windows.Forms.DataGridViewImageColumn();
            this.StreamerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.DownloadButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.VODTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThumbnailImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.DescriptionText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.pleaseWaitLabel = new System.Windows.Forms.Label();
            this.PreparingToLoadLabel = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.DownloadStreamDownloadButton = new System.Windows.Forms.Button();
            this.FileNameTextBox = new System.Windows.Forms.TextBox();
            this.SizeLabel = new System.Windows.Forms.Label();
            this.CreatedLabel = new System.Windows.Forms.Label();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.selectedVODPictureBox = new System.Windows.Forms.PictureBox();
            this.userIdLabel = new System.Windows.Forms.Label();
            this.userPictureBox = new System.Windows.Forms.PictureBox();
            this.TabBackButton = new System.Windows.Forms.Button();
            this.TabForwardButton = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectedVODPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(216, 46);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(848, 649);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage4.Controls.Add(this.streamerPickControl1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(840, 623);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "tabPage4";
            // 
            // streamerPickControl1
            // 
            this.streamerPickControl1.Location = new System.Drawing.Point(6, 0);
            this.streamerPickControl1.Name = "streamerPickControl1";
            this.streamerPickControl1.Size = new System.Drawing.Size(904, 615);
            this.streamerPickControl1.TabIndex = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage5.Controls.Add(this.streamPickControl_Remake1);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(840, 623);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "tabPage5";
            // 
            // streamPickControl_Remake1
            // 
            this.streamPickControl_Remake1.Location = new System.Drawing.Point(16, 17);
            this.streamPickControl_Remake1.Name = "streamPickControl_Remake1";
            this.streamPickControl_Remake1.Size = new System.Drawing.Size(822, 595);
            this.streamPickControl_Remake1.TabIndex = 0;
            // 
            // tabPage6
            // 
            this.tabPage6.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage6.Controls.Add(this.downloadControl1);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(840, 623);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "tabPage6";
            // 
            // downloadControl1
            // 
            this.downloadControl1.Location = new System.Drawing.Point(40, 17);
            this.downloadControl1.Name = "downloadControl1";
            this.downloadControl1.Size = new System.Drawing.Size(776, 626);
            this.downloadControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.streamerPickControl);
            this.tabPage1.Controls.Add(this.loadingDoneLabel);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(953, 623);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Followed Streamers";
            // 
            // streamerPickControl
            // 
            this.streamerPickControl.Location = new System.Drawing.Point(18, 3);
            this.streamerPickControl.Name = "streamerPickControl";
            this.streamerPickControl.Size = new System.Drawing.Size(849, 498);
            this.streamerPickControl.TabIndex = 2;
            // 
            // loadingDoneLabel
            // 
            this.loadingDoneLabel.AutoSize = true;
            this.loadingDoneLabel.Location = new System.Drawing.Point(77, 594);
            this.loadingDoneLabel.Name = "loadingDoneLabel";
            this.loadingDoneLabel.Size = new System.Drawing.Size(44, 13);
            this.loadingDoneLabel.TabIndex = 1;
            this.loadingDoneLabel.Text = "Nothing";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SelectColumn,
            this.StreamerPicture,
            this.StreamerName});
            this.dataGridView1.Location = new System.Drawing.Point(629, 507);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(297, 108);
            this.dataGridView1.TabIndex = 0;
            // 
            // SelectColumn
            // 
            this.SelectColumn.HeaderText = "Select";
            this.SelectColumn.Name = "SelectColumn";
            this.SelectColumn.ReadOnly = true;
            this.SelectColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SelectColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // StreamerPicture
            // 
            this.StreamerPicture.HeaderText = "Streamer Icon";
            this.StreamerPicture.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.StreamerPicture.Name = "StreamerPicture";
            this.StreamerPicture.ReadOnly = true;
            this.StreamerPicture.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.StreamerPicture.Width = 200;
            // 
            // StreamerName
            // 
            this.StreamerName.HeaderText = "StreamerName";
            this.StreamerName.Name = "StreamerName";
            this.StreamerName.ReadOnly = true;
            this.StreamerName.Width = 200;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.dataGridView2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(953, 623);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Past Streams";
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DownloadButton,
            this.VODTitle,
            this.ThumbnailImage,
            this.DescriptionText});
            this.dataGridView2.Location = new System.Drawing.Point(88, 83);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(757, 492);
            this.dataGridView2.TabIndex = 0;
            // 
            // DownloadButton
            // 
            this.DownloadButton.HeaderText = "Download";
            this.DownloadButton.Name = "DownloadButton";
            this.DownloadButton.ReadOnly = true;
            // 
            // VODTitle
            // 
            this.VODTitle.HeaderText = "Stream Title";
            this.VODTitle.Name = "VODTitle";
            this.VODTitle.ReadOnly = true;
            this.VODTitle.Width = 200;
            // 
            // ThumbnailImage
            // 
            this.ThumbnailImage.HeaderText = "Stream Thumbnail";
            this.ThumbnailImage.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.ThumbnailImage.Name = "ThumbnailImage";
            this.ThumbnailImage.ReadOnly = true;
            this.ThumbnailImage.Width = 200;
            // 
            // DescriptionText
            // 
            this.DescriptionText.HeaderText = "Description";
            this.DescriptionText.Name = "DescriptionText";
            this.DescriptionText.ReadOnly = true;
            this.DescriptionText.Width = 200;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Controls.Add(this.pleaseWaitLabel);
            this.tabPage3.Controls.Add(this.PreparingToLoadLabel);
            this.tabPage3.Controls.Add(this.progressBar1);
            this.tabPage3.Controls.Add(this.DownloadStreamDownloadButton);
            this.tabPage3.Controls.Add(this.FileNameTextBox);
            this.tabPage3.Controls.Add(this.SizeLabel);
            this.tabPage3.Controls.Add(this.CreatedLabel);
            this.tabPage3.Controls.Add(this.TitleLabel);
            this.tabPage3.Controls.Add(this.comboBox1);
            this.tabPage3.Controls.Add(this.selectedVODPictureBox);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(953, 623);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Download Stream";
            // 
            // pleaseWaitLabel
            // 
            this.pleaseWaitLabel.AutoSize = true;
            this.pleaseWaitLabel.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pleaseWaitLabel.ForeColor = System.Drawing.Color.Maroon;
            this.pleaseWaitLabel.Location = new System.Drawing.Point(344, 542);
            this.pleaseWaitLabel.Name = "pleaseWaitLabel";
            this.pleaseWaitLabel.Size = new System.Drawing.Size(151, 32);
            this.pleaseWaitLabel.TabIndex = 9;
            this.pleaseWaitLabel.Text = "please wait";
            this.pleaseWaitLabel.Visible = false;
            // 
            // PreparingToLoadLabel
            // 
            this.PreparingToLoadLabel.AutoSize = true;
            this.PreparingToLoadLabel.Font = new System.Drawing.Font("Arial", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PreparingToLoadLabel.ForeColor = System.Drawing.Color.Maroon;
            this.PreparingToLoadLabel.Location = new System.Drawing.Point(272, 500);
            this.PreparingToLoadLabel.Name = "PreparingToLoadLabel";
            this.PreparingToLoadLabel.Size = new System.Drawing.Size(297, 42);
            this.PreparingToLoadLabel.TabIndex = 8;
            this.PreparingToLoadLabel.Text = "Preparing to load";
            this.PreparingToLoadLabel.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(93, 590);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(731, 23);
            this.progressBar1.TabIndex = 7;
            // 
            // DownloadStreamDownloadButton
            // 
            this.DownloadStreamDownloadButton.Location = new System.Drawing.Point(338, 449);
            this.DownloadStreamDownloadButton.Name = "DownloadStreamDownloadButton";
            this.DownloadStreamDownloadButton.Size = new System.Drawing.Size(167, 23);
            this.DownloadStreamDownloadButton.TabIndex = 6;
            this.DownloadStreamDownloadButton.Text = "Download";
            this.DownloadStreamDownloadButton.UseVisualStyleBackColor = true;
            // 
            // FileNameTextBox
            // 
            this.FileNameTextBox.Location = new System.Drawing.Point(234, 393);
            this.FileNameTextBox.Name = "FileNameTextBox";
            this.FileNameTextBox.Size = new System.Drawing.Size(417, 20);
            this.FileNameTextBox.TabIndex = 5;
            // 
            // SizeLabel
            // 
            this.SizeLabel.AutoSize = true;
            this.SizeLabel.Location = new System.Drawing.Point(400, 262);
            this.SizeLabel.Name = "SizeLabel";
            this.SizeLabel.Size = new System.Drawing.Size(35, 13);
            this.SizeLabel.TabIndex = 3;
            this.SizeLabel.Text = "label3";
            // 
            // CreatedLabel
            // 
            this.CreatedLabel.AutoSize = true;
            this.CreatedLabel.Location = new System.Drawing.Point(400, 230);
            this.CreatedLabel.Name = "CreatedLabel";
            this.CreatedLabel.Size = new System.Drawing.Size(35, 13);
            this.CreatedLabel.TabIndex = 2;
            this.CreatedLabel.Text = "label2";
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Location = new System.Drawing.Point(400, 201);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(35, 13);
            this.TitleLabel.TabIndex = 1;
            this.TitleLabel.Text = "label1";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(279, 307);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(292, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // selectedVODPictureBox
            // 
            this.selectedVODPictureBox.Location = new System.Drawing.Point(279, 22);
            this.selectedVODPictureBox.Name = "selectedVODPictureBox";
            this.selectedVODPictureBox.Size = new System.Drawing.Size(292, 163);
            this.selectedVODPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.selectedVODPictureBox.TabIndex = 4;
            this.selectedVODPictureBox.TabStop = false;
            // 
            // userIdLabel
            // 
            this.userIdLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userIdLabel.Location = new System.Drawing.Point(103, 9);
            this.userIdLabel.Name = "userIdLabel";
            this.userIdLabel.Size = new System.Drawing.Size(197, 38);
            this.userIdLabel.TabIndex = 1;
            this.userIdLabel.Text = "label1";
            // 
            // userPictureBox
            // 
            this.userPictureBox.Location = new System.Drawing.Point(5, 5);
            this.userPictureBox.Name = "userPictureBox";
            this.userPictureBox.Size = new System.Drawing.Size(92, 85);
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
            this.TabBackButton.Click += new System.EventHandler(this.Button1_Click_1);
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
            this.TabForwardButton.Click += new System.EventHandler(this.Button2_Click);
            // 
            // TabForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1174, 907);
            this.Controls.Add(this.TabForwardButton);
            this.Controls.Add(this.TabBackButton);
            this.Controls.Add(this.userPictureBox);
            this.Controls.Add(this.userIdLabel);
            this.Controls.Add(this.tabControl1);
            this.Name = "TabForm";
            this.Text = "TabForm";
            this.Load += new System.EventHandler(this.TabForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectedVODPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label userIdLabel;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewButtonColumn SelectColumn;
        private System.Windows.Forms.DataGridViewImageColumn StreamerPicture;
        private System.Windows.Forms.DataGridViewTextBoxColumn StreamerName;
        private System.Windows.Forms.Label loadingDoneLabel;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewButtonColumn DownloadButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn VODTitle;
        private System.Windows.Forms.DataGridViewImageColumn ThumbnailImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescriptionText;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label SizeLabel;
        private System.Windows.Forms.Label CreatedLabel;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.TextBox FileNameTextBox;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button DownloadStreamDownloadButton;
        private System.Windows.Forms.Label PreparingToLoadLabel;
        private System.Windows.Forms.Label pleaseWaitLabel;
        private System.Windows.Forms.PictureBox selectedVODPictureBox;
        private System.Windows.Forms.PictureBox userPictureBox;
        private StreamerPickControl streamerPickControl;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private StreamerPickControl streamerPickControl1;
        private StreamPickControl_Remake streamPickControl_Remake1;
        private DownloadControl downloadControl1;
        private System.Windows.Forms.Button TabBackButton;
        private System.Windows.Forms.Button TabForwardButton;
    }
}