namespace VOD_Downloader
{
    partial class StreamPickControl
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
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.DownloadButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.VODTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThumbnailImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.DescriptionText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DownloadButton,
            this.VODTitle,
            this.ThumbnailImage,
            this.DescriptionText});
            this.dataGridView2.Location = new System.Drawing.Point(23, 20);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(757, 492);
            this.dataGridView2.TabIndex = 1;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView2_CellContentClick);
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
            // StreamPickControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView2);
            this.Name = "StreamPickControl";
            this.Size = new System.Drawing.Size(865, 593);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewButtonColumn DownloadButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn VODTitle;
        private System.Windows.Forms.DataGridViewImageColumn ThumbnailImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescriptionText;
    }
}
