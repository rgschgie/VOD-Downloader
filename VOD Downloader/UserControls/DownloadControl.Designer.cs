namespace VOD_Downloader
{
    partial class DownloadControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.DownloadStreamDownloadButton = new System.Windows.Forms.Button();
            this.FileNameTextBox = new System.Windows.Forms.TextBox();
            this.SizeLabel = new System.Windows.Forms.Label();
            this.CreatedLabel = new System.Windows.Forms.Label();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.VideoQualityComboBox = new System.Windows.Forms.ComboBox();
            this.selectedVODPictureBox = new System.Windows.Forms.PictureBox();
            this.VideoQualityLabel = new System.Windows.Forms.Label();
            this.DownloadNameLabel = new System.Windows.Forms.Label();
            this.VideoTitleLabel = new System.Windows.Forms.Label();
            this.CreadedDateLabel = new System.Windows.Forms.Label();
            this.VideoLengthLabel = new System.Windows.Forms.Label();
            this.PickVideoQualityLabel = new System.Windows.Forms.Label();
            this.LoadingPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.selectedVODPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoadingPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(13, 580);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(731, 23);
            this.progressBar1.TabIndex = 17;
            // 
            // DownloadStreamDownloadButton
            // 
            this.DownloadStreamDownloadButton.Location = new System.Drawing.Point(258, 439);
            this.DownloadStreamDownloadButton.Name = "DownloadStreamDownloadButton";
            this.DownloadStreamDownloadButton.Size = new System.Drawing.Size(167, 23);
            this.DownloadStreamDownloadButton.TabIndex = 16;
            this.DownloadStreamDownloadButton.Text = "Download";
            this.DownloadStreamDownloadButton.UseVisualStyleBackColor = true;
            this.DownloadStreamDownloadButton.Click += new System.EventHandler(this.DownloadStreamDownloadButton_Click);
            // 
            // FileNameTextBox
            // 
            this.FileNameTextBox.Location = new System.Drawing.Point(199, 383);
            this.FileNameTextBox.Name = "FileNameTextBox";
            this.FileNameTextBox.Size = new System.Drawing.Size(334, 20);
            this.FileNameTextBox.TabIndex = 15;
            // 
            // SizeLabel
            // 
            this.SizeLabel.Location = new System.Drawing.Point(267, 281);
            this.SizeLabel.Name = "SizeLabel";
            this.SizeLabel.Size = new System.Drawing.Size(264, 17);
            this.SizeLabel.TabIndex = 13;
            this.SizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CreatedLabel
            // 
            this.CreatedLabel.Location = new System.Drawing.Point(266, 258);
            this.CreatedLabel.Name = "CreatedLabel";
            this.CreatedLabel.Size = new System.Drawing.Size(264, 17);
            this.CreatedLabel.TabIndex = 12;
            this.CreatedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TitleLabel
            // 
            this.TitleLabel.Location = new System.Drawing.Point(266, 235);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(264, 17);
            this.TitleLabel.TabIndex = 11;
            this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // VideoQualityComboBox
            // 
            this.VideoQualityComboBox.FormattingEnabled = true;
            this.VideoQualityComboBox.Location = new System.Drawing.Point(199, 336);
            this.VideoQualityComboBox.Name = "VideoQualityComboBox";
            this.VideoQualityComboBox.Size = new System.Drawing.Size(334, 21);
            this.VideoQualityComboBox.TabIndex = 10;
            // 
            // selectedVODPictureBox
            // 
            this.selectedVODPictureBox.Location = new System.Drawing.Point(185, 29);
            this.selectedVODPictureBox.Name = "selectedVODPictureBox";
            this.selectedVODPictureBox.Size = new System.Drawing.Size(348, 185);
            this.selectedVODPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.selectedVODPictureBox.TabIndex = 14;
            this.selectedVODPictureBox.TabStop = false;
            // 
            // VideoQualityLabel
            // 
            this.VideoQualityLabel.AutoSize = true;
            this.VideoQualityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VideoQualityLabel.Location = new System.Drawing.Point(101, 339);
            this.VideoQualityLabel.Name = "VideoQualityLabel";
            this.VideoQualityLabel.Size = new System.Drawing.Size(95, 15);
            this.VideoQualityLabel.TabIndex = 20;
            this.VideoQualityLabel.Text = "Video Quality:";
            // 
            // DownloadNameLabel
            // 
            this.DownloadNameLabel.AutoSize = true;
            this.DownloadNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DownloadNameLabel.Location = new System.Drawing.Point(79, 386);
            this.DownloadNameLabel.Name = "DownloadNameLabel";
            this.DownloadNameLabel.Size = new System.Drawing.Size(117, 15);
            this.DownloadNameLabel.TabIndex = 21;
            this.DownloadNameLabel.Text = "Download Name:";
            // 
            // VideoTitleLabel
            // 
            this.VideoTitleLabel.AutoSize = true;
            this.VideoTitleLabel.Location = new System.Drawing.Point(200, 235);
            this.VideoTitleLabel.Name = "VideoTitleLabel";
            this.VideoTitleLabel.Size = new System.Drawing.Size(60, 13);
            this.VideoTitleLabel.TabIndex = 22;
            this.VideoTitleLabel.Text = "Video Title:";
            // 
            // CreadedDateLabel
            // 
            this.CreadedDateLabel.AutoSize = true;
            this.CreadedDateLabel.Location = new System.Drawing.Point(187, 260);
            this.CreadedDateLabel.Name = "CreadedDateLabel";
            this.CreadedDateLabel.Size = new System.Drawing.Size(73, 13);
            this.CreadedDateLabel.TabIndex = 23;
            this.CreadedDateLabel.Text = "Date Created:";
            // 
            // VideoLengthLabel
            // 
            this.VideoLengthLabel.AutoSize = true;
            this.VideoLengthLabel.Location = new System.Drawing.Point(187, 285);
            this.VideoLengthLabel.Name = "VideoLengthLabel";
            this.VideoLengthLabel.Size = new System.Drawing.Size(73, 13);
            this.VideoLengthLabel.TabIndex = 24;
            this.VideoLengthLabel.Text = "Video Length:";
            // 
            // PickVideoQualityLabel
            // 
            this.PickVideoQualityLabel.AutoSize = true;
            this.PickVideoQualityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PickVideoQualityLabel.ForeColor = System.Drawing.Color.Red;
            this.PickVideoQualityLabel.Location = new System.Drawing.Point(280, 320);
            this.PickVideoQualityLabel.Name = "PickVideoQualityLabel";
            this.PickVideoQualityLabel.Size = new System.Drawing.Size(122, 13);
            this.PickVideoQualityLabel.TabIndex = 25;
            this.PickVideoQualityLabel.Text = "Pick a Video Quality";
            this.PickVideoQualityLabel.Visible = false;
            // 
            // LoadingPictureBox
            // 
            this.LoadingPictureBox.Location = new System.Drawing.Point(243, 468);
            this.LoadingPictureBox.Name = "LoadingPictureBox";
            this.LoadingPictureBox.Size = new System.Drawing.Size(194, 106);
            this.LoadingPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LoadingPictureBox.TabIndex = 26;
            this.LoadingPictureBox.TabStop = false;
            // 
            // DownloadControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LoadingPictureBox);
            this.Controls.Add(this.PickVideoQualityLabel);
            this.Controls.Add(this.VideoLengthLabel);
            this.Controls.Add(this.CreadedDateLabel);
            this.Controls.Add(this.VideoTitleLabel);
            this.Controls.Add(this.DownloadNameLabel);
            this.Controls.Add(this.VideoQualityLabel);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.DownloadStreamDownloadButton);
            this.Controls.Add(this.FileNameTextBox);
            this.Controls.Add(this.SizeLabel);
            this.Controls.Add(this.CreatedLabel);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.VideoQualityComboBox);
            this.Controls.Add(this.selectedVODPictureBox);
            this.Name = "DownloadControl";
            this.Size = new System.Drawing.Size(776, 626);
            ((System.ComponentModel.ISupportInitialize)(this.selectedVODPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoadingPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button DownloadStreamDownloadButton;
        private System.Windows.Forms.TextBox FileNameTextBox;
        private System.Windows.Forms.Label SizeLabel;
        private System.Windows.Forms.Label CreatedLabel;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.ComboBox VideoQualityComboBox;
        private System.Windows.Forms.PictureBox selectedVODPictureBox;
        private System.Windows.Forms.Label VideoQualityLabel;
        private System.Windows.Forms.Label DownloadNameLabel;
        private System.Windows.Forms.Label VideoTitleLabel;
        private System.Windows.Forms.Label CreadedDateLabel;
        private System.Windows.Forms.Label VideoLengthLabel;
        private System.Windows.Forms.Label PickVideoQualityLabel;
        private System.Windows.Forms.PictureBox LoadingPictureBox;
    }
}
