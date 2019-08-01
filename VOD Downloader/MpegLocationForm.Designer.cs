namespace VOD_Downloader
{
    partial class MpegLocationForm
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
            this.DownloadLinkLabel = new System.Windows.Forms.LinkLabel();
            this.FilePathTextBox = new System.Windows.Forms.TextBox();
            this.OpenFileButton = new System.Windows.Forms.Button();
            this.FormTitleLabel = new System.Windows.Forms.Label();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.ApplyButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DownloadLinkLabel
            // 
            this.DownloadLinkLabel.AutoSize = true;
            this.DownloadLinkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DownloadLinkLabel.Location = new System.Drawing.Point(120, 114);
            this.DownloadLinkLabel.Name = "DownloadLinkLabel";
            this.DownloadLinkLabel.Size = new System.Drawing.Size(170, 20);
            this.DownloadLinkLabel.TabIndex = 0;
            this.DownloadLinkLabel.TabStop = true;
            this.DownloadLinkLabel.Text = "Download ffmpeg here";
            this.DownloadLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel1_LinkClicked);
            // 
            // FilePathTextBox
            // 
            this.FilePathTextBox.Enabled = false;
            this.FilePathTextBox.Location = new System.Drawing.Point(80, 85);
            this.FilePathTextBox.Name = "FilePathTextBox";
            this.FilePathTextBox.Size = new System.Drawing.Size(236, 20);
            this.FilePathTextBox.TabIndex = 1;
            // 
            // OpenFileButton
            // 
            this.OpenFileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OpenFileButton.Location = new System.Drawing.Point(322, 85);
            this.OpenFileButton.Name = "OpenFileButton";
            this.OpenFileButton.Size = new System.Drawing.Size(35, 20);
            this.OpenFileButton.TabIndex = 2;
            this.OpenFileButton.Text = ". . .";
            this.OpenFileButton.UseVisualStyleBackColor = true;
            this.OpenFileButton.Click += new System.EventHandler(this.OpenFileButton_Click);
            // 
            // FormTitleLabel
            // 
            this.FormTitleLabel.AutoSize = true;
            this.FormTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormTitleLabel.Location = new System.Drawing.Point(46, 9);
            this.FormTitleLabel.Name = "FormTitleLabel";
            this.FormTitleLabel.Size = new System.Drawing.Size(381, 33);
            this.FormTitleLabel.TabIndex = 3;
            this.FormTitleLabel.Text = "FFmpeg Location Selector";
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.DescriptionLabel.Location = new System.Drawing.Point(80, 44);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(277, 40);
            this.DescriptionLabel.TabIndex = 4;
            this.DescriptionLabel.Text = "FFmpeg is used to complete, cross-platform solution to record, convert and stream" +
    " audio and video.";
            this.DescriptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ApplyButton
            // 
            this.ApplyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ApplyButton.Location = new System.Drawing.Point(162, 148);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(78, 28);
            this.ApplyButton.TabIndex = 5;
            this.ApplyButton.Text = "Apply";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // MpegLocationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 187);
            this.Controls.Add(this.ApplyButton);
            this.Controls.Add(this.DescriptionLabel);
            this.Controls.Add(this.FormTitleLabel);
            this.Controls.Add(this.OpenFileButton);
            this.Controls.Add(this.FilePathTextBox);
            this.Controls.Add(this.DownloadLinkLabel);
            this.Name = "MpegLocationForm";
            this.Text = "MpegLocationForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel DownloadLinkLabel;
        private System.Windows.Forms.TextBox FilePathTextBox;
        private System.Windows.Forms.Button OpenFileButton;
        private System.Windows.Forms.Label FormTitleLabel;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.Button ApplyButton;
    }
}