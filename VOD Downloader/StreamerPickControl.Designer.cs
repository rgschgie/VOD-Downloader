namespace VOD_Downloader
{
    partial class StreamerPickControl
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.SelectColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.StreamerPicture = new System.Windows.Forms.DataGridViewImageColumn();
            this.StreamerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
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
            this.dataGridView1.Location = new System.Drawing.Point(35, 21);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(776, 543);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellContentClick_1);
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
            // StreamerPickControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Name = "StreamerPickControl";
            this.Size = new System.Drawing.Size(867, 607);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewButtonColumn SelectColumn;
        private System.Windows.Forms.DataGridViewImageColumn StreamerPicture;
        private System.Windows.Forms.DataGridViewTextBoxColumn StreamerName;
    }
}
