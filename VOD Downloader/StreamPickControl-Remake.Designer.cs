namespace VOD_Downloader
{
    partial class StreamPickControl_Remake
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PreviousButton = new System.Windows.Forms.Button();
            this.NextButton = new System.Windows.Forms.Button();
            this.StreamDataGridView = new System.Windows.Forms.DataGridView();
            this.DownloadButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.VODTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThumbnailImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.DescriptionText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedPeriodComboBox = new System.Windows.Forms.ComboBox();
            this.SortByComboBox = new System.Windows.Forms.ComboBox();
            this.ItemsPerPageComboBox = new System.Windows.Forms.ComboBox();
            this.VideoTypeComboBox = new System.Windows.Forms.ComboBox();
            this.CreatePeriodLabel = new System.Windows.Forms.Label();
            this.SortLabel = new System.Windows.Forms.Label();
            this.ItemsPerPageLabel = new System.Windows.Forms.Label();
            this.VideoTypeLabel = new System.Windows.Forms.Label();
            this.ApplyButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.StreamDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // PreviousButton
            // 
            this.PreviousButton.Location = new System.Drawing.Point(19, 527);
            this.PreviousButton.Name = "PreviousButton";
            this.PreviousButton.Size = new System.Drawing.Size(122, 23);
            this.PreviousButton.TabIndex = 8;
            this.PreviousButton.Text = "< Previous";
            this.PreviousButton.UseVisualStyleBackColor = true;
            this.PreviousButton.Visible = false;
            this.PreviousButton.Click += new System.EventHandler(this.PreviousButton_Click);
            // 
            // NextButton
            // 
            this.NextButton.Location = new System.Drawing.Point(654, 527);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(122, 23);
            this.NextButton.TabIndex = 7;
            this.NextButton.Text = "Next >";
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // StreamDataGridView
            // 
            this.StreamDataGridView.AllowUserToAddRows = false;
            this.StreamDataGridView.AllowUserToDeleteRows = false;
            this.StreamDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StreamDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DownloadButton,
            this.VODTitle,
            this.ThumbnailImage,
            this.DescriptionText});
            this.StreamDataGridView.Location = new System.Drawing.Point(19, 15);
            this.StreamDataGridView.Name = "StreamDataGridView";
            this.StreamDataGridView.ReadOnly = true;
            this.StreamDataGridView.RowTemplate.Height = 90;
            this.StreamDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.StreamDataGridView.Size = new System.Drawing.Size(757, 492);
            this.StreamDataGridView.TabIndex = 6;
            this.StreamDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.StreamDataGridView_CellContentClick);
            // 
            // DownloadButton
            // 
            this.DownloadButton.HeaderText = "Download";
            this.DownloadButton.Name = "DownloadButton";
            this.DownloadButton.ReadOnly = true;
            // 
            // VODTitle
            // 
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.VODTitle.DefaultCellStyle = dataGridViewCellStyle3;
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
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DescriptionText.DefaultCellStyle = dataGridViewCellStyle4;
            this.DescriptionText.HeaderText = "Description";
            this.DescriptionText.Name = "DescriptionText";
            this.DescriptionText.ReadOnly = true;
            this.DescriptionText.Width = 200;
            // 
            // CreatedPeriodComboBox
            // 
            this.CreatedPeriodComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreatedPeriodComboBox.FormattingEnabled = true;
            this.CreatedPeriodComboBox.Items.AddRange(new object[] {
            "all",
            "day",
            "week",
            "month"});
            this.CreatedPeriodComboBox.Location = new System.Drawing.Point(804, 104);
            this.CreatedPeriodComboBox.Name = "CreatedPeriodComboBox";
            this.CreatedPeriodComboBox.Size = new System.Drawing.Size(131, 24);
            this.CreatedPeriodComboBox.TabIndex = 9;
            this.CreatedPeriodComboBox.Text = "all";
            // 
            // SortByComboBox
            // 
            this.SortByComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.SortByComboBox.FormattingEnabled = true;
            this.SortByComboBox.Items.AddRange(new object[] {
            "time",
            "trending",
            "views"});
            this.SortByComboBox.Location = new System.Drawing.Point(804, 193);
            this.SortByComboBox.Name = "SortByComboBox";
            this.SortByComboBox.Size = new System.Drawing.Size(131, 24);
            this.SortByComboBox.TabIndex = 10;
            this.SortByComboBox.Text = "time";
            // 
            // ItemsPerPageComboBox
            // 
            this.ItemsPerPageComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.ItemsPerPageComboBox.FormattingEnabled = true;
            this.ItemsPerPageComboBox.Items.AddRange(new object[] {
            "10",
            "20",
            "40",
            "60",
            "80",
            "100"});
            this.ItemsPerPageComboBox.Location = new System.Drawing.Point(804, 294);
            this.ItemsPerPageComboBox.Name = "ItemsPerPageComboBox";
            this.ItemsPerPageComboBox.Size = new System.Drawing.Size(131, 24);
            this.ItemsPerPageComboBox.TabIndex = 11;
            this.ItemsPerPageComboBox.Text = "20";
            // 
            // VideoTypeComboBox
            // 
            this.VideoTypeComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.VideoTypeComboBox.FormattingEnabled = true;
            this.VideoTypeComboBox.Items.AddRange(new object[] {
            "all",
            "upload",
            "archive",
            "highlight"});
            this.VideoTypeComboBox.Location = new System.Drawing.Point(804, 392);
            this.VideoTypeComboBox.Name = "VideoTypeComboBox";
            this.VideoTypeComboBox.Size = new System.Drawing.Size(131, 24);
            this.VideoTypeComboBox.TabIndex = 12;
            this.VideoTypeComboBox.Text = "highlight";
            // 
            // CreatePeriodLabel
            // 
            this.CreatePeriodLabel.AutoSize = true;
            this.CreatePeriodLabel.Location = new System.Drawing.Point(827, 88);
            this.CreatePeriodLabel.Name = "CreatePeriodLabel";
            this.CreatePeriodLabel.Size = new System.Drawing.Size(80, 13);
            this.CreatePeriodLabel.TabIndex = 13;
            this.CreatePeriodLabel.Text = "Created Period:";
            // 
            // SortLabel
            // 
            this.SortLabel.AutoSize = true;
            this.SortLabel.Location = new System.Drawing.Point(843, 177);
            this.SortLabel.Name = "SortLabel";
            this.SortLabel.Size = new System.Drawing.Size(41, 13);
            this.SortLabel.TabIndex = 14;
            this.SortLabel.Text = "Sort By";
            // 
            // ItemsPerPageLabel
            // 
            this.ItemsPerPageLabel.AutoSize = true;
            this.ItemsPerPageLabel.Location = new System.Drawing.Point(828, 278);
            this.ItemsPerPageLabel.Name = "ItemsPerPageLabel";
            this.ItemsPerPageLabel.Size = new System.Drawing.Size(79, 13);
            this.ItemsPerPageLabel.TabIndex = 15;
            this.ItemsPerPageLabel.Text = "Items Per Page";
            // 
            // VideoTypeLabel
            // 
            this.VideoTypeLabel.AutoSize = true;
            this.VideoTypeLabel.Location = new System.Drawing.Point(843, 376);
            this.VideoTypeLabel.Name = "VideoTypeLabel";
            this.VideoTypeLabel.Size = new System.Drawing.Size(61, 13);
            this.VideoTypeLabel.TabIndex = 16;
            this.VideoTypeLabel.Text = "Video Type";
            // 
            // ApplyButton
            // 
            this.ApplyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ApplyButton.Location = new System.Drawing.Point(804, 458);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(131, 38);
            this.ApplyButton.TabIndex = 17;
            this.ApplyButton.Text = "Apply";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // StreamPickControl_Remake
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ApplyButton);
            this.Controls.Add(this.VideoTypeLabel);
            this.Controls.Add(this.ItemsPerPageLabel);
            this.Controls.Add(this.SortLabel);
            this.Controls.Add(this.CreatePeriodLabel);
            this.Controls.Add(this.VideoTypeComboBox);
            this.Controls.Add(this.ItemsPerPageComboBox);
            this.Controls.Add(this.SortByComboBox);
            this.Controls.Add(this.CreatedPeriodComboBox);
            this.Controls.Add(this.PreviousButton);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.StreamDataGridView);
            this.Name = "StreamPickControl_Remake";
            this.Size = new System.Drawing.Size(963, 650);
            ((System.ComponentModel.ISupportInitialize)(this.StreamDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button PreviousButton;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.DataGridView StreamDataGridView;
        private System.Windows.Forms.ComboBox CreatedPeriodComboBox;
        private System.Windows.Forms.ComboBox SortByComboBox;
        private System.Windows.Forms.ComboBox ItemsPerPageComboBox;
        private System.Windows.Forms.ComboBox VideoTypeComboBox;
        private System.Windows.Forms.Label CreatePeriodLabel;
        private System.Windows.Forms.Label SortLabel;
        private System.Windows.Forms.Label ItemsPerPageLabel;
        private System.Windows.Forms.Label VideoTypeLabel;
        private System.Windows.Forms.Button ApplyButton;
        private System.Windows.Forms.DataGridViewButtonColumn DownloadButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn VODTitle;
        private System.Windows.Forms.DataGridViewImageColumn ThumbnailImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescriptionText;
    }
}
