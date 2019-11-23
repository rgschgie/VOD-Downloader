namespace VOD_Downloader
{
    partial class YoutubeDLLocationForm
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
            this.ApplyButton = new System.Windows.Forms.Button();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.FormTitleLabel = new System.Windows.Forms.Label();
            this.OpenFileButton = new System.Windows.Forms.Button();
            this.FilePathTextBox = new System.Windows.Forms.TextBox();
            this.DownloadLinkLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // ApplyButton
            // 
            this.ApplyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ApplyButton.Location = new System.Drawing.Point(158, 148);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(78, 28);
            this.ApplyButton.TabIndex = 11;
            this.ApplyButton.Text = "Apply";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click_1);
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.DescriptionLabel.Location = new System.Drawing.Point(76, 44);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(277, 40);
            this.DescriptionLabel.TabIndex = 10;
            this.DescriptionLabel.Text = "youtube-dl is a command-line program to download videos from YouTube.com and a fe" +
    "w more sites.";
            this.DescriptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormTitleLabel
            // 
            this.FormTitleLabel.AutoSize = true;
            this.FormTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormTitleLabel.Location = new System.Drawing.Point(12, 9);
            this.FormTitleLabel.Name = "FormTitleLabel";
            this.FormTitleLabel.Size = new System.Drawing.Size(412, 33);
            this.FormTitleLabel.TabIndex = 9;
            this.FormTitleLabel.Text = "youtube-dl Location Selector";
            // 
            // OpenFileButton
            // 
            this.OpenFileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OpenFileButton.Location = new System.Drawing.Point(318, 85);
            this.OpenFileButton.Name = "OpenFileButton";
            this.OpenFileButton.Size = new System.Drawing.Size(35, 20);
            this.OpenFileButton.TabIndex = 8;
            this.OpenFileButton.Text = ". . .";
            this.OpenFileButton.UseVisualStyleBackColor = true;
            this.OpenFileButton.Click += new System.EventHandler(this.OpenFileButton_Click_1);
            // 
            // FilePathTextBox
            // 
            this.FilePathTextBox.Enabled = false;
            this.FilePathTextBox.Location = new System.Drawing.Point(76, 85);
            this.FilePathTextBox.Name = "FilePathTextBox";
            this.FilePathTextBox.Size = new System.Drawing.Size(236, 20);
            this.FilePathTextBox.TabIndex = 7;
            // 
            // DownloadLinkLabel
            // 
            this.DownloadLinkLabel.AutoSize = true;
            this.DownloadLinkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DownloadLinkLabel.Location = new System.Drawing.Point(104, 114);
            this.DownloadLinkLabel.Name = "DownloadLinkLabel";
            this.DownloadLinkLabel.Size = new System.Drawing.Size(194, 20);
            this.DownloadLinkLabel.TabIndex = 6;
            this.DownloadLinkLabel.TabStop = true;
            this.DownloadLinkLabel.Text = "Download youtube-dl here";
            this.DownloadLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.DownloadLinkLabel_LinkClicked);
            // 
            // YoutubeDLLocationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 193);
            this.Controls.Add(this.ApplyButton);
            this.Controls.Add(this.DescriptionLabel);
            this.Controls.Add(this.FormTitleLabel);
            this.Controls.Add(this.OpenFileButton);
            this.Controls.Add(this.FilePathTextBox);
            this.Controls.Add(this.DownloadLinkLabel);
            this.Name = "YoutubeDLLocationForm";
            this.Text = "YoutubeDLLocationForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ApplyButton;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.Label FormTitleLabel;
        private System.Windows.Forms.Button OpenFileButton;
        private System.Windows.Forms.TextBox FilePathTextBox;
        private System.Windows.Forms.LinkLabel DownloadLinkLabel;
    }
}