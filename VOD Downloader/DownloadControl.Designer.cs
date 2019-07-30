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
            this.VideoQualityLabel = new System.Windows.Forms.Label();
            this.DownloadNameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.selectedVODPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pleaseWaitLabel
            // 
            this.pleaseWaitLabel.AutoSize = true;
            this.pleaseWaitLabel.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pleaseWaitLabel.ForeColor = System.Drawing.Color.Maroon;
            this.pleaseWaitLabel.Location = new System.Drawing.Point(264, 514);
            this.pleaseWaitLabel.Name = "pleaseWaitLabel";
            this.pleaseWaitLabel.Size = new System.Drawing.Size(151, 32);
            this.pleaseWaitLabel.TabIndex = 19;
            this.pleaseWaitLabel.Text = "please wait";
            this.pleaseWaitLabel.Visible = false;
            // 
            // PreparingToLoadLabel
            // 
            this.PreparingToLoadLabel.AutoSize = true;
            this.PreparingToLoadLabel.Font = new System.Drawing.Font("Arial", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PreparingToLoadLabel.ForeColor = System.Drawing.Color.Maroon;
            this.PreparingToLoadLabel.Location = new System.Drawing.Point(192, 472);
            this.PreparingToLoadLabel.Name = "PreparingToLoadLabel";
            this.PreparingToLoadLabel.Size = new System.Drawing.Size(297, 42);
            this.PreparingToLoadLabel.TabIndex = 18;
            this.PreparingToLoadLabel.Text = "Preparing to load";
            this.PreparingToLoadLabel.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(13, 554);
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
            this.DownloadStreamDownloadButton.Click += new System.EventHandler(this.DownloadStreamDownloadButton_Click_1);
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
            this.SizeLabel.Location = new System.Drawing.Point(182, 287);
            this.SizeLabel.Name = "SizeLabel";
            this.SizeLabel.Size = new System.Drawing.Size(351, 17);
            this.SizeLabel.TabIndex = 13;
            this.SizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CreatedLabel
            // 
            this.CreatedLabel.Location = new System.Drawing.Point(182, 260);
            this.CreatedLabel.Name = "CreatedLabel";
            this.CreatedLabel.Size = new System.Drawing.Size(351, 17);
            this.CreatedLabel.TabIndex = 12;
            this.CreatedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TitleLabel
            // 
            this.TitleLabel.Location = new System.Drawing.Point(182, 233);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(351, 17);
            this.TitleLabel.TabIndex = 11;
            this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(199, 336);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(334, 21);
            this.comboBox1.TabIndex = 10;
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
            // DownloadControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DownloadNameLabel);
            this.Controls.Add(this.VideoQualityLabel);
            this.Controls.Add(this.pleaseWaitLabel);
            this.Controls.Add(this.PreparingToLoadLabel);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.DownloadStreamDownloadButton);
            this.Controls.Add(this.FileNameTextBox);
            this.Controls.Add(this.SizeLabel);
            this.Controls.Add(this.CreatedLabel);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.selectedVODPictureBox);
            this.Name = "DownloadControl";
            this.Size = new System.Drawing.Size(776, 626);
            this.Load += new System.EventHandler(this.DownloadControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.selectedVODPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label pleaseWaitLabel;
        private System.Windows.Forms.Label PreparingToLoadLabel;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button DownloadStreamDownloadButton;
        private System.Windows.Forms.TextBox FileNameTextBox;
        private System.Windows.Forms.Label SizeLabel;
        private System.Windows.Forms.Label CreatedLabel;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.PictureBox selectedVODPictureBox;
        private System.Windows.Forms.Label VideoQualityLabel;
        private System.Windows.Forms.Label DownloadNameLabel;
    }
}
