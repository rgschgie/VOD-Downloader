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
            this.StreamerDataGridView = new System.Windows.Forms.DataGridView();
            this.SelectColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.StreamerPicture = new System.Windows.Forms.DataGridViewImageColumn();
            this.StreamerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NextButton = new System.Windows.Forms.Button();
            this.PreviousButton = new System.Windows.Forms.Button();
            this.ItemsPerPageComboBox = new System.Windows.Forms.ComboBox();
            this.ItemsPerPageLabel = new System.Windows.Forms.Label();
            this.ApplyButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.StreamerDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // StreamerDataGridView
            // 
            this.StreamerDataGridView.AllowUserToAddRows = false;
            this.StreamerDataGridView.AllowUserToDeleteRows = false;
            this.StreamerDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StreamerDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SelectColumn,
            this.StreamerPicture,
            this.StreamerName});
            this.StreamerDataGridView.Location = new System.Drawing.Point(27, 18);
            this.StreamerDataGridView.Name = "StreamerDataGridView";
            this.StreamerDataGridView.ReadOnly = true;
            this.StreamerDataGridView.RowTemplate.Height = 90;
            this.StreamerDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.StreamerDataGridView.Size = new System.Drawing.Size(776, 543);
            this.StreamerDataGridView.TabIndex = 1;
            this.StreamerDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.StreamerGridView_CellContentClick);
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
            // NextButton
            // 
            this.NextButton.Location = new System.Drawing.Point(681, 580);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(122, 23);
            this.NextButton.TabIndex = 2;
            this.NextButton.Text = "Next >";
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // PreviousButton
            // 
            this.PreviousButton.Location = new System.Drawing.Point(27, 580);
            this.PreviousButton.Name = "PreviousButton";
            this.PreviousButton.Size = new System.Drawing.Size(122, 23);
            this.PreviousButton.TabIndex = 3;
            this.PreviousButton.Text = "< Previous";
            this.PreviousButton.UseVisualStyleBackColor = true;
            this.PreviousButton.Visible = false;
            this.PreviousButton.Click += new System.EventHandler(this.PreviousButton_Click);
            // 
            // ItemsPerPageComboBox
            // 
            this.ItemsPerPageComboBox.FormattingEnabled = true;
            this.ItemsPerPageComboBox.Items.AddRange(new object[] {
            "10",
            "20",
            "40",
            "60",
            "80",
            "100"});
            this.ItemsPerPageComboBox.Location = new System.Drawing.Point(838, 65);
            this.ItemsPerPageComboBox.Name = "ItemsPerPageComboBox";
            this.ItemsPerPageComboBox.Size = new System.Drawing.Size(121, 21);
            this.ItemsPerPageComboBox.TabIndex = 4;
            this.ItemsPerPageComboBox.Text = "20";
            // 
            // ItemsPerPageLabel
            // 
            this.ItemsPerPageLabel.AutoSize = true;
            this.ItemsPerPageLabel.Location = new System.Drawing.Point(853, 49);
            this.ItemsPerPageLabel.Name = "ItemsPerPageLabel";
            this.ItemsPerPageLabel.Size = new System.Drawing.Size(79, 13);
            this.ItemsPerPageLabel.TabIndex = 16;
            this.ItemsPerPageLabel.Text = "Items Per Page";
            // 
            // ApplyButton
            // 
            this.ApplyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ApplyButton.Location = new System.Drawing.Point(838, 511);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(131, 38);
            this.ApplyButton.TabIndex = 18;
            this.ApplyButton.Text = "Apply";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // StreamerPickControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ApplyButton);
            this.Controls.Add(this.ItemsPerPageLabel);
            this.Controls.Add(this.ItemsPerPageComboBox);
            this.Controls.Add(this.PreviousButton);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.StreamerDataGridView);
            this.Name = "StreamerPickControl";
            this.Size = new System.Drawing.Size(1011, 622);
            ((System.ComponentModel.ISupportInitialize)(this.StreamerDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView StreamerDataGridView;
        private System.Windows.Forms.DataGridViewButtonColumn SelectColumn;
        private System.Windows.Forms.DataGridViewImageColumn StreamerPicture;
        private System.Windows.Forms.DataGridViewTextBoxColumn StreamerName;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.Button PreviousButton;
        private System.Windows.Forms.ComboBox ItemsPerPageComboBox;
        private System.Windows.Forms.Label ItemsPerPageLabel;
        private System.Windows.Forms.Button ApplyButton;
    }
}
