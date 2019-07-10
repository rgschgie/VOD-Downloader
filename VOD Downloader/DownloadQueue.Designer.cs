namespace VOD_Downloader
{
    partial class DownloadQueue
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
            this.itemsInQueueLabel = new System.Windows.Forms.Label();
            this.numItemsInQueueLabel = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.detailsButton = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // itemsInQueueLabel
            // 
            this.itemsInQueueLabel.AutoSize = true;
            this.itemsInQueueLabel.Location = new System.Drawing.Point(15, 24);
            this.itemsInQueueLabel.Name = "itemsInQueueLabel";
            this.itemsInQueueLabel.Size = new System.Drawing.Size(130, 13);
            this.itemsInQueueLabel.TabIndex = 0;
            this.itemsInQueueLabel.Text = "Number of items in queue:";
            // 
            // numItemsInQueueLabel
            // 
            this.numItemsInQueueLabel.AutoSize = true;
            this.numItemsInQueueLabel.Location = new System.Drawing.Point(141, 24);
            this.numItemsInQueueLabel.Name = "numItemsInQueueLabel";
            this.numItemsInQueueLabel.Size = new System.Drawing.Size(13, 13);
            this.numItemsInQueueLabel.TabIndex = 1;
            this.numItemsInQueueLabel.Text = "0";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(191, 10);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(450, 27);
            this.progressBar1.TabIndex = 2;
            // 
            // detailsButton
            // 
            this.detailsButton.Location = new System.Drawing.Point(59, 41);
            this.detailsButton.Name = "detailsButton";
            this.detailsButton.Size = new System.Drawing.Size(91, 23);
            this.detailsButton.TabIndex = 3;
            this.detailsButton.Text = "Show Details";
            this.detailsButton.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.SystemColors.Control;
            this.listView1.Location = new System.Drawing.Point(191, 41);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(450, 97);
            this.listView1.TabIndex = 5;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // DownloadQueue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.detailsButton);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.numItemsInQueueLabel);
            this.Controls.Add(this.itemsInQueueLabel);
            this.Name = "DownloadQueue";
            this.Size = new System.Drawing.Size(686, 156);
            this.Load += new System.EventHandler(this.DownloadQueue_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label itemsInQueueLabel;
        private System.Windows.Forms.Label numItemsInQueueLabel;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button detailsButton;
        private System.Windows.Forms.ListView listView1;
    }
}
