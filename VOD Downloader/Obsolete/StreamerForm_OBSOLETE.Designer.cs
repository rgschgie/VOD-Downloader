namespace VOD_Downloader
{
    partial class StreamerForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.DownloadStream = new System.Windows.Forms.DataGridViewButtonColumn();
            this.StreamTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StreamThumbnail = new System.Windows.Forms.DataGridViewImageColumn();
            this.StreamDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.formSetupBgWorker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(283, 211);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(286, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(240, 186);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DownloadStream,
            this.StreamTitle,
            this.StreamThumbnail,
            this.StreamDescription});
            this.dataGridView1.Location = new System.Drawing.Point(12, 245);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(915, 473);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // DownloadStream
            // 
            this.DownloadStream.HeaderText = "Download";
            this.DownloadStream.Name = "DownloadStream";
            // 
            // StreamTitle
            // 
            this.StreamTitle.HeaderText = "Title";
            this.StreamTitle.Name = "StreamTitle";
            this.StreamTitle.Width = 300;
            // 
            // StreamThumbnail
            // 
            this.StreamThumbnail.HeaderText = "StreamThumbnail";
            this.StreamThumbnail.Name = "StreamThumbnail";
            this.StreamThumbnail.Width = 300;
            // 
            // StreamDescription
            // 
            this.StreamDescription.HeaderText = "StreamDescription";
            this.StreamDescription.Name = "StreamDescription";
            // 
            // formSetupBgWorker
            // 
            this.formSetupBgWorker.WorkerReportsProgress = true;

            // 
            // StreamerForm
            // 
            this.ClientSize = new System.Drawing.Size(939, 730);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Name = "StreamerForm";
            this.Load += new System.EventHandler(this.StreamerForm_LoadAsync);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewButtonColumn DownloadStream;
        private System.Windows.Forms.DataGridViewTextBoxColumn StreamTitle;
        private System.Windows.Forms.DataGridViewImageColumn StreamThumbnail;
        private System.Windows.Forms.DataGridViewTextBoxColumn StreamDescription;
        private System.ComponentModel.BackgroundWorker formSetupBgWorker;
    }
}